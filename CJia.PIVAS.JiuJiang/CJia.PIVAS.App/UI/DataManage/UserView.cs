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
    /// 用户维护的UI层
    /// </summary>
    public partial class UserView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IUserView
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public UserView()
        {
            InitializeComponent();
        }

        //重写P层方法
        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.UserPresenter(this);
        }

        //初始化载入数据
        private void Gc_User_Load(object sender, EventArgs e)
        {
            this.OnLoadData(null, null);
        }

        //添加新用户
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UI.DataManage.NewAddUserView addUser = new UI.DataManage.NewAddUserView();
            this.ShowAsWindow("添加新用户", addUser);
            this.OnLoadData(null, null);
        }

        //删除用户
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.Views.DataManage.UserEventArgs userArgs = new Views.DataManage.UserEventArgs();
            if (GridViewUser.FocusedRowHandle>=0)
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("确认是否删除", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    userArgs.CreateBy = User.UserId;
                    userArgs.UserId = long.Parse(GridViewUser.GetFocusedDataRow()["USER_ID"].ToString());
                    this.OnDeleteUser(null, userArgs);
                    this.OnLoadData(null, null);
                }
                {
                    return;
                }
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请选择数据");
            }
        }


        #region【实现接口】
        //初始化载入方法
        public event EventHandler<Views.DataManage.UserEventArgs> OnLoadData;

        //删除用户 把状态改为0
        public event EventHandler<Views.DataManage.UserEventArgs> OnDeleteUser;

        //gridcontrol数据源绑定
        public void ExeDataBind(DataTable dt)
        {
            Gc_User.DataSource = dt;
        }
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    BtnRefresh.Focus();
                    this.OnLoadData(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
