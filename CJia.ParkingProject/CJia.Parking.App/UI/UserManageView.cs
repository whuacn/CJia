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
    public partial class UserManageView : CJia.Parking.Tools.View,CJia.Parking.Views.IUserManageView
    {
        public UserManageView()
        {
            InitializeComponent();
            OnInit(null,null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.UserManagePresenter(this);
        }

        Views.UserArgs userArgs = new Views.UserArgs();

        #region 【界面事件】

        private void gvwUser_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            Tools.Help.GridViewDrawEmptyForeground(gvwUser, sender, e);
        }
       
        private void gvwUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwUser.FocusedRowHandle < 0)
            {
                SetNullUser();
                return; 
            }
            DataRow dr = gvwUser.GetFocusedDataRow();
            if (dr != null)
            {
                userArgs.Password = "";
                userArgs.UserId = Convert.ToInt64(dr["user_id"]);
                userArgs.OldUserName = dr["user_name"].ToString();

                txtUserNo.Text = dr["user_no"].ToString();
                txtUserName.Text = dr["user_name"].ToString();
                userArgs.UserSaveStatus = "update";
            }
            OnUserFocusedRowChanged(null,userArgs);
        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            if (IsNullReturnUser())
            {
                return;
            }
            userArgs.ListRoleId.Clear();
            for (int i = 0; i < chkRole.Items.Count; i++)
            {
                if (chkRole.Items[i].CheckState == CheckState.Checked)
                {
                    InnerUser uChecked = (InnerUser)(this.chkRole.Items[i].Value);
                    userArgs.ListRoleId.Add(uChecked.GetFieldID());
                }
            }
            if (chkDefaultPwd.CheckState == CheckState.Checked)
            {
                userArgs.Password = "8888";
            }
            userArgs.UserName = txtUserName.Text;
            userArgs.UserNo = txtUserNo.Text;
            OnUserSave(null,userArgs);
            SetNullUser();
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            userArgs.UserSaveStatus = "add";
            userArgs.UserId = -1; // 保存时，如是新增有重名则提示并返回，修改则不处理
            SetNullUser();
        }

        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            if (gvwUser.FocusedRowHandle < 0)
            {
                return;
            }
            OnUserDelete(null,userArgs);
            gvwUser_FocusedRowChanged(null,null);
        }

        private void chkAllRole_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllRole.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < chkRole.Items.Count;i++ )
                {
                    chkRole.Items[i].CheckState = CheckState.Checked;
                }
            }
            if (chkAllRole.CheckState == CheckState.Unchecked)
            {
                for (int i = 0; i < chkRole.Items.Count; i++)
                {
                    chkRole.Items[i].CheckState = CheckState.Unchecked;
                }
            }
        }
               
        #endregion

        #region 【自定义方法】
       
        /// <summary>
        /// 用户输入框为空返回
        /// </summary>
        /// <returns></returns>
        bool IsNullReturnUser()
        {
            //if (this.txtUserName.Text == "")
            //{
            //    MessageBox.Show("用户名称不能为空！");
            //    txtUserName.Focus();
            //    return true;
            //}
            //if (this.txtUserNo.Text == "")
            //{
            //    MessageBox.Show("用户工号不能为空！");
            //    txtUserNo.Focus();
            //    return true;
            //}
            return false;

        }

        /// <summary>
        /// 置空User相关输入框
        /// </summary>
        void SetNullUser()
        {
            this.txtUserName.Text = "";
            this.txtUserNo.Text = "";
            chkDefaultPwd.CheckState = CheckState.Unchecked;
            chkAllRole.CheckState = CheckState.Unchecked;
            for (int i = 0; i < chkRole.Items.Count; i++)
            {
                chkRole.Items[i].CheckState = CheckState.Unchecked;
            }
        }

        ///// <summary>
        ///// 确认密码是否一致
        ///// </summary>
        //void IsSamePassword()
        //{
        //    if (txtPassword.Text != txtPasswordConfirm.Text)
        //    {
        //        MessageBox.Show("两次输入密码不一致！");
        //        txtPassword.Text = "";
        //        txtPassword.Focus();
        //        txtPasswordConfirm.Text = "";
        //        return;
        //    }
        //}
        #endregion

        #region 【接口绑定】

        /// <summary>
        /// 绑定Grid用户
        /// </summary>
        /// <param name="dtUser"></param>
        public void ExeBindGridUser(DataTable dtUser)
        {
            gridUser.DataSource = dtUser;
        }

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="dtRole"></param>
        public void ExeCheckRole(DataTable dtRole)
        {
            chkRole.Items.Clear();
            chkRole.DisplayMember = "role_name";
            chkRole.ValueMember = "role_id";
            foreach (DataRow dr in dtRole.Rows)//dt为数据源：DataTable类型  
            {
                this.chkRole.Items.Add(new InnerUser(dr, "role_id", "role_name"));
            }
        }

        /// <summary>
        /// 设定用户权限选择状态
        /// </summary>
        /// <param name="dtRole"></param>
        public void ExeSetRoleChecked(DataTable dtRole)
        {
            // 全部置为不选状态
            for (int j = 0; j < dtRole.Rows.Count; j++)
            {
                chkRole.Items[j].CheckState = CheckState.Unchecked;
            }

            DataTable dt = userArgs.TableUserRole;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtRole.Rows.Count; j++)
                {
                    if (dtRole.Rows[j]["role_id"].ToString() == dt.Rows[i]["role_id"].ToString())
                    {
                        chkRole.Items[j].CheckState = CheckState.Checked;
                    }
                }
            }
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnInit;
               
        /// <summary>
        /// 保存用户事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnUserSave;

        /// <summary>
        /// 删除用户事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnUserDelete;

        /// <summary>
        /// 点击用户Grid行事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnUserFocusedRowChanged;
        #endregion 

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnUserSave_Click(null, null);
                    return true;
                case Keys.F2:
                    btnUserAdd_Click(null, null);
                    return true;
                case Keys.F6:
                    btnUserDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
