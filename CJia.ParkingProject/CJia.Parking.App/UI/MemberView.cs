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
    public partial class MemberView : CJia.Parking.Tools.View,CJia.Parking.Views.IMemberView
    {
        public MemberView()
        {
            InitializeComponent();
            OnInit(null,null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MemberPresenter(this);
        }

        Views.MemberArgs memberArgs = new Views.MemberArgs();

        #region 【界面事件】

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwMem.FocusedRowHandle < 0)
            {
                SetNull();
                return;
            }
            DataRow dr = gvwMem.GetFocusedDataRow();
            if (dr != null)
            {
                txtMemNo.Text = dr["mem_no"].ToString();
                txtMemName.Text = dr["mem_name"].ToString();
                txtPlateNo.Text = dr["plate_no"].ToString();

                memberArgs.MemSaveStatus = "update";
                memberArgs.MemId = (long)dr["mem_id"];
                memberArgs.OldMemName = dr["mem_name"].ToString();
                memberArgs.OldPlateNo = dr["plate_no"].ToString();
            }
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NullReturn())
            {
                return;
            }
            memberArgs.MemNo = txtMemNo.Text;
            memberArgs.MemName = txtMemName.Text;
            memberArgs.PlateNo = txtPlateNo.Text;
            OnSave(null,memberArgs);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            memberArgs.MemId = -1;
            memberArgs.MemSaveStatus = "add";
            SetNull();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvwMem.FocusedRowHandle < 0)
            {
                return;
            }
            OnDelete(null,memberArgs);
            gridView1_FocusedRowChanged(null,null);
        }
        #endregion

        #region【实现接口】

        /// <summary>
        /// 绑定会员Grid
        /// </summary>
        /// <param name="dtMember"></param>
        public void ExeGridMember(DataTable dtMember)
        {
            gridMem.DataSource = dtMember;
        }
        #endregion

        #region【自定义方法】

        /// <summary>
        /// 空值返回
        /// </summary>
        /// <returns></returns>
        bool NullReturn()
        {
            if (txtMemNo.Text == "")
            {
                MessageBox.Show("会员编号不能为空！");
                txtMemNo.Focus();
                return true;
            }
            if (txtMemName.Text == "")
            {
                MessageBox.Show("会员姓名不能为空！");
                txtMemName.Focus();
                return true;
            }
            if (txtPlateNo.Text == "")
            {
                MessageBox.Show("车牌号不能为空！");
                txtPlateNo.Focus();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 置空
        /// </summary>
        void SetNull()
        {
            txtMemNo.Text = "";
            txtMemName.Text = "";
            txtPlateNo.Text = "";
            txtMemNo.Focus();
        }
        #endregion

        #region【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.MemberArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.MemberArgs> OnSave;

        /// <summary>
        /// 删除事件
        /// </summary>
        public event EventHandler<Views.MemberArgs> OnDelete;
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
