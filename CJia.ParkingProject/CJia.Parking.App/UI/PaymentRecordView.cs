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
    public partial class PaymentRecordView : CJia.Parking.Tools.View,CJia.Parking.Views.IPaymentRecordView
    {
        public PaymentRecordView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PaymentRecordPresenter(this);
        }

        Views.PaymentRecordArgs payRecordArgs = new Views.PaymentRecordArgs();

        #region 【界面事件】
        // 查询 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (NullReturn())
            {
                return;
            }
            if ((txtStartDate.Text == "" && txtEndDate.Text != "") || (txtStartDate.Text != "" && txtEndDate.Text == ""))
            {
                MessageBox.Show("请把起止时间填写完整！");
                return;
            }
            if (txtStartDate.DateTime > txtEndDate.DateTime)
            {
                MessageBox.Show("开始时间不得小于结束时间！");
                return;
            }
            SetValue();
            OnSearch(null,payRecordArgs);
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 为空返回，不查询
        /// </summary>
        /// <returns></returns>
        bool NullReturn()
        {
            if(txtStartDate.Text == "" && txtEndDate.Text == "" && txtMemInfo.Text == "" && txtPlateNo.Text == "" && txtPayDate.Text == "")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 赋值（查询条件）
        /// </summary>
        void SetValue()
        {
            payRecordArgs.StartDate = txtStartDate.DateTime;
            payRecordArgs.EndDate = DateTime.Parse(txtEndDate.DateTime.ToShortDateString() + " 23:59:59");
            payRecordArgs.MemInfo = txtMemInfo.Text;
            payRecordArgs.PlateNo = txtPlateNo.Text;
            payRecordArgs.PayDate = DateTime.Parse(txtPayDate.DateTime.ToShortDateString()) ;
        }
        #endregion

        #region 【接口实现】
        /// <summary>
        /// 绑定Grid会员缴费日志表
        /// </summary>
        /// <param name="dtMemPaylog"></param>
        public void ExeGridMemPaylog(DataTable dtMemPaylog)
        {
            gridMemPaylog.DataSource = dtMemPaylog;
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.PaymentRecordArgs> OnSearch;
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnSearch_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
