using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PEIS.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }


        #region 窗体事件
        //起始页
        private void PnlHome_Click(object sender, EventArgs e)
        {
            UI.HomePageView home=new UI.HomePageView();
            CJia.PEIS.Tools.Help.NewBorderForm(home);
        }
        //评估模板维护
        private void btnAssTemMan_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;//获得tabpage名称
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.AssTemManView atmv = new UI.AssTemManView();
                tabMain.ShowPage(pageTitle, atmv);
            }
        }
        //智能评估
        private void btnInteAssMan_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;//获得tabpage名称
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.InteAssManView iamv = new UI.InteAssManView();
                tabMain.ShowPage(pageTitle, iamv);
            }
        }
        //操作员管理
        private void btnAdminHandel_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;//获得tabpage名称
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.AdminHandleView rguc = new UI.AdminHandleView();
                tabMain.ShowPage(pageTitle, rguc);
            }
        }

        // 体检科室设置
        private void btnDeptHandel_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.DeptView rguc = new UI.DeptView();
                tabMain.ShowPage(pageTitle, rguc);
            }
        }

        // 体检项目设置
        private void btnProHandle_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.ProjectView rguc = new UI.ProjectView();
                tabMain.ShowPage(pageTitle, rguc);
            }
        }
        // 组合项目设置
        private void btnGroupPro_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.GroupProjectView rguc = new UI.GroupProjectView();
                tabMain.ShowPage(pageTitle, rguc);
            }
        }

        // 单位维护
        private void btnInstitutionHandle_Click(object sender, EventArgs e)
        {
            string pageTitle = (sender as ToolStripMenuItem).Text;
            if (!tabMain.isExistPage(pageTitle))
            {
                UI.InstitutionView rguc = new UI.InstitutionView();
                tabMain.ShowPage(pageTitle, rguc);
            }
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Initialize()
        {
            lblLoginTime.Text = User.LoginTime.ToString("yyyy-MM-dd HH:mm:ss");
            lblUserName.Text = User.UserData.Rows[0]["user_name"].ToString();
        }

        #endregion
    }
}
