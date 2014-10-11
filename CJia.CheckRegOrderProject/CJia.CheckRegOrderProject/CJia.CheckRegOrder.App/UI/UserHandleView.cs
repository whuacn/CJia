using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class UserHandleView : CJia.Editors.View, Views.IUserHandleView
    {//CJia.Editors.View
        public UserHandleView()
        {
            InitializeComponent();
        }
        public UserHandleView(DataTable data)
        {
            InitializeComponent();
            ExeBindUser(data);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.UserHandlePresenter(this);
        }
        /// <summary>
        /// 记录用户信息
        /// </summary>
        private DataTable UserData;
        #region IUserHandleView 成员
        public int UserID
        {
            get;
            set;
        }
        public string OldUserNO { get; set; }
        public string UserNO
        {
            get { return txtUserNO.Text.Trim(); }
            set { txtUserNO.Text = value; }
        }
        public string UserName
        {
            get { return txtUserName.Text.Trim(); }
            set { txtUserName.Text = value; }
        }
        public bool IsAdmin
        {
            get { return ckAdmin.Checked; }
            set { ckAdmin.Checked = value; }
        }
        public event EventHandler OnSaveBtn;
        public event EventHandler OnCancel;
        public event EventHandler OnAddUser;
        public void TxtUserNOFocus()
        {
            txtUserNO.Focus();
            txtUserNO.SelectAll();
        }
        public void CloseForm()
        {
            if (OnCancel != null)
            {
                OnCancel(null, null);
            }
        }
        public void ExeBindUser(DataTable data)
        {
            UserID = int.Parse(data.Rows[0]["user_id"].ToString());
            UserNO = data.Rows[0]["user_no"].ToString();
            OldUserNO = data.Rows[0]["user_no"].ToString();
            UserName = data.Rows[0]["user_name"].ToString();
            IsAdmin = bool.Parse(data.Rows[0]["user_type"].ToString());
            UserData = data;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isRightUser()) return;

            if (UserData != null)
            {
                OnSaveBtn(null, null);
            }
            else 
            {
                OnAddUser(null, null);
            }
        }
        /// <summary>
        /// 界面验证
        /// </summary>
        /// <returns></returns>
        bool isRightUser()
        {
            if (UserNO.Length == 0)
            {
                MessageBox.Show("请输入用户工号");
                txtUserNO.Focus();
                return false;
            }
            if (UserName.Length == 0)
            {
                MessageBox.Show("请输入用户名称");
                txtUserName.Focus();
                return false;
            }
            return true;
        }

    }
}
