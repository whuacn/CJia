using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CJia.PEIS.App.UI
{
    public partial class AdminHandleView : CJia.PEIS.Tools.View, CJia.PEIS.Views.IAdminHandleView
    {
        //保存图片文本框提示信息
        private string UserImagePointText;
        private string UserSignPointText;
        private string SearchPointText;
        private bool isAddNewUser = false;

        public AdminHandleView()
        {
            InitializeComponent();
            Init();
            UserImagePointText = ofUserImage.Text;
            UserSignPointText = ofUserSign.Text;
            SearchPointText = txtSearchUsers.Text;
        }
        protected override object CreatePresenter()
        {
            return new Presenters.AdminHandlePresenter(this);
        }

        /// <summary>
        /// 操作员管理参数
        /// </summary>
        CJia.PEIS.Views.AdminHandleEventArgs adminHandleEventArgs = new Views.AdminHandleEventArgs();

        #region IAdminHandleView成员
        //初始化事件
        public event EventHandler<Views.AdminHandleEventArgs> OnLoad;
        //删除用户事件
        public event EventHandler<Views.AdminHandleEventArgs> OnDelete;
        //保存与修改事件
        public event EventHandler<Views.AdminHandleEventArgs> OnSave;
        //重置密码事件
        public event EventHandler<Views.AdminHandleEventArgs> OnResetPassword;
        //用户数据网格点击事件
        public event EventHandler<Views.AdminHandleEventArgs> OnGridClick;
        // 是否显示停用用户事件
        public event EventHandler<Views.AdminHandleEventArgs> OnCheck;
        //搜索框按钮点击事件
        public event EventHandler<Views.AdminHandleEventArgs> OnBtnSearchClick;
        //初始化
        public void ExeInitialize(DataTable genderData, DataTable userData, DataTable userStausData)
        {
            cbGender.Properties.DataSource = genderData;
            cbGender.Properties.DisplayMember = "code_name";
            cbGender.Properties.ValueMember = "code_id";
            cbGender.EditValue = genderData.Rows[0]["code_id"].ToString();
            cbUserState.Properties.DataSource = userStausData;
            cbUserState.Properties.DisplayMember = "code_name";
            cbUserState.Properties.ValueMember = "code_id";
            cbUserState.EditValue = userStausData.Rows[0]["code_id"].ToString();
            cJiaGrid.DataSource = userData;
        }
        //绑定用户信息
        public void ExeBindUserInfo(DataTable data)
        {
            BindUserInfo(data);
        }
        //绑定所有用户
        public void ExeBindAllUser(DataTable data)
        {
            cJiaGrid.DataSource = data;
        }
        //工号输入框获得焦点
        public void ExeTxtUserNOFocus()
        {
            txtUserNO.Focus();
            txtUserNO.SelectAll();
        }
        #endregion

        #region 界面事件
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isRightUser()) return;
            if (OnSave != null)
            {
                OnSave(sender, GetUserArgs());
                Init();
                Reset();
            }
        }
        //新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddNewUser = true;//新增用户
            Reset();
            txtUserNO.Focus();
            btnDelete.Enabled = false;
            btnResetPwd.Enabled = false;
        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cjiaGridView.GetFocusedDataRow() != null && OnDelete != null && !isAddNewUser)
            {
                adminHandleEventArgs.UserID = int.Parse(cjiaGridView.GetFocusedDataRow()["user_id"].ToString());
                string userNO = cjiaGridView.GetFocusedDataRow()["user_no"].ToString();
                string userName = cjiaGridView.GetFocusedDataRow()["user_name"].ToString();
                if (Message.ShowQuery("您确定停用【" + userNO + "|" + userName + "】吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    OnDelete(sender, adminHandleEventArgs);
                    Init();
                    Reset();
                }
            }
        }
        //重置密码
        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            if (OnResetPassword != null && cjiaGridView.GetFocusedDataRow() != null && !isAddNewUser)
            {
                adminHandleEventArgs.UserID = int.Parse(cjiaGridView.GetFocusedDataRow()["user_id"].ToString());
                adminHandleEventArgs.UserNo = cjiaGridView.GetFocusedDataRow()["user_no"].ToString();
                adminHandleEventArgs.UserName = cjiaGridView.GetFocusedDataRow()["user_name"].ToString();
                OnResetPassword(sender, adminHandleEventArgs);
            }
        }
        //用户签名图片改变
        private void ofUserSign_TextChanged(object sender, EventArgs e)
        {
            if (ofUserSign.Text == UserSignPointText) return;
            isRightPicture(imgSign, ofUserSign);
        }
        //用户头像改变
        private void ofUserImage_TextChanged(object sender, EventArgs e)
        {
            if (ofUserImage.Text == UserImagePointText) return;
            isRightPicture(imgUser, ofUserImage);
        }
        //点击grid
        private void cJiaGrid_Click(object sender, EventArgs e)
        {
            isAddNewUser = false;
            btnDelete.Enabled = true;
            btnResetPwd.Enabled = true;
            if (cjiaGridView.GetFocusedDataRow() != null && OnGridClick != null)
            {
                adminHandleEventArgs.UserID = int.Parse(cjiaGridView.GetFocusedDataRow()["user_id"].ToString());
                OnGridClick(sender, adminHandleEventArgs);
            }
        }
        //加强显示停用用户
        private void cjiaGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (cjiaGridView.GetRowCellValue(e.RowHandle, gridColumn6).ToString() == "停用")
            {

                e.Appearance.ForeColor = Color.DarkGray;
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Strikeout);
            }
        }
        //是否显示停用用户
        private void ckNoUse_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }
        //搜索框按钮点击
        private void txtSearchUsers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Search();
        }
        //岗位设置
        private void btnPostSet_Click(object sender, EventArgs e)
        {
            UI.PostSetView postSetView = new PostSetView();
            CJia.PEIS.Tools.Help.NewBorderForm(postSetView);
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            if (OnLoad != null)
            {
                adminHandleEventArgs.isShowNoUse = ckNoUse.Checked;
                OnLoad(null, adminHandleEventArgs);
            }
        }
        /// <summary>
        /// 界面校验
        /// </summary>
        /// <returns></returns>
        bool isRightUser()
        {
            if (txtUserNO.Text.Length == 0)
            {
                MessageBox.Show("工号不能为空");
                txtUserNO.Focus();
                return false;
            }
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("姓名不能为空");
                txtUserName.Focus();
                return false;
            }
            if (txtTelePhone.Text.Length == 0)
            {
                MessageBox.Show("联系电话不能为空");
                txtUserNO.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断图片格式是否正确
        /// </summary>
        /// <param name="image"></param>
        /// <param name="file"></param>
        bool isRightPicture(CJia.Controls.CJiaPicture image, CJia.Controls.CJiaOpenFile file)
        {
            try
            {
                image.Image = Image.FromFile(file.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                image.Image = null;
                return false;
            }
        }
        /// <summary>
        /// 获得用户基本信息参数
        /// </summary>
        /// <returns></returns>
        CJia.PEIS.Views.AdminHandleEventArgs GetUserArgs()
        {
            CJia.PEIS.Views.AdminHandleEventArgs args = new Views.AdminHandleEventArgs();
            if (cjiaGridView.GetFocusedDataRow() != null && !isAddNewUser)//修改用户
            {
                args.UserID = int.Parse(cjiaGridView.GetFocusedDataRow()["user_id"].ToString());
                args.OldUserNo = cjiaGridView.GetFocusedDataRow()["user_no"].ToString();
            }
            args.UserNo = txtUserNO.Text;
            args.UserName = txtUserName.Text;
            args.UserPhone = txtTelePhone.Text;
            args.UserGender = int.Parse(cbGender.EditValue.ToString());
            args.UserWorkUnit = txtWorkUnit.Text;
            args.UserStatus = int.Parse(cbUserState.EditValue.ToString());
            if (imgUser.Image != null && ofUserImage.Text != UserImagePointText)
            {
                args.UserImage = CJia.PEIS.Tools.Help.GetBytesByFilePath(ofUserImage.Text);
            }
            else if (imgUser.Image == null)
            {
                string rootPath = Application.StartupPath;
                string defaultPath = rootPath.Substring(0, rootPath.Length - 10) + "\\Resources\\defaultUserImage.png";
                args.UserImage = CJia.PEIS.Tools.Help.GetBytesByFilePath(defaultPath);
            }
            if (imgSign.Image != null && ofUserSign.Text != UserSignPointText)
            {
                args.UserSignImage = CJia.PEIS.Tools.Help.GetBytesByFilePath(ofUserSign.Text);
            }
            args.UserNameSpell = CJia.Controls.CJiaSpellEditor.ToChString(txtUserName.Text).ToUpper();
            return args;
        }
        /// <summary>
        /// 绑定用户信息
        /// </summary>
        /// <param name="data"></param>
        void BindUserInfo(DataTable data)
        {
            txtUserNO.Text = data.Rows[0]["user_no"].ToString();
            txtUserName.Text = data.Rows[0]["user_name"].ToString();
            txtTelePhone.Text = data.Rows[0]["user_phone"].ToString();
            txtWorkUnit.Text = data.Rows[0]["user_workunit"].ToString();
            cbGender.EditValue = int.Parse(data.Rows[0]["user_gender"].ToString());
            cbUserState.EditValue = int.Parse(data.Rows[0]["status"].ToString());
            if (data.Rows[0]["user_image"] != DBNull.Value)
                imgUser.Image = CJia.PEIS.Tools.Help.GetImageByBytes((byte[])data.Rows[0]["user_image"]);
            else
                imgUser.Image = null;
            if (data.Rows[0]["user_sign"] != DBNull.Value)
                imgSign.Image = CJia.PEIS.Tools.Help.GetImageByBytes((byte[])data.Rows[0]["user_sign"]);
            else
                imgSign.Image = null;
        }
        /// <summary>
        /// 重置
        /// </summary>
        void Reset()
        {
            adminHandleEventArgs = new Views.AdminHandleEventArgs();
            txtUserNO.Text = "";
            txtUserName.Text = "";
            txtTelePhone.Text = "";
            txtWorkUnit.Text = "";
            ofUserImage.Text = UserImagePointText;
            imgUser.Image = null;
            ofUserSign.Text = UserSignPointText;
            imgSign.Image = null;
        }
        /// <summary>
        /// 搜索
        /// </summary>
        void Search()
        {
            if (OnBtnSearchClick != null)
            {
                adminHandleEventArgs.isShowNoUse = ckNoUse.Checked;
                if (txtSearchUsers.Text != SearchPointText)
                    adminHandleEventArgs.Keys = txtSearchUsers.Text;
                else adminHandleEventArgs.Keys = "";
                OnBtnSearchClick(null, adminHandleEventArgs);
            }
        }
        #endregion

    }
}
