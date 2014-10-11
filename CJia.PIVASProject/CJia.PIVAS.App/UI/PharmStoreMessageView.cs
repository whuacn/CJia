using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.App.UI
{
    public partial class PharmStoreMessageView : Tools.View, Views.IPharmStoreMessageView
    {
        /// <summary>
        /// 第几次冲药id
        /// </summary>
        public int TimeID;
        public PharmStoreMessageView()
        {
            InitializeComponent();
        }
        public PharmStoreMessageView(DataTable data,int timeID)
        {
            InitializeComponent();
            gcPharmStore.DataSource = data;
            TimeID = timeID;
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PharmStoreMessagePresenter(this);
        }
        /// <summary>
        /// 继续冲药参数
        /// </summary>
        Views.PharmStoreMessageArgs pharmStoreMessageArgs = new Views.PharmStoreMessageArgs();
        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        public event EventHandler CloseForm;
        public event EventHandler<Views.PharmStoreMessageArgs> OnGoPharmSend;
        #region 窗体事件
        //关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseForm != null)
                CloseForm(null, null);
        }
        //继续冲药
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (OnGoPharmSend != null)
            {
                pharmStoreMessageArgs.timeID = TimeID;
                OnGoPharmSend(sender, pharmStoreMessageArgs);
            }
        }
        #endregion

    }
}
