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
    public partial class PharmSendView : Tools.View, Views.IPharmSendView
    {
        public PharmSendView()
        {
            InitializeComponent();
            Load(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PharmSendPresenter(this);
        }
        /// <summary>
        /// 冲药参数
        /// </summary>
        Views.PharmSendArgs pharmSendArgs = new Views.PharmSendArgs();

        #region IPharmSendView成员
        //初始化事件
        public event EventHandler Load;
        //预览瓶贴事件
        public event EventHandler OnPreviewLable;
        //瓶贴详情事件
        public event EventHandler OnDetail;
        //冲药事件
        public event EventHandler<Views.PharmSendArgs> OnPharmSend;
        //绑定冲药次数
        public void ExeGetPharmSendTime(DataTable data)
        {
            object[] image = new object[]
            { 
                CJia.PIVAS.App.Properties.Resources.time1,
                CJia.PIVAS.App.Properties.Resources.time2,
                CJia.PIVAS.App.Properties.Resources.time3,
                CJia.PIVAS.App.Properties.Resources.time4,
                CJia.PIVAS.App.Properties.Resources.time5
            };
            for (int i = 1; i <= data.Rows.Count; i++)
            {
                DevExpress.XtraEditors.SimpleButton btn = new SimpleButton();
                btn.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
                btn.Appearance.Options.UseFont = true;
                btn.Image = (System.Drawing.Image)(image[i - 1]);
                btn.Location = new System.Drawing.Point(5, 77 + 52 * i);
                btn.Size = new System.Drawing.Size(209, 32);
                btn.Text = "第" +CJia.PIVAS.Tools.Helper.Convert(i) + "次冲药";
                btn.Tag = data.Rows[i - 1]["TIME_ID"].ToString();
                btn.Click += btn_Click;
                this.groupControl2.Controls.Add(btn);
            }
        }
        //绑定当天要冲的药
        public void ExeBindTodayLable(DataTable data)
        {
            gcLable.DataSource = data;
            gvLabel.ExpandAllGroups();
        }
        //绑定当天冲药明细
        public void ExeBindTodayLableDetail(DataTable data)
        {
            PharmSendForm pafuc = new PharmSendForm(data);
            pafuc.ShowDialog();
        }
        //绑定库存不足的药品
        public void ExeBindTodayNoPharmStore(DataTable data, int timeID)
        {
            PharmSendForm pafuc = new PharmSendForm(data, timeID);
            pafuc.ShowDialog();
        }
        //判断是否在冲药时间范围内
        public bool ExeIsPharmSend(DataTable data)
        {
            DateTime start = DateTime.Parse(this.Sysdate.ToShortDateString() + " " + data.Rows[0]["START_TIME"].ToString());
            DateTime over = DateTime.Parse(this.Sysdate.ToShortDateString() + " " + data.Rows[0]["OVER_TIME"].ToString());
            DateTime now = this.Sysdate;
            if (start > now || now > over)
            {
                Message.Show("不在操作时间范围内");
                return false;
            }
            return true;
        }
        #endregion

        #region 窗体事件
        //预览瓶贴按钮
        private void btnPreviewLable_Click(object sender, EventArgs e)
        {
            if (OnPreviewLable != null)
                OnPreviewLable(null, null);
        }
        //详情按钮
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (OnDetail != null)
                OnDetail(null, null);
        }
        #endregion

        #region 内部掉用方法
        /// <summary>
        /// 冲药按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton btn = (sender as SimpleButton);
            if (OnPharmSend != null)
            {
                pharmSendArgs.timeID = int.Parse(btn.Tag.ToString());
                OnPharmSend(sender, pharmSendArgs);
                OnPreviewLable(null, null);
            }
        }
        #endregion

    }
}
