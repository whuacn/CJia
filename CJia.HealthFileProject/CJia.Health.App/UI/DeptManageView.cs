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
    public partial class DeptManageView : CJia.Health.Tools.View, CJia.Health.Views.IDeptManageView
    {
        public DeptManageView()
        {
            InitializeComponent();
            //初始载入页面绑定科室
            LoadData();
            GetFocusData();
        }

        Views.DeptArgs deptArgs = new Views.DeptArgs();

        protected override object CreatePresenter()
        {
            return new Presenters.DeptManagePresenter(this);
        }

        private void DeptManageView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlDept.Width) / 2;
            pnlDept.Location = new Point(location, 5);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        /// <summary>
        /// 查询科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeptSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            deptArgs.KewWord = DeptSearch.Text;
            OnQueryDept(null, deptArgs);
        }

        /// <summary>
        /// 获取或得焦点行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetFocusData();
        }

        /// <summary>
        /// 获得网格焦点行的数据
        /// </summary>
        private void GetFocusData()
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                TxtDeptName.Text = dr["DEPT_NAME"].ToString();
                TxtDeptNo.Text = dr["DEPT_NO"].ToString();
                TxtDeptPinyin.Text = dr["FIRST_PINYIN"].ToString();
                deptArgs.DeptId = dr["DEPT_ID"].ToString();
            }
        }

        /// <summary>
        /// 添加一条科室信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDept_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "TxtDeptName", "科室名称") || Common.CheckIsNotNull(this, "TxtDeptNo", "科室编号") || Common.CheckIsNotNull(this, "TxtDeptPinyin", "科室拼音查询码"))
            {
                SetDeptArgs();
                Models.DeptManageModel model = new Models.DeptManageModel();
                deptArgs.DeptId = " ";
                int i = model.CheckDeptIsRepeat(deptArgs.DeptNo, deptArgs.DeptId);
                if (i == 0)
                {
                    if (CJia.Health.Tools.Message.ShowQuery("是否添加此科室", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                    {
                        OnAddDept(null, deptArgs);
                        LoadData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("此科室编号已存在");
                    TxtDeptNo.Focus();
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 修改科室信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateDept_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "TxtDeptName", "科室名称") || Common.CheckIsNotNull(this, "TxtDeptNo", "科室编号") || Common.CheckIsNotNull(this, "TxtDeptPinyin", "科室拼音查询码"))
            {
                SetDeptArgs();
                Models.DeptManageModel model = new Models.DeptManageModel();
                int i = model.CheckDeptIsRepeat(deptArgs.DeptNo, deptArgs.DeptId);
                if (i == 0)
                {
                    if (CJia.Health.Tools.Message.ShowQuery("是否修改此科室信息", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                    {
                        OnUpdateDept(null, deptArgs);
                        LoadData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("此科室编号已存在");
                    TxtDeptNo.Focus();
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeptDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                deptArgs.UserID = User.UserData.Rows[0]["USER_ID"].ToString();
                deptArgs.DeptId = dr["DEPT_ID"].ToString();
                if (CJia.Health.Tools.Message.ShowQuery("是否添加此项目", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                {
                    OnDeleteDept(null, deptArgs);
                    LoadData();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 给参数类赋值
        /// </summary>
        private void SetDeptArgs()
        {
            deptArgs.DeptNo = TxtDeptNo.Text;
            deptArgs.DeptName = TxtDeptName.Text;
            deptArgs.DeptPinYin = CJia.Controls.CJiaSpellEditor.ToChString(TxtDeptName.Text).ToUpper() ;
            TxtDeptPinyin.Text = deptArgs.DeptPinYin;
            deptArgs.UserID = User.UserData.Rows[0]["USER_ID"].ToString();
        }

        /// <summary>
        ///初始化载入数据
        /// </summary>
        private void LoadData()
        {
            deptArgs.KewWord = "";
            OnQueryDept(null, deptArgs);
        }

        #region【实现接口】
        public event EventHandler<Views.DeptArgs> OnQueryDept;

        public event EventHandler<Views.DeptArgs> OnUpdateDept;

        public event EventHandler<Views.DeptArgs> OnAddDept;

        public event EventHandler<Views.DeptArgs> OnDeleteDept;

        /// <summary>
        /// 绑定Grid
        /// </summary>
        /// <param name="dtDept"></param>
        public void ExeBindDept(DataTable dtDept)
        {
            DeptGrid.DataSource = dtDept;
        }
        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    BtnAddDept.Focus();
                    this.BtnAddDept_Click(null, null);
                    return true;
                case Keys.F2:
                    BtnUpdateDept.Focus();
                    this.BtnUpdateDept_Click(null, null);
                    return true;
                case Keys.F3:
                    BtnDeptDelete.Focus();
                    BtnDeptDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
 
    }
}
