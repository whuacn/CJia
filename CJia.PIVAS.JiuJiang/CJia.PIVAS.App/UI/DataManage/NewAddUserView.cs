using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Cryptography;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 添加用户UI层
    /// </summary>
    public partial class NewAddUserView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.INewAddUserView
    {
        /// <summary>
        /// 记录工号是否已经存在信息
        /// </summary>
        private bool isUserNoRepeat = false;

        public NewAddUserView()
        {
            InitializeComponent();
        }

        CJia.PIVAS.Views.DataManage.NewaddUsereventArgs addUserArgs = new Views.DataManage.NewaddUsereventArgs();

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.AddNewUserPresenter(this);
        }

        //确认添加用户
        private void BtnUsre_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        private void AddUser()
        {
            addUserArgs.UserNo = TxtUserNo.Text.ToUpper();
            if(TxtUserNo.Text.Trim() != "")
            {
                this.OnLeave(null, addUserArgs);
                if(isUserNoRepeat)
                {
                    if(TxtNewPwd.Text.Trim() != "")
                    {
                        if(TxtSurePwd.Text.Trim() != "")
                        {
                            if(TxtNewPwd.Text == TxtSurePwd.Text)
                            {
                                addUserArgs.UserNo = this.TxtUserNo.Text.Trim();
                                addUserArgs.Pwd = CJia.PIVAS.Common.EncryptString(TxtNewPwd.Text.Trim());
                                addUserArgs.IsAdmin = this.cbAdmin.Checked ? "1" : "0";
                                addUserArgs.UserId = User.UserId;
                                if(this.rbPharm.Checked)
                                {
                                    addUserArgs.role = "1";
                                }
                                if(this.rbJDPharm.Checked)
                                {
                                    addUserArgs.role = "2";
                                }
                                if(this.tbHS.Checked)
                                {
                                    addUserArgs.role = "0";
                                }
                                this.OnaddUser(null, addUserArgs);
                            }
                            else
                            {
                                CJia.PIVAS.Tools.Message.Show("密码与重复密码不相同");
                            }
                        }
                        else
                        {
                            CJia.PIVAS.Tools.Message.Show("重复密码不能为空");

                        }
                    }
                    else
                    {
                        CJia.PIVAS.Tools.Message.Show("密码不能为空");
                    }
                }
                else
                {
                    CJia.PIVAS.Tools.Message.Show("此HIS工号不存在或已经注册");
                }
            }
        }

        #region【实现接口】
        //工号输入框失去焦点 判断当前工号是否有重复
        public new event EventHandler<Views.DataManage.NewaddUsereventArgs> OnLeave;

        //添加用户
        public event EventHandler<Views.DataManage.NewaddUsereventArgs> OnaddUser;

        //获得工号是否已经存在信息
        public void ExeGetFocus(bool have)
        {
            isUserNoRepeat = have;
        }

        //取消事件
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Enter:
                    BtnUsre.Focus();
                    this.AddUser();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(!this.rbPharm.Checked)
            {
                this.cbAdmin.Enabled = false;
                this.cbAdmin.Checked = false;
            }
            else
            {
                this.cbAdmin.Enabled = true;
            }
        }

    }
}
