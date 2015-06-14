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
    public partial class PackView : CJia.Health.Tools.View, Views.IPackView
    {
        public PackView()
        {
            InitializeComponent();
            InitView();
            dtStart.DateTime = Sysdate;
            dtEnd.DateTime = Sysdate;
        }
        private DataTable Data;
        private void InitView()
        {
            Data = new DataTable();
            Data.Columns.Add("ID", typeof(string));
            Data.Columns.Add("RECORDNO", typeof(string));
            Data.Columns.Add("IN_HOSPITAL_TIME", typeof(string));
            Data.Columns.Add("PATIENT_NAME", typeof(string));
            Data.Columns.Add("PAT_COMMIT_DATE", typeof(string));
            gcPack.DataSource = Data;
            txtPackName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtRecord.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtRecord.Focus();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.PackViewPresenter(this);
        }
        PackViewArgs args = new PackViewArgs();
        public event EventHandler<PackViewArgs> OnSearchPatient;
        public event EventHandler<PackViewArgs> OnOK;
        public event EventHandler<PackViewArgs> OnPack;
        public void ExeisPack(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("打包/上架成功");
                InitView();
            }
            else
                MessageBox.Show("打包/上架失败");
        }
        public void ExeisOk(DataRow dr)
        {
            Data.Rows.Add(dr.ItemArray);
            gcPack.DataSource = Data;
            txtRecord.Text = string.Empty;
        }
        public void ExeBindData(DataTable data)
        {
            gridPatient.DataSource = data;
        }

        private void btnNoPack_Click(object sender, EventArgs e)
        {
            string start = dtStart.Text.Trim();
            string end = dtEnd.Text.Trim();
            if (start.Length > 0 && end.Length > 0)
            {
                args.Start = dtStart.DateTime;
                args.End = dtEnd.DateTime;
                OnSearchPatient(null, args);
            }
        }

        private void gvPatientInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "PACK_STATUS")
            {
                string look = this.gvPatientInfo.GetDataRow(e.RowHandle)["PACK_STATUS"].ToString();
                if (look == "已打包")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            if (e.RowHandle == this.gvPatientInfo.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(93, 175, 223);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int sInex = rgStatus.SelectedIndex;
            string text = txtRecord.Text.Trim();
            if (text.Length > 0)
            {
                if (sInex == 0)
                {
                    foreach (DataRow dr in Data.Rows)
                    {
                        string record = dr["RECORDNO"].ToString();
                        if (record == text)
                        {
                            return;
                        }
                    }
                    args.RecordNo = text;
                    OnOK(null, args);
                }
                else
                {
                    foreach (DataRow dr in Data.Rows)
                    {
                        string record = dr["RECORDNO"].ToString();
                        if (record == text)
                        {
                            Data.Rows.Remove(dr);
                            break;
                        }
                    }
                    gcPack.DataSource = Data;
                }
            }
            else
                txtRecord.Focus();
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            if (Data.Rows.Count > 0)
            {
                string max = cbNumber.Text;
                if (max.Length > 0)
                {
                    if (int.Parse(max) < Data.Rows.Count)
                    {
                        MessageBox.Show("打包/上架病案数量超过包容量上限值");
                        return;
                    }
                }
                if (txtPackName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("请输入包名称");
                    txtPackName.Focus();
                    return;
                }
                if (Message.ShowQuery("确定打包/上架？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    List<string> listID = new List<string>();
                    foreach (DataRow dr in Data.Rows)
                    {
                        listID.Add(dr["ID"].ToString());
                    }
                    string name = txtPackName.Text.Trim();
                    string address = txtAddress.Text.Trim();
                    string remark = txtRemark.Text.Trim();
                    args.HealthID = listID;
                    args.PackName = name.Length > 25 ? name.Substring(0, 25) : name;
                    args.PackAddress = address.Length > 50 ? address.Substring(0, 50) : address;
                    args.PackRemark = remark.Length > 100 ? remark.Substring(0, 100) : remark;
                    args.isPrintCode = ckCode.Checked;
                    OnPack(null, args);
                }
            }
        }
    }
}
