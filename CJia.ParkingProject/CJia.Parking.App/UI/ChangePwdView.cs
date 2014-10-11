using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Parking.App.UI
{
    public partial class ChangePwdView : CJia.Parking.Tools.View,CJia.Parking.Views.IChangePwdView
    {
        public ChangePwdView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ChangePwdPresenter(this);
        }

        Views.ChangePwdArgs changeArgs = new Views.ChangePwdArgs();

        #region 【界面事件】
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtOldPwd.Text == User.UserData.Rows[0]["user_pwd"].ToString())
            {
                if (txtNewPwd.Text != txtConfirmPwd.Text)
                {
                    MessageBox.Show("新输入密码不一致！");
                    return;
                }
                else
                {
                    changeArgs.NewPassword = txtNewPwd.Text;
                    OnSavePwd(null,changeArgs);
                    this.ParentForm.Close();
                }
            }
            else
            {
                MessageBox.Show("原密码输入错误！");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion

        #region 【自定义方法】

        #endregion

        #region 【实现接口】

        #endregion

        #region 【接口事件】
        /// <summary>
        /// 保存更改密码
        /// </summary>
        public event EventHandler<Views.ChangePwdArgs> OnSavePwd;
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnOk_Click(null, null);
                    return true;
                case Keys.F4:
                    btnCancel_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
