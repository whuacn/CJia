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
    public partial class AddUserView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IAddUserView
    {
        /// <summary>
        /// 记录工号是否已经存在信息
        /// </summary>
        private bool isUserNoRepeat = false;

        public AddUserView()
        {
            InitializeComponent();
        }

        CJia.PIVAS.Views.DataManage.addUsereventArgs addUserArgs = new Views.DataManage.addUsereventArgs();

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.AddUserPresenter(this);
        }

        ////鼠标在取消按钮区域
        //private void BtnCancle_MouseEnter(object sender, EventArgs e)
        //{
        //    IsCalcleClick = true;
        //}

        ////鼠标离开取消按钮区域
        //private void BtnCancle_MouseLeave(object sender, EventArgs e)
        //{
        //    IsCalcleClick = false;
        //}

        ////判断工号是否有重复
        //private void TxtUserNo_Leave(object sender, EventArgs e)
        //{
        //    if (IsCalcleClick == false)
        //    {
        //        if (TxtUserNo.Text != "" && TxtUserNo.Text.Length <= 20)
        //        {
        //            addUserArgs.UserNo = TxtUserNo.Text;
        //            this.OnLeave(null, addUserArgs);
        //        }
        //        else
        //        {
        //            CJia.PIVAS.Tools.Message.Show("工号不能为空且不能长于20位");
        //            TxtUserNo.Focus();
        //            TxtUserNo.SelectAll();
        //            return;
        //        }
        //    }
        //}

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
            addUserArgs.UserNo = TxtUserNo.Text;
            if (TxtUserNo.Text != "" && TxtUserNo.Text.Length <= 20)
            {
                this.OnLeave(null, addUserArgs);
                if (isUserNoRepeat)
                {
                    this.OnLeave(null, addUserArgs);
                    CJia.PIVAS.Tools.Message.Show("此工号已存在");
                    TxtUserNo.Focus();
                    TxtUserNo.SelectAll();
                    isUserNoRepeat = false;
                    return;
                }
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("工号不能为空且不能长于20位");
                TxtUserNo.Focus();
                TxtUserNo.SelectAll();
                return;
            }

            if (TxtName.Text != "" && TxtName.Text.Length < 20)
            {
                addUserArgs.UserName = TxtName.Text;
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请填写用户名称，并且长度不能大于20位");
                TxtName.Focus();
                TxtName.SelectAll();
                return;
            }
            if (TxtNewPwd.Text != "" && TxtNewPwd.Text.Length <= 6)
            {
                if (TxtSurePwd.Text != "" && TxtSurePwd.Text.Length <= 6)
                {
                    if (TxtNewPwd.Text == TxtSurePwd.Text)
                    {
                        
                        addUserArgs.Pwd = CJia.PIVAS.Common.EncryptString(TxtNewPwd.Text);
                        addUserArgs.UserId = User.UserId;
                        addUserArgs.DeptId = "1000000000";
                        addUserArgs.DeptName = "静脉药物配置中心";
                        this.OnaddUser(null, addUserArgs);
                    }
                    else
                    {
                        CJia.PIVAS.Tools.Message.Show("密码必须一致！");
                        TxtNewPwd.Focus();
                        TxtNewPwd.SelectAll();
                        return;

                    }
                }
                else
                {
                    CJia.PIVAS.Tools.Message.Show("请填写确认密码，并且长度不能大于6位");
                    TxtSurePwd.Focus();
                    TxtSurePwd.SelectAll();
                    return;
                }
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请填写密码，并且长度不能大于6位");
                TxtNewPwd.Focus();
                TxtNewPwd.SelectAll();
                return;
            }
        }

        #region【实现接口】
        //工号输入框失去焦点 判断当前工号是否有重复
        public new event EventHandler<Views.DataManage.addUsereventArgs> OnLeave;

        //添加用户
        public event EventHandler<Views.DataManage.addUsereventArgs> OnaddUser;

       //获得工号是否已经存在信息
        public void ExeGetFocus()
        {
            isUserNoRepeat = true;
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
            switch (keyData)
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

    }
}
