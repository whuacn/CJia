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
    public partial class PaymentView : CJia.Parking.Tools.View,CJia.Parking.Views.IPaymentView
    {
        public PaymentView()
        {
            InitializeComponent();
            OnInit(null,null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PaymentPresenter(this);
        }

        Views.PaymentArgs paymentArgs = new Views.PaymentArgs();

        #region 【界面事件】
        
        private void gvwMem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwMem.FocusedRowHandle < 0)
            {
                SetNull();
                return;
            }
            DataRow dr = gvwMem.GetFocusedDataRow();
            paymentArgs.MemId = (long)dr["mem_id"];
            paymentArgs.MemName = dr["mem_name"].ToString();
            OnPaylogFocusedRowChanged(null,paymentArgs);
        }

        private void btnReChange_Click(object sender, EventArgs e)
        {
            if (NullReturn())
            {
                return;
            }
            if (txtStartDate.DateTime < Tools.Help.Sysdate)
            {
                MessageBox.Show("开始时间不能小于当前日期！");
                return;
            }
            paymentArgs.FreeTime = downEdit.Text;
            paymentArgs.PayAmount = GetPayAmount();
            paymentArgs.StartDate = txtStartDate.DateTime;
            paymentArgs.EffectiveDate = txtStartDate.DateTime.AddMonths(int.Parse(downEdit.Text));
            OnReCharge(null,paymentArgs);
            SetNull();
        }

        private void dropMemType_EditValueChanged(object sender, EventArgs e)
        {
            paymentArgs.MemTypeId = (long)dropMemType.EditValue;
            SetPayAmount(sender,e);
        }

        //private void btnRefreshMem_Click(object sender, EventArgs e)
        //{
        //    OnRefreshMem(null,null);
        //}
        #endregion

        #region 【自定义方法】

        /// <summary>
        /// 计算缴费
        /// </summary>
        /// <returns></returns>
        double GetPayAmount()
        {
            DataTable dt = dropMemType.Properties.DataSource as DataTable;
            double unitPrice = Convert.ToDouble(dt.Select(" mem_type_id=" + paymentArgs.MemTypeId + "")[0]["price"]);
            return unitPrice * double.Parse(downEdit.Text);
        }

        /// <summary>
        /// 设置会员金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPayAmount(object sender, EventArgs e)
        {
            if (dropMemType.Text != "" && downEdit.Text != "0")
            {
                txtPayAmount.Text = GetPayAmount().ToString();
            }
            if (downEdit.Text == "0")
            {
                txtPayAmount.Text = "";
            }
        }

        /// <summary>
        /// 保存时为空返回
        /// </summary>
        /// <returns></returns>
        bool NullReturn()
        {
            if (dropMemType.Text == "")
            {
                MessageBox.Show("请选择会员类型！");
                return true;
            }
            if (downEdit.Text == "0")
            {
                MessageBox.Show("请填写停车时长！");
                return true;
            }
            if (txtPayAmount.Text == "")
            {
                MessageBox.Show("缴费金额不能为空！");
                return true;
            }
            if (txtStartDate.Text == "")
            {
                MessageBox.Show("开始日期不能为空！");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 置空
        /// </summary>
        void SetNull()
        {
            dropMemType.Text = "";
            dropMemType.EditValue = "";

            downEdit.Text = "";
            downEdit.Focus();
            txtPayAmount.Text = "";
            txtStartDate.Text = "";
        }
        #endregion

        #region 【接口实现】
        /// <summary>
        /// 绑定界面会员Grid
        /// </summary>
        /// <param name="dtMemType"></param>
        public void ExeGridMember(DataTable dtMember)
        {
            gridMember.DataSource = dtMember;
        }

        /// <summary>
        /// 绑定下拉会员类型
        /// </summary>
        /// <param name="dtMemType"></param>
        public void ExeDropMemType(DataTable dtMemType)
        {
            dropMemType.Properties.ValueMember = "mem_type_id";
            dropMemType.Properties.DisplayMember = "mem_type";
            dropMemType.Properties.DataSource = dtMemType;
        }

        /// <summary>
        /// 绑定会员日志记录
        /// </summary>
        /// <param name="dtMemPaylog"></param>
        public void ExeGridMemPaylog(DataTable dtMemPaylog)
        {
            gridMemPaylog.DataSource = dtMemPaylog;
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.PaymentArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.PaymentArgs> OnReCharge;

        /// <summary>
        /// 会员点击聚焦
        /// </summary>
        public event EventHandler<Views.PaymentArgs> OnPaylogFocusedRowChanged;

        ///// <summary>
        ///// 重新加载会员信息
        ///// </summary>
        //public event EventHandler<Views.PaymentArgs> OnRefreshMem;
        #endregion    
        
        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnReChange_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
