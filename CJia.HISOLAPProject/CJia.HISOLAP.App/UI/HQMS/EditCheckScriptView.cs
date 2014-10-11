using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.HISOLAP.Views;

namespace CJia.HISOLAP.App.UI.HQMS
{
    public partial class EditCheckScriptView : CJia.HISOLAP.Tools.View, Views.ICheckScript
    {
        public enum Type
        {
            /// <summary>
            /// 新增界面
            /// </summary>
            Add,
            /// <summary>
            /// 修改界面
            /// </summary>
            Modify
        }
        /// <summary>
        /// 用于判断是新增界面还是修改界面
        /// </summary>
        private Type typeH;
        /// <summary>
        /// 用于修改时判断编号有没有更改
        /// </summary>
        private string NO;
        private string ID;
        public EditCheckScriptView(Type type, DataRow dr)
        {
            InitializeComponent();
            if (OnQueryCheckType != null)
                OnQueryCheckType(null, null);
            switch (type)
            {
                case Type.Add:
                    typeH = Type.Add;
                    lblMeg.Text = "新增审核脚本";
                    btnSave1.CustomText = "添加(F8)";
                    cbStatus.Visible = false;
                    lblStatus.Visible = false;
                    Reset();
                    break;
                case Type.Modify:
                    typeH = Type.Modify;
                    lblMeg.Text = "修改审核脚本";
                    btnSave1.CustomText = "保存(F8)";
                    InitView(dr);
                    break;
                default:
                    break;
            }
        }
        public EditCheckScriptView()
        {
            InitializeComponent();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.CheckScriptPresenter(this);
        }
        CheckScriptArgs checkScriptArgs = new CheckScriptArgs();
        public event EventHandler OnInitView;
        public event EventHandler<CheckScriptArgs> OnDelete;
        public event EventHandler<CheckScriptArgs> OnSearch;
        public event EventHandler<CheckScriptArgs> OnAdd;
        public event EventHandler<CheckScriptArgs> OnModify;
        public event EventHandler OnQueryCheckType;
        public void ExeFocusNO() 
        {
            txtNO.Focus();
            txtNO.SelectAll();
        }
        public void ExeBindCheckTypeData(DataTable data)
        {
            cbType.Properties.DataSource = data;
            cbType.Properties.DisplayMember = "NAME";
            cbType.Properties.ValueMember = "CODE";
        }
        public void ExeBindData(DataTable data) { }
        public void ExeIsSuccessDelete(bool bol)
        {

        }
        public void ExeIsSuccessAdd(bool bol)
        {
            if (bol)
            {
                Reset();
                txtNO.Focus();
            }
            else
            {
                Message.Show("添加失败！");
            }
        }
        public void ExeIsSuccessModify(bool bol)
        {
            if (bol)
            {
                this.ParentForm.Close();
            }
            else
            {
                Message.Show("保存失败！");
            }
        }
        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (!isRightScript()) return; //判断非空项
            if (typeH == Type.Add) //新增界面
            {
                BindValue();
                OnAdd(null, checkScriptArgs);
            }
            else
            {
                checkScriptArgs.OldNO = NO;
                checkScriptArgs.Status = cbStatus.Text == "有效" ? "1" : "0";
                checkScriptArgs.ID = ID;
                BindValue();
                OnModify(null, checkScriptArgs);
            }
        }


        #region 内部调用方法
        /// <summary>
        /// 绑定值
        /// </summary>
        public void BindValue()
        {
            checkScriptArgs.NO = txtNO.Text.Trim();
            checkScriptArgs.Test = txtTest.Text.Trim();
            checkScriptArgs.Error = txtError.Text.Trim();
            checkScriptArgs.CheckID = cbType.EditValue.ToString();
            checkScriptArgs.Level = txtLevel.Text.Trim();
            checkScriptArgs.Classify = txtClassfiy.Text.Trim();
        }
        /// <summary>
        /// 用于修改初始化界面
        /// </summary>
        /// <param name="dr"></param>
        private void InitView(DataRow dr)
        {
            if (dr != null)
            {
                NO = dr["CS_NO"].ToString();
                ID = dr["ID"].ToString();
                txtNO.Text = dr["CS_NO"].ToString();
                txtTest.Text = dr["CS_TEXT"].ToString();
                txtError.Text = dr["CS_ERROR"].ToString();
                txtLevel.Text = dr["CHECK_LEVEL"].ToString();
                txtClassfiy.Text = dr["CHECK_CLASSIFY"].ToString();
                cbStatus.Text = dr["STATUS_NAME"].ToString().Length == 0 ? "有效" : "无效";
                cbType.EditValue = dr["CHECK_ID"].ToString();
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {
            txtNO.Text = "";
            txtTest.Text = "";
            txtError.Text = "";
            txtLevel.Text = "";
            txtClassfiy.Text = "";
            cbStatus.Text = "";
            cbType.Text = "";
        }
        private bool isRightScript()
        {
            if (txtNO.Text.Trim().Length == 0)
            {
                Message.Show("编号不能为空");
                txtNO.Focus();
                return false;
            }
            if (txtTest.Text.Trim().Length == 0)
            {
                Message.Show("审核脚本不能为空");
                txtTest.Focus();
                return false;
            }
            if (txtError.Text.Trim().Length == 0)
            {
                Message.Show("错误提示不能为空");
                txtError.Focus();
                return false;
            }
            if (cbType.Text.Length == 0)
            {
                Message.Show("审核类型不能为空");
                cbType.Focus();
                return false;
            }
            return true;
        }
        #endregion

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnSave1.Focus();
                    btnSave1_Click(null, null);
                    return true;
                case Keys.F4:
                    btnClose1.Focus();
                    btnClose1_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
