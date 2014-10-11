using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class RoleFunctionView : CJia.Health.Tools.View,CJia.Health.Views.IRoleFunctionView
    {
        public RoleFunctionView()
        {
            InitializeComponent();
            OnInit(null,null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.RoleFunctionPresenter(this);
        }

        Views.RoleFunctionArgs roleFounctionArgs = new Views.RoleFunctionArgs();

        #region【初始绑定事件】
        /// <summary>
        /// 绑定用户类型
        /// </summary>
        /// <param name="dtUserType"></param>
        public void ExeBindUserType(DataTable dtUserType)
        {
            cboUserType.Properties.DataSource = dtUserType;
            cboUserType.Properties.DisplayMember = "NAME";
            cboUserType.Properties.ValueMember = "CODE";
        }

        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtGridRole"></param>
        public void ExeBindGridRole(DataTable dtGridRole)
        {
            gridRole.DataSource = dtGridRole;
        }
        #endregion

        #region 【控件生成事件】
        private void RoleFunctionView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlRoleFun.Width) / 2;
            pnlRoleFun.Location = new Point(location, 9);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        // 网格单击事件
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                txtFounctionName.Text = dr["FUNCTION_NAME"].ToString();
                cboUserType.Text = dr["NAME"].ToString();
                cboUserType.EditValue = dr["USER_TYPE"].ToString();

                roleFounctionArgs.FunctionId = long.Parse(dr["FUNCTION_ID"].ToString());
            }
            else
            {
                return;
            }
        }

        // 新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetValue();
            OnAdd(sender, roleFounctionArgs);
        }

        // 更新
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetValue();
             DataRow dr = gridView1.GetFocusedDataRow();
             if (dr != null)
             {
                 roleFounctionArgs.ExistName = dr["FUNCTION_NAME"].ToString();
             }
            OnUpdate(sender, roleFounctionArgs);
        }

        // 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
             DataRow dr = gridView1.GetFocusedDataRow();
             if (dr != null)
             {
                 roleFounctionArgs.FunctionId = long.Parse(dr["FUNCTION_ID"].ToString());
                 roleFounctionArgs.FuncionName = dr["FUNCTION_NAME"].ToString();
                 OnDelete(sender, roleFounctionArgs);
                 OnInit(null, null);
             }
             else
             {
                 txtFounctionName.Text = "";
                 cboUserType.Text = "";
             }
        }

        /// <summary>
        /// 取界面控件所编辑值
        /// </summary>
        void SetValue()
        {
            roleFounctionArgs.FuncionName = txtFounctionName.Text;
            roleFounctionArgs.UserType = long.Parse(cboUserType.EditValue.ToString());
        }
        #endregion

        #region 【事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.RoleFunctionArgs> OnInit;

        /// <summary>
        /// 添加事件
        /// </summary>
        public event EventHandler<Views.RoleFunctionArgs> OnAdd;

        /// <summary>
        /// 更新事件
        /// </summary>
        public event EventHandler<Views.RoleFunctionArgs> OnUpdate;

        /// <summary>
        /// 删除事件
        /// </summary>
        public event EventHandler<Views.RoleFunctionArgs> OnDelete;

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        public event EventHandler<Views.RoleFunctionArgs> OnFocusedRowChanged;

        /// <summary>
        /// 查询
        /// </summary>
        public event EventHandler<Views.UserArgs> OnSearch;

        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
       {
            switch (keyData)
            {
                case Keys.F1:
                    btnAdd.Focus();
                    this.btnAdd_Click(null, null);
                    return true;
                case Keys.F2:
                    btnUpdate.Focus();
                    this.btnUpdate_Click(null, null);
                    return true;
                case Keys.F3:
                    btnDelete.Focus();
                    btnDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

      
    }
}
