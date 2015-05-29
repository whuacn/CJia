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
    public partial class ProjectManageView : CJia.Health.Tools.View, CJia.Health.Views.IProjectManageView
    {
        public ProjectManageView()
        {
            InitializeComponent();
            //初始载入页面绑定项目
            LoadData();
            //获取网格焦点数据
            GetFocusData();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ProjectManagePresenter(this);
        }

        CJia.Health.Views.ProjectKeyWordArg projectArg = new Views.ProjectKeyWordArg();

        private void ProjectManageView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight - 7;
            int location = (formWidth - pnlProject.Width) / 2;
            pnlProject.Location = new Point(location, 9);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        /// <summary>
        /// 查询项目信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string keyWord = ProjectSearch.Text;
            projectArg.KeyWord = keyWord;
            OnQueryProject(null, projectArg);
        }

        /// <summary>
        /// 把用户选中的项目信息展示出来
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
                TxtProName.Text = dr["PRO_NAME"].ToString();
                TxtProNo.Text = dr["PRO_NO"].ToString();
                TxtProPinyin.Text = dr["FIRST_PINYIN"].ToString();
                ckLook.Checked = dr["IS_LOOK"].ToString() == "1" ? true : false;
                ckPrint.Checked = dr["IS_PRINT"].ToString() == "1" ? true : false;//by dh
                ckExport.Checked = dr["IS_EXPORT"].ToString() == "1" ? true : false;
                projectArg.ProId = dr["PRO_ID"].ToString();
                txtKey.Text = dr["SHORT_KEY"].ToString();
            }
        }

        /// <summary>
        /// 获取修改后的项目信息并修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateProject_Click(object sender, EventArgs e)
        {
            string shortKey = "";
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
                shortKey = dr["SHORT_KEY"].ToString();
            if (Common.CheckIsNotNull(this, "TxtProNo", "项目编号") && Common.CheckIsNotNull(this, "TxtProName", "项目名称") && Common.CheckIsNotNull(this, "TxtProPinyin", "项目查询码"))
            {
                projectArg.ProjectName = TxtProName.Text;
                projectArg.ProNo = TxtProNo.Text;
                projectArg.shortKey = txtKey.Text.Trim().ToUpper(); ;
                projectArg.ProPinyin = CJia.Controls.CJiaSpellEditor.ToChString(TxtProName.Text).ToUpper();
                TxtProPinyin.Text = projectArg.ProPinyin;
                projectArg.UserID = User.UserData.Rows[0]["USER_ID"].ToString();
                projectArg.isPrint = ckPrint.Checked == true ? "1" : "0";//by dh
                projectArg.isLook = ckLook.Checked == true ? "1" : "0";
                projectArg.isExport = ckExport.Checked == true ? "1" : "0";
                Models.ProjectManageModel model = new Models.ProjectManageModel();
                int i = model.CheckProIsRepeat(projectArg.ProNo, projectArg.ProId);
                bool bol = model.IsShortKey(txtKey.Text.Trim().ToUpper());
                if (!bol || shortKey == txtKey.Text.Trim().ToUpper())
                {
                    if (i == 0)
                    {
                        if (CJia.Health.Tools.Message.ShowQuery("是否修改此项目", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                        {
                            OnUpdateProject(null, projectArg);
                            LoadData();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Message.ShowWarning("此项目编号已存在！");
                        TxtProNo.Focus();
                    }
                }
                else
                {
                    Message.ShowWarning("存在相同的快捷键，请重新输入！");
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 添加新项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddProject_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "TxtProNo", "项目编号") && Common.CheckIsNotNull(this, "TxtProName", "项目名称") && Common.CheckIsNotNull(this, "TxtProPinyin", "项目查询码"))
            {
                projectArg.ProjectName = TxtProName.Text;
                projectArg.ProNo = TxtProNo.Text;
                projectArg.shortKey = txtKey.Text.Trim().ToUpper();
                projectArg.ProPinyin = CJia.Controls.CJiaSpellEditor.ToChString(TxtProName.Text).ToUpper();
                TxtProPinyin.Text = projectArg.ProPinyin;
                projectArg.UserID = User.UserData.Rows[0]["USER_ID"].ToString();
                projectArg.ProId = " ";
                projectArg.isPrint = ckPrint.Checked == true ? "1" : "0";//by dh
                projectArg.isLook = ckLook.Checked == true ? "1" : "0";
                projectArg.isExport = ckExport.Checked == true ? "1" : "0";
                Models.ProjectManageModel model = new Models.ProjectManageModel();//这。。。严重违反MVP模式
                int i = model.CheckProIsRepeat(projectArg.ProNo, projectArg.ProId);
                bool bol = model.IsShortKey(txtKey.Text.Trim().ToUpper());
                if (!bol)
                {
                    if (i == 0)
                    {
                        if (CJia.Health.Tools.Message.ShowQuery("是否添加此项目？", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                        {
                            OnInsertProject(null, projectArg);
                            LoadData();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Message.ShowWarning("此编号已存在！");
                        TxtProNo.Focus();
                    }
                }
                else
                {
                    Message.ShowWarning("存在相同的快捷键，请重新输入！");
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 删除一条选中项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProjectDelect_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                projectArg.ProId = dr["PRO_ID"].ToString();
                projectArg.UserID = User.UserData.Rows[0]["USER_ID"].ToString();
                if (CJia.Health.Tools.Message.ShowQuery("是否删除此项目？", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                {
                    OnDeleteProject(null, projectArg);
                    LoadData();
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 把项目信息编辑框的值清空
        /// </summary>
        private void ClearControlText()
        {
            TxtProName.Text = null;
            TxtProNo.Text = null;
            TxtProPinyin.Text = null;
        }

        /// <summary>
        ///初始化载入数据
        /// </summary>
        private void LoadData()
        {
            projectArg.KeyWord = "";
            OnQueryProject(null, projectArg);
        }

        #region【实现接口】
        public event EventHandler<Views.ProjectKeyWordArg> OnQueryProject;

        public event EventHandler<Views.ProjectKeyWordArg> OnUpdateProject;

        public event EventHandler<Views.ProjectKeyWordArg> OnInsertProject;

        public event EventHandler<Views.ProjectKeyWordArg> OnDeleteProject;

        /// <summary>
        /// 把项目数据绑定到网格中
        /// </summary>
        /// <param name="dt"></param>
        public void ExeBindProject(DataTable dt)
        {
            ProjectGrid.DataSource = dt;
        }
        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    BtnAddProject.Focus();
                    this.BtnAddProject_Click(null, null);
                    return true;
                case Keys.F2:
                    BtnUpdateProject.Focus();
                    this.BtnUpdateProject_Click(null, null);
                    return true;
                case Keys.F3:
                    BtnProjectDelect.Focus();
                    BtnProjectDelect_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void ckLook_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckLook.Checked)
            {
                ckPrint.Checked = false;
                ckExport.Checked = false;
            }
        }

        private void ckPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPrint.Checked)
            {
                ckLook.Checked = true;
            }
            else
            {
                ckExport.Checked = false; 
            }
        }

        private void ckExport_CheckedChanged(object sender, EventArgs e)
        {
            if (ckExport.Checked)
            {
                ckLook.Checked = true;
                ckPrint.Checked = true;
            }
        }

    }
}
