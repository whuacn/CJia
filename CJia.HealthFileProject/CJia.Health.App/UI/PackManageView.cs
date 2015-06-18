using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Views;

namespace CJia.Health.App.UI
{
    public partial class PackManageView : CJia.Health.Tools.View, Views.IPackManageView
    {
        public PackManageView()
        {
            InitializeComponent();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PackManageViewPresenter(this);
        }
        PackManageViewArgs args = new PackManageViewArgs();
        public event EventHandler<PackManageViewArgs> OnSearchPat;
        public event EventHandler<PackManageViewArgs> OnAndInPack;
        public event EventHandler<PackManageViewArgs> OnPrint;
        public event EventHandler<PackManageViewArgs> OnOut;
        public event EventHandler<PackManageViewArgs> OnDeletePack;
        public event EventHandler<PackManageViewArgs> OnSearchPack;
        public void ExeBindPack(DataTable data)
        {
            gcPack.DataSource = data;
        }
        public void ExeIsDeletePack(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("解包成功");
                gcPat.DataSource = null;
            }
        }
        public void ExeIsOut(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("出包成功");
                gvPat.DeleteRow(gvPat.FocusedRowHandle);
            }
        }
        public void ExeIsAndInPack(DataRow dr)
        {
            DataRow focusDr = gvPat.GetFocusedDataRow();
            DataTable data = gcPat.DataSource as DataTable;
            DataRow nr = data.NewRow();
            nr["ID"] = dr["ID"].ToString();
            nr["PATIENT_NAME"] = dr["PATIENT_NAME"].ToString();
            nr["RECORDNO"] = dr["RECORDNO"].ToString();
            nr["IN_HOSPITAL_TIME"] = dr["IN_HOSPITAL_TIME"].ToString();
            nr["PACK_CODE"] = focusDr["PACK_CODE"].ToString();
            nr["PACK_NAME"] = focusDr["PACK_NAME"].ToString();
            nr["PACK_ID"] = focusDr["PACK_ID"].ToString();
            data.Rows.Add(nr);
            gcPat.DataSource = data;
            txtRecord.Text = string.Empty;
        }
        public void ExeBindPat(DataTable data)
        {
            gcPat.DataSource = data;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            args.PackCode = txtCode.Text.Trim();
            args.PackName = txtName.Text.Trim();
            OnSearchPat(null, args);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            DataRow dr = gvPat.GetFocusedDataRow();
            string recordNO = txtRecord.Text.Trim();
            if (recordNO.Length > 0)
            {
                if (dr != null)
                {
                    args.PackID = dr["PACK_ID"].ToString();
                    args.RecordNO = recordNO;
                    OnAndInPack(null, args);
                }
                else
                    MessageBox.Show("请先查询某个包");
            }
            else
                txtRecord.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataRow dr = gvPat.GetFocusedDataRow();
            if (dr != null)
            {
                args.PackCode = dr["PACK_CODE"].ToString();
                args.PackName = dr["PACK_NAME"].ToString();
                OnPrint(null, args);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DataRow dr = gvPat.GetFocusedDataRow();
            if (dr != null)
            {
                if (Message.ShowQuery("确定选择出包？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    args.PackID = dr["PACK_ID"].ToString();
                    args.HealthID = dr["ID"].ToString();
                    OnOut(null, args);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = gvPat.GetFocusedDataRow();
            if (dr != null)
            {
                if (Message.ShowQuery("确定解包？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    args.PackID = dr["PACK_ID"].ToString();
                    OnDeletePack(null, args);
                }
            }
        }

        private void btnSearchPack_Click(object sender, EventArgs e)
        {
            args.Start = dtStart.DateTime;
            args.End = dtEnd.DateTime;
            args.PackAddress = txtAddress.Text.Trim();
            args.PatCode = txtPatCode.Text.Trim();
            args.PatName = txtPatName.Text.Trim();
            args.PackCode = txtPackCode.Text.Trim();
            args.PackName = txtPackName.Text.Trim();
            OnSearchPack(null, args);
        }

        private void cJiaButton1_Click(object sender, EventArgs e)
        {
            dtStart.DateTime = DateTime.MinValue;
            dtStart.Text = string.Empty;
            dtEnd.DateTime = DateTime.MinValue;
            dtEnd.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPatCode.Text = string.Empty;
            txtPatName.Text = string.Empty;
            txtPackCode.Text = string.Empty;
            txtPackName.Text = string.Empty;
        }
    }
}
