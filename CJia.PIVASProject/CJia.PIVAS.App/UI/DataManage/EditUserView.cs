using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 修改个人信息UI层
    /// </summary>
    public partial class EditUserView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IEditUserView
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public EditUserView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 带参数的构造方法   初始化绑定数据
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public EditUserView(string userName)
        {
            InitializeComponent();
            TxtUserName.Text = userName;
            TxtOldPwd.Focus();
        }


        /// <summary>
        /// 旧密码是否正确
        /// </summary>
        private bool IsOldPwdOk;

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.EditUserPresenter(this);
        }


        //确认修改
        private void BtnUsre_Click(object sender, EventArgs e)
        {
            this.EditUser();
        }

        //修改方法
        private void EditUser()
        {
            CJia.PIVAS.Views.DataManage.EditUsereventArgs editargs = new Views.DataManage.EditUsereventArgs();
            editargs.OldPwd = CJia.PIVAS.Common.EncryptString(TxtOldPwd.Text);
            editargs.UserId = User.UserId;
            this.OnCheckPwd(null, editargs);
            //如果旧密码不正确
            if (!IsOldPwdOk)
            {
                CJia.PIVAS.Tools.Message.Show("旧密码错误,请重新输入");
                TxtOldPwd.SelectAll();
                TxtOldPwd.Focus();
                return;
            }

            if (TxtNewPwd.Text == "")
            {
                CJia.PIVAS.Tools.Message.Show("新密码不能为空");
                TxtNewPwd.Focus();
                return;
            }

            if (TxtSurePwd.Text == "")
            {
                CJia.PIVAS.Tools.Message.Show("确认密码不能为空");
                TxtSurePwd.Focus();
                return;
            }
            
            if (TxtNewPwd.Text != TxtSurePwd.Text)
            {
                CJia.PIVAS.Tools.Message.Show("您输入的两次密码不一致");
                TxtNewPwd.Focus();
                TxtNewPwd.SelectAll();
                return;
            }
            else
            {
                if (TxtSurePwd.Text.Length > 6)
                {
                    CJia.PIVAS.Tools.Message.Show("密码长度不能大于6位");
                    TxtNewPwd.Focus();
                    TxtNewPwd.SelectAll();
                    return;
                }
                else
                {
                    editargs.NewPwd = CJia.PIVAS.Common.EncryptString(TxtSurePwd.Text);
                }
            }
            editargs.UserId = User.UserId;

            if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认修改", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
            {
                this.OnUpdateUser(null, editargs);
            }
            else
            {
                return;
            }
        }

        //取消修改  关闭窗体
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #region【实现接口】

        //修改用户信息
        public event EventHandler<Views.DataManage.EditUsereventArgs> OnUpdateUser;

        //判断修改密码是输入的旧密码是否正确
        public event EventHandler<Views.DataManage.EditUsereventArgs> OnCheckPwd;

        /// <summary>
        /// 判断修改密码是旧密码是否正确
        /// </summary>
        /// <param name="isPwdOk"></param>
        public void ExeIsPwdOk(bool isPwdOk)
        {
            IsOldPwdOk = isPwdOk;
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    BtnUsre.Focus();
                    this.EditUser();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
