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
    public partial class UserSelectView : CJia.Editors.View, Views.IUserSelectView
    {//CJia.Editors.View
        public UserSelectView()
        {
            InitializeComponent();
            Load(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.UserSelectPresenter(this);
        }
        #region IUserSelectView 程序
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
        public int UserID
        {
            get { return int.Parse(gvUser.GetFocusedDataRow()["user_id"].ToString()); }
        }
        public DataTable UserData { get; set; }
        public event EventHandler OnSelectByNO;
        public event EventHandler OnSelectByName;
        public event EventHandler OnSelectBtn;
        public event EventHandler Load;
        public event EventHandler OnResetPswdBtn;
        public event EventHandler OnEditBtn;
        public event EventHandler OnDelete;
        public void ExeBindUser(DataTable data)
        {
            gcUser.DataSource = data;
        }
        public void ExeShowUserHandle(DataTable data)
        {
            UserHandle uh = new UserHandle(data);
            uh.Text = "编辑用户";
            uh.ShowDialog();
            Load(null, null);
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (UserName != "" || UserNO != "")
            {
                OnSelectBtn(null, null);
                UserName = UserName;
                UserNO = "";
                txtUserName.Focus();
                txtUserName.SelectAll();
            }
            else
            {
                MessageBox.Show("请输入用户名称或者工号");
                UserName = UserName;
                txtUserName.Focus();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (UserName != "")
                {
                    OnSelectByName(null, null);
                    UserName = UserName;
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                }
                else
                {
                    MessageBox.Show("请输入用户名称");
                    UserName = UserName;
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                }
            }
        }

        private void txtUserNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (UserNO != "")
                {
                    OnSelectByNO(null, null);
                    UserNO = UserNO;
                    txtUserNO.Focus();
                    txtUserNO.SelectAll();
                }
                else
                {
                    MessageBox.Show("请输入用户工号");
                    UserNO = UserNO;
                    txtUserNO.Focus();
                    txtUserNO.SelectAll();
                }
            }
        }

        private void btnResetPswd_Click(object sender, EventArgs e)
        {
            if (gvUser.GetFocusedDataRow() != null)
            {
                string userName = gvUser.GetFocusedDataRow()["user_name"].ToString();
                if (Message.ShowQuery("你确定重置【" + userName + "】密码吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    OnResetPswdBtn(null, null);
                    Load(null, null);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvUser.GetFocusedDataRow() != null)
            {
                string userName = gvUser.GetFocusedDataRow()["user_name"].ToString();
                if (Message.ShowQuery("你确定删除【" + userName + "】吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    OnDelete(null, null);
                    Load(null, null);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (gvUser.GetFocusedDataRow() != null)
            {
                OnEditBtn(null, null);
            }
        }

    }
}
