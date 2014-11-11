namespace HealthFileBagPrint
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Windows.Forms;

    public class HealthFileSearch : Form
    {
        private SimpleButton btnPrint;
        private SimpleButton btnSearch;
        private System.Windows.Forms.ComboBox CbUser;
        private CheckEdit checkEdit1;
        private IContainer components = null;
        private DateEdit dateEdit1;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn8;
        private GridControl gridFile;
        private GridView gridView1;
        private RepositoryItemCheckEdit ischecked;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private PanelControl panelControl1;
        private CheckEdit TimeCheck;
        private TextEdit txtFmrdid;

        public HealthFileSearch()
        {
            this.InitializeComponent();
            this.dateEdit1.EditValue = DateTime.Now;
            this.LoadData();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                string sql = "SELECT V.FMRDID, V.FNAME, T.FDESC, V.FICD_D, V.FODATE, V.FUDATE, TUSER.FDESC FRECORD\r\n                              FROM VTMRDDEPUB001 V, TOFFIM T, TUSERM TUSER \r\n                             WHERE v.FOOFFI = T.FOFFN\r\n                               AND V.FUSER=TUSER.FUSER\r\n                               AND V.FUSER LIKE ?\r\n                               AND V.FMRDID LIKE ?";
                string str2 = "SELECT V.FMRDID, V.FNAME, T.FDESC, V.FICD_D, V.FODATE, V.FUDATE, TUSER.FDESC FRECORD\r\n                              FROM VTMRDDEPUB001 V, TOFFIM T, TUSERM TUSER\r\n                             WHERE v.FOOFFI = T.FOFFN\r\n                               AND V.FUSER=TUSER.FUSER\r\n                               AND V.FUSER LIKE ?\r\n                               AND V.FMRDID LIKE ? \r\n                               AND V.FUDATE between ? and ?";
                string text = this.txtFmrdid.Text;
                string str4 = this.CbUser.SelectedValue.ToString();
                string str5 = (str4 == "quanbu") ? "%%" : str4;
                DataTable table = new DataTable();
                if (!this.TimeCheck.Checked)
                {
                    OleDbParameter[] opm = new OleDbParameter[] { new OleDbParameter("1", str5), new OleDbParameter("2", text + "%") };
                    table = helper.Query(sql, opm);
                }
                else
                {
                    DateTime date = DateTime.Parse(this.dateEdit1.EditValue.ToString()).Date;
                    DateTime time2 = date;
                    DateTime time3 = new DateTime(date.Year, date.Month, date.Day, 0x17, 0x3b, 0x3b);
                    OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("1", str5), new OleDbParameter("2", text + "%"), new OleDbParameter("3", time2), new OleDbParameter("4", time3) };
                    table = helper.Query(str2, parameterArray2);
                }
                DataColumn column = new DataColumn("ISCHECK", typeof(bool)) {
                    DefaultValue = false
                };
                table.Columns.Add(column);
                this.gridFile.DataSource = table;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable checkeDataTable = this.GetCheckeDataTable();
            if (((checkeDataTable != null) && (checkeDataTable.Rows != null)) && (checkeDataTable.Rows.Count > 0))
            {
                PrintHealthFile file = new PrintHealthFile();
                for (int i = 0; i < checkeDataTable.Rows.Count; i++)
                {
                    string str = checkeDataTable.Rows[i]["FMRDID"].ToString();
                    file.DataBind(str.Insert(str.Length - 2, "_"), checkeDataTable.Rows[i]["FNAME"].ToString(), checkeDataTable.Rows[i]["FDESC"].ToString(), checkeDataTable.Rows[i]["FICD_D"].ToString(), Convert.ToDateTime(checkeDataTable.Rows[i]["FODATE"]).ToShortDateString());
                }
            }
            else
            {
                MessageBox.Show("请选择病历.");
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dataSource = (DataTable) this.gridFile.DataSource;
            if (((dataSource != null) && (dataSource.Rows != null)) && (dataSource.Rows.Count > 0))
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    dataSource.Rows[i]["ISCHECK"] = this.checkEdit1.Checked;
                }
            }
            this.gridFile.DataSource = dataSource;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private DataTable GetCheckeDataTable()
        {
            DataTable dataSource = (DataTable) this.gridFile.DataSource;
            DataTable table2 = dataSource.Copy();
            table2.Clear();
            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                if ((bool) dataSource.Rows[i]["ISCHECK"])
                {
                    table2.ImportRow(dataSource.Rows[i]);
                }
            }
            return table2;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HealthFileSearch
            // 
            this.ClientSize = new System.Drawing.Size(709, 375);
            this.Name = "HealthFileSearch";
            this.ResumeLayout(false);

        }

        private void IsCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            string str = "";
            string str2 = this.gridView1.GetFocusedDataRow()["FMRDID"].ToString();
            str = this.gridView1.GetFocusedDataRow()["ISCHECK"].ToString();
            DataTable dataSource = this.gridFile.DataSource as DataTable;
            foreach (DataRow row in dataSource.Rows)
            {
                if (row["FMRDID"].ToString() == str2)
                {
                    if ((str == "") || (str == "False"))
                    {
                        row["ISCHECK"] = true;
                    }
                    else
                    {
                        row["ISCHECK"] = false;
                    }
                }
            }
            this.gridFile.RefreshDataSource();
        }

        private void LoadData()
        {
            using (DBHelper helper = new DBHelper())
            {
                string sql = "select FUSER,rpad(FDESC,12,'　')||FUSER as USERNAME  from TUSERM ORDER BY FUSER";
                DataTable table = helper.Query(sql);
                DataRow row = table.NewRow();
                row["FUSER"] = "quanbu";
                row["USERNAME"] = "全部";
                table.Rows.InsertAt(row, 0);
                this.CbUser.DataSource = table;
                this.CbUser.DisplayMember = "USERNAME";
                this.CbUser.ValueMember = "FUSER";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys keys = keyData;
            if (keys != Keys.Enter)
            {
                if (keys == Keys.P)
                {
                    this.btnPrint.Focus();
                    this.btnPrint_Click(null, null);
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            this.btnSearch.Focus();
            this.btn_Search_Click(null, null);
            return true;
        }

    }
}

