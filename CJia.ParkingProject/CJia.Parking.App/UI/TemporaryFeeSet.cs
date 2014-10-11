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
    public partial class TemporaryFeeSet : CJia.Parking.Tools.View,CJia.Parking.Views.ITemporaryFeeSetView
    {
        public TemporaryFeeSet()
        {
            InitializeComponent();
            OnInit(null,temFeeSetArgs);
            if (temFeeSetArgs.DataTableTem != null && temFeeSetArgs.DataTableTem.Rows.Count > 0)
            {
                DataRow dr = temFeeSetArgs.DataTableTem.Rows[0];
                txtFreeHour.Text = dr["free_hour"].ToString();
                txtStartHour.Text = dr["free_hour"].ToString();
                txtHourSet.Text = dr["hour_set"].ToString();
                txtHourSetFee.Text = dr["hour_set_fee"].ToString();
                txtUpperHour.Text = dr["upper_hour"].ToString();
                txtEndHour.Text = dr["upper_hour"].ToString();
                txtUpperSetFee.Text = dr["upper_hour_fee"].ToString();
                
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.TemporaryFeeSetPresenter(this);
        }

        Views.TemproaryFeeSetArgs temFeeSetArgs = new Views.TemproaryFeeSetArgs();

        #region 【界面事件】
        private void btnSave_Click(object sender, EventArgs e)
        {
            NullReturn();
            if (Convert.ToInt16(txtStartHour.Text) > Convert.ToInt16(txtEndHour.Text))
            {
                MessageBox.Show("时间设置有误，请修改！");
                return;
            }
            SetValue();
            OnSave(null, temFeeSetArgs);
            this.ParentForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetNull();
        }

        private void txtFreeHour_Leave(object sender, EventArgs e)
        {
            txtStartHour.Text = txtFreeHour.Text;
        }

        private void txtStartHour_Leave(object sender, EventArgs e)
        {
            txtFreeHour.Text = txtStartHour.Text;
        }

        private void txtEndHour_Leave(object sender, EventArgs e)
        {
            txtUpperHour.Text = txtEndHour.Text;
        }

        private void txtUpperHour_Leave(object sender, EventArgs e)
        {
            txtEndHour.Text = txtUpperHour.Text;
        }

        private void Lower_Leave(object sender, EventArgs e)
        {
            if (txtFreeHour.Text != "")
            {
                txtStartHour.Text = txtFreeHour.Text;
                return;
            }
            if (txtStartHour.Text != "")
            {
                txtFreeHour.Text = txtHourSet.Text;
                return;
            }
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 空值返回
        /// </summary>
        /// <returns></returns>
        bool NullReturn()
        {
            if (txtFreeHour.Text == "")
            {
                MessageBox.Show("输入框不能为空！");
                txtFreeHour.Focus();
                return true;
            }
            if (txtHourSet.Text == "")
            {
                MessageBox.Show("输入框不能为空！");
                txtHourSet.Focus();
                return true;
            }
            if (txtHourSetFee.Text == "")
            {
                MessageBox.Show("输入框不能为空！");
                txtHourSetFee.Focus();
                return true;
            }
            if (txtUpperHour.Text == "")
            {
                MessageBox.Show("输入框不能为空！");
                txtUpperHour.Focus();
                return true;
            }
            if (txtUpperSetFee.Text == "")
            {
                MessageBox.Show("输入框不能为空！");
                txtUpperSetFee.Focus();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 赋值
        /// </summary>
        void SetValue()
        {
            temFeeSetArgs.FreeHour = txtFreeHour.Text;
            temFeeSetArgs.HourSet = txtHourSet.Text;
            temFeeSetArgs.HourSetFee = txtHourSetFee.Text;
            temFeeSetArgs.UpperHour = txtUpperHour.Text;
            temFeeSetArgs.UpperHourFee = txtUpperSetFee.Text;
        }

        /// <summary>
        /// 清空
        /// </summary>
        void SetNull()
        {
            txtFreeHour.Text = "";
            txtHourSet.Text = "";
            txtHourSetFee.Text = "";
            txtUpperHour.Text = "";
            txtUpperSetFee.Text = "";
            txtStartHour.Text = "";
            txtEndHour.Text = "";
        }
        #endregion

        #region 【接口实现】
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.TemproaryFeeSetArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.TemproaryFeeSetArgs> OnSave;
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnSave_Click(null, null);
                    return true;
                case Keys.F4:
                    btnCancel_Click(null, null);
                    return true;
                case Keys.F9:
                    btnClear_Click(null,null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
