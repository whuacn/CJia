using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Parking.App
{
    public partial class MainForm : CJia.Parking.Tools.Form1, CJia.Parking.Views.IMainFormView
    {

        /// <summary>
        /// 是否注销
        /// </summary>
        public bool isLogOff = false;

        public MainForm()
        {
            InitializeComponent();
            Init();
            OnInit(null,mainFormArgs);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MainFormPresenter(this);
        }

        Views.MainFormArgs mainFormArgs = new Views.MainFormArgs();

        #region  Tab控件操作
        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="name">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, UserControl userControl)
        {
            DevExpress.XtraTab.XtraTabPage page1 = new DevExpress.XtraTab.XtraTabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            tabMain.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            tabMain.SelectedTabPage = page1;
        }
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        public bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.TabPages[i].Name == PageTitle)
                {
                    tabMain.SelectedTabPage = tabMain.TabPages[i];
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 双击删除选中tabpage  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_DoubleClick(object sender, EventArgs e)
        {
            if (tabMain.SelectedTabPage != null)
            {
                int index = tabMain.SelectedTabPageIndex;
                this.tabMain.SelectedTabPage.Dispose();
                tabMain.SelectedTabPageIndex = index - 1;
            }
        }
        #endregion

        #region 【界面绑定事件】

        // 用户维护
        private void btnUSer_Click(object sender, EventArgs e)
        {
            string pageTitle = "用户维护";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            string pageTitle = "区域维护";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        // 会员类型维护
        private void btnMemType_Click(object sender, EventArgs e)
        {
            string pageTitle = "会员类型维护";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        // 会员管理
        private void btnMemManage_Click(object sender, EventArgs e)
        {
            string pageTitle = "会员管理";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        // 会员缴费
        private void btnPayment_Click(object sender, EventArgs e)
        {
            string pageTitle = "会员缴费";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        // 会员缴费记录
        private void btnQueryPaylog_Click(object sender, EventArgs e)
        {
            string pageTitle = "会员缴费记录";//获得tabpage名称
            this.MenuShowPage(pageTitle);
        }

        // 临时收费设置
        private void btnTemFeeSet_Click(object sender, EventArgs e)
        {
            UI.TemporaryFeeSet editUser = new UI.TemporaryFeeSet();
            Tools.Help.NewBorderForm(editUser);
        }

        // 修改密码
        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            UI.ChangePwdView editUser = new UI.ChangePwdView();
            Tools.Help.NewBorderForm(editUser);
        }

        // 注销
        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (CJia.Parking.Tools.Message.ShowQuery("是否确认注销", CJia.Parking.Tools.Message.Button.YesNo) == CJia.Parking.Tools.Message.Result.Yes)
            {
                Form frm = new Form();
                frm.Text = "登录";
                frm.Width = 410;
                frm.Height = 270;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.StartPosition = FormStartPosition.CenterScreen;
                UI.LoginView loginView = new UI.LoginView();
                frm.Controls.Add(loginView);
                loginView.Dock = DockStyle.Fill;
                frm.ShowDialog();
                if (User.IsLoginSuccess)
                {
                    this.isLogOff = true;
                    this.FindForm().Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                return;
            }
        }

        // 退出系统
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (CJia.Parking.Tools.Message.ShowQuery("是否确认退出系统", CJia.Parking.Tools.Message.Button.YesNo) == CJia.Parking.Tools.Message.Result.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            lblUserName.Text = User.UserData.Rows[0]["user_name"].ToString();
            lblLogTime.Text = User.LoginTime.ToString();
        }

        /// <summary>
        ///根据标题在tabpage中显示出页面
        ///增加新按钮需 1.在该方法的switch中加一个case，case后面的字符为按钮的text属性值
        ///case中new出你要显示的用户控件
        ///2.并且按钮的单击事件绑定到 menubutton_click 方法上
        /// </summary>
        /// <param name="pageTitle">button的text属性字段</param>
        private void MenuShowPage(string pageTitle)
        {
            if (!isExistPage(pageTitle))
            {
                UserControl uc = null;
                switch (pageTitle)
                {
                    case "用户维护":
                        uc = new UI.UserManageView();
                        break;
                    case "区域维护":
                        uc = new UI.AreaManageView();
                        break;
                    case "会员类型维护":
                        uc = new UI.MemberSetView();
                        break;
                    case "会员管理":
                        uc = new UI.MemberView();
                        break;
                    case "会员缴费":
                        uc = new UI.PaymentView();
                        break;
                    case "会员缴费记录":
                        uc = new UI.PaymentRecordView();
                        break;
                    default:
                        break;
                }
                if (uc != null)
                {
                    ShowPage(pageTitle, uc);
                }
            }
        }

        #endregion

        #region 【接口绑定】
        /// <summary>
        /// 判断绑定登录用户权限
        /// </summary>
        /// <param name="dtLoginUserRoles"></param>
        public void ExeLoginUserRoles(DataTable dtLoginUserRoles)
        {
            if (dtLoginUserRoles != null && dtLoginUserRoles.Rows != null && dtLoginUserRoles.Rows.Count > 0)
            {
                for (int i = 0; i < dtLoginUserRoles.Rows.Count; i++)
                {
                    switch (dtLoginUserRoles.Rows[i]["role_id"].ToString())
                    {
                        case "1" : //  查询
                            
                            break;
                    }
                }
            }
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.MainFormArgs> OnInit;
        #endregion
 
    }
}
