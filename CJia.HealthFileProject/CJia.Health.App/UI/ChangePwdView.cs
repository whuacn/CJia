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
    public partial class ChangePwdView : CJia.Health.Tools.View, CJia.Health.Views.IChangePwdView
    {
        CJia.Health.Views.ChangePwdArgs changePwdArgs = new Views.ChangePwdArgs();
        bool OldPwdIsYes = false;

        public ChangePwdView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.ChangePwdPresenter(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            changePwdArgs.OldPwd = txtOldPwd.Text;
            OnCheckOldPwd(null, changePwdArgs);
            if (OldPwdIsYes)
            {
                if (CheckNewPwd(txtNewPwd.Text, txtRepeatNewPwd.Text))
                {
                    OnUpdatePwd(null, changePwdArgs);
                }
            }
            else
            {
                Message.ShowWarning("旧密码输入错误");
                txtOldPwd.Focus();
                txtOldPwd.SelectAll();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private bool CheckNewPwd(string NewPwd, string RepeatNewPwd)
        {
            if (txtNewPwd.Text == "" || txtRepeatNewPwd.Text == "")
            {
                Message.ShowWarning("密码框不能为空");
                if (txtNewPwd.Text == "")
                {
                    txtNewPwd.Focus();
                }
                else
                {
                    if (txtRepeatNewPwd.Text == "")
                    {
                        txtRepeatNewPwd.Focus();
                    }
                }
                return false;
            }
            else
            {
                if (NewPwd != RepeatNewPwd)
                {
                    Message.ShowWarning("新密码不一致");
                    txtNewPwd.Focus();
                    txtNewPwd.SelectAll();
                    return false;
                }
                else
                {
                    changePwdArgs.NewPwd = txtNewPwd.Text;
                    return true;
                }
            }
        }
        
        #region
        public event EventHandler<Views.ChangePwdArgs> OnCheckOldPwd;

        public event EventHandler<Views.ChangePwdArgs> OnUpdatePwd;

        /// <summary>
        /// 判断旧密码是否正确
        /// </summary>
        /// <param name="bo"></param>
        public void ExeCheckOldPwd(bool bo)
        {
            if (!bo)
            {
                OldPwdIsYes = false;
            }
            else
            {
                OldPwdIsYes = true;
            }
        }
        #endregion

        
    }
}
