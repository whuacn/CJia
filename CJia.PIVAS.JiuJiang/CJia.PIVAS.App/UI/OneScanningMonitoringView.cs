using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class OneScanningMonitoringView : Tools.View, Views.IOneScanningMonitoringView
    {
        string no = "";
        DataTable user = null;

        public OneScanningMonitoringView(string no)
        {
            InitializeComponent();
            this.no = no;
            this.LoginBtnSizeChanged();
            groupControl1.Text = CJia.PIVAS.Tools.Helper.Convert(int.Parse(no)) + "号操作台";
            this.Initi();
        }

        private void Initi()
        {
            CJia.PIVAS.Views.OneScanningMonitoringEventArgs oneScanningMonitoringEventArgs = new Views.OneScanningMonitoringEventArgs()
            {
                no = this.no
            };
            this.OnInit(null, oneScanningMonitoringEventArgs);
        }

        //重写创建P层的方法
        protected override object CreatePresenter()
        {
            return new Presenters.OneScanningMonitoringPresenter(this);
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.App.UI.LoginScanningView loginScanningView = new LoginScanningView(this.no);
            this.ShowAsWindow(this.no + "号操作台登录", loginScanningView);
            if(loginScanningView.succeed)
            {
                this.user = loginScanningView.userData;
                this.lbName.Text = this.user.Rows[0]["USER_NAME"].ToString();
                this.lbDate.Text = Sysdate.ToString("yyyy/MM/dd HH:mm:ss");
                this.btnOut.Enabled = true;
                this.btnLogin.Enabled = false;
                this.cJiaPanel1.Visible = false;
            }
            else
            {
                this.user = null;
                this.lbName.Text = "";
                this.lbDate.Text = "";
                this.btnOut.Enabled = false;
                this.btnLogin.Enabled = true;
                this.cJiaPanel1.Visible = true;
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.Views.OneScanningMonitoringEventArgs oneScanningMonitoringEventArgs = new Views.OneScanningMonitoringEventArgs()
            {
                userId = user.Rows[0]["USER_ID"].ToString(),
                no = this.no
            };
            this.OnOutLogin(null, oneScanningMonitoringEventArgs);
            this.user = null;
            this.lbName.Text = "";
            this.lbDate.Text = "";
            this.btnOut.Enabled = false;
            this.btnLogin.Enabled = true;
            this.cJiaPanel1.Visible = true;

        }

        private void cJiaPanel1_SizeChanged(object sender, EventArgs e)
        {
            this.LoginBtnSizeChanged();
        }

        public void Scanning(string labelBarId)
        {
            if(this.user == null || this.user.Rows == null || this.user.Rows.Count == 0)
            {
                this.SendLightMes(false);
            }
            else
            {
                CJia.PIVAS.Views.OneScanningMonitoringEventArgs oneScanningMonitoringEventArgs = new Views.OneScanningMonitoringEventArgs()
                {
                    userId = user.Rows[0]["USER_ID"].ToString(),
                    no = this.no,
                    labelBarId = labelBarId
                };
                this.OnScanning(null, oneScanningMonitoringEventArgs);
            }
        }


        #region IOneScanningMonitoringView 成员

        //登录
        public event EventHandler<Views.OneScanningMonitoringEventArgs> OnOutLogin;

        //扫描
        public event EventHandler<Views.OneScanningMonitoringEventArgs> OnScanning;

        //初始化登录信息
        public event EventHandler<Views.OneScanningMonitoringEventArgs> OnInit;



        //扫描返回信息
        public void ExeResurtMes(bool lightMes, string mes)
        {
            this.SendLightMes(lightMes);
            this.addMessage(mes, lightMes);
        }

        //初始化返回事件
        public void ExeInit(DataTable userData)
        {
            if(userData != null && userData.Rows != null && userData.Rows.Count > 0)
            {
                this.user = userData;
                this.lbName.Text = this.user.Rows[0]["USER_NAME"].ToString();
                this.lbDate.Text = this.user.Rows[0]["LOGIN_DATE"].ToString();
                this.btnOut.Enabled = true;
                this.btnLogin.Enabled = false;
                this.cJiaPanel1.Visible = false;
            }
            else
            {
                this.user = null;
                this.lbName.Text = "";
                this.lbDate.Text = "";
                this.btnOut.Enabled = false;
                this.btnLogin.Enabled = true;
                this.cJiaPanel1.Visible = true;
            }
        }

        #endregion


        private void LoginBtnSizeChanged()
        {
            this.btnLogin.Location = new Point((this.cJiaPanel1.Size.Width - 150) / 2, (this.cJiaPanel1.Size.Height - 50) / 2);
        }

        public void addMessage(string mes, bool result)
        {
            foreach(Control control in this.pnMes.Controls)
            {
                control.Location = new Point(control.Location.X, control.Location.Y + 18);
            }
            CJia.Controls.CJiaLabel cJiaLabel = new Controls.CJiaLabel();
            cJiaLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            cJiaLabel.Location = new System.Drawing.Point(3, 3);
            cJiaLabel.Name = "cJiaLabel" + (this.pnMes.Controls.Count + 1);
            cJiaLabel.Text = mes;
            if(result)
            {
                cJiaLabel.ForeColor = Color.Black;
            }
            else
            {
                cJiaLabel.ForeColor = Color.Red;
            }
            this.pnMes.Controls.Add(cJiaLabel);
        }


        /// <summary>
        /// 发送灯信号
        /// </summary>
        /// <param name="mes">true为绿等亮false未红灯</param>
        public void SendLightMes(bool mes)
        {
            //根据this.no 与 mes  确定哪个灯亮
        }

    }
}
