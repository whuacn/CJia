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
    public partial class MemberSetView : CJia.Parking.Tools.View,CJia.Parking.Views.IMemberSetView
    {
        public MemberSetView()
        {
            InitializeComponent();
            OnInit(null,null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MemberSetPresenter(this);
        }

        Views.MemSetArgs memSetArgs = new Views.MemSetArgs();

        #region 【界面事件】
        private void gvwMemType_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwMemType.FocusedRowHandle < 0)
            {
                SetNull();
                return;
            }
            DataRow dr = gvwMemType.GetFocusedDataRow();
            if (dr != null)
            {
                txtMemType.Text = dr["mem_type"].ToString();
                txtPrice.Text = dr["price"].ToString();

                memSetArgs.MemTypeSaveStatus = "update";
                memSetArgs.OldMemType = dr["mem_type"].ToString();
                memSetArgs.MemTypeId = Convert.ToInt64(dr["mem_type_id"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsNullReturn())
            {
                return;
            }
            memSetArgs.MemType = txtMemType.Text;
            memSetArgs.Price = int.Parse(txtPrice.Text);
            OnSave(null,memSetArgs);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            memSetArgs.MemTypeId = -1;
            memSetArgs.MemTypeSaveStatus = "add";
            SetNull();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvwMemType.FocusedRowHandle < 0)
            {
                return;
            }
            OnDelete(null,memSetArgs);
            gvwMemType_FocusedRowChanged(null,null);
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 输入框为空返回
        /// </summary>
        /// <returns></returns>
        bool IsNullReturn()
        {
            if (txtMemType.Text == "")
            {
                MessageBox.Show("类型不能为空！");
                return true;
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("收费金额不能为空！");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 置空
        /// </summary>
        void SetNull()
        {
            txtMemType.Text = "";
            txtPrice.Text = "";
        }
        #endregion

        #region 【实现接口】
        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtMemType"></param>
        public void ExeGridMemType(DataTable dtMemType)
        {
            gridMemType.DataSource = dtMemType;
        }
        #endregion

        #region 【接口层事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.MemSetArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.MemSetArgs> OnSave;

        /// <summary>
        /// 删除事件
        /// </summary>
        public event EventHandler<Views.MemSetArgs> OnDelete;
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnSave_Click(null, null);
                    return true;
                case Keys.F2:
                    btnAdd_Click(null, null);
                    return true;
                case Keys.F6:
                    btnDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
