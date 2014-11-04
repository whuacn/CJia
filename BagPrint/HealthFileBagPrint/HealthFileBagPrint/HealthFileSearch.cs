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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(HealthFileSearch));
            this.gridFile = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn6 = new GridColumn();
            this.ischecked = new RepositoryItemCheckEdit();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.txtFmrdid = new TextEdit();
            this.dateEdit1 = new DateEdit();
            this.btnSearch = new SimpleButton();
            this.panelControl1 = new PanelControl();
            this.labelControl3 = new LabelControl();
            this.TimeCheck = new CheckEdit();
            this.btnPrint = new SimpleButton();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.checkEdit1 = new CheckEdit();
            this.CbUser = new System.Windows.Forms.ComboBox();
            this.gridColumn8 = new GridColumn();
            this.gridFile.BeginInit();
            this.gridView1.BeginInit();
            this.ischecked.BeginInit();
            this.txtFmrdid.Properties.BeginInit();
            this.dateEdit1.Properties.VistaTimeProperties.BeginInit();
            this.dateEdit1.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.TimeCheck.Properties.BeginInit();
            this.checkEdit1.Properties.BeginInit();
            base.SuspendLayout();
            this.gridFile.Location = new Point(1, 0x49);
            this.gridFile.MainView = this.gridView1;
            this.gridFile.Name = "gridFile";
            this.gridFile.RepositoryItems.AddRange(new RepositoryItem[] { this.ischecked });
            this.gridFile.Size = new Size(0x32e, 0x1a5);
            this.gridFile.TabIndex = 4;
            this.gridFile.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.Columns.AddRange(new GridColumn[] { this.gridColumn6, this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn8, this.gridColumn7 });
            this.gridView1.GridControl = this.gridFile;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn6.Caption = "全选";
            this.gridColumn6.ColumnEdit = this.ischecked;
            this.gridColumn6.FieldName = "ISCHECK";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 0x48;
            this.ischecked.AutoHeight = false;
            this.ischecked.Name = "ischecked";
            this.ischecked.NullStyle = StyleIndeterminate.Unchecked;
            this.ischecked.CheckedChanged += new EventHandler(this.IsCheckEdit_CheckedChanged);
            this.gridColumn1.Caption = "病案号";
            this.gridColumn1.FieldName = "FMRDID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 0x75;
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "FNAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 0x75;
            this.gridColumn3.Caption = "科别";
            this.gridColumn3.FieldName = "FDESC";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 0x75;
            this.gridColumn4.Caption = "诊断";
            this.gridColumn4.FieldName = "FICD_D";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 0x75;
            this.gridColumn5.Caption = "出院日期";
            this.gridColumn5.FieldName = "FODATE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 0x75;
            this.gridColumn7.Caption = "录入时间";
            this.gridColumn7.FieldName = "FUDATE";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 0x8b;
            this.txtFmrdid.Location = new Point(0x39, 0x16);
            this.txtFmrdid.Name = "txtFmrdid";
            this.txtFmrdid.Size = new Size(0x86, 20);
            this.txtFmrdid.TabIndex = 5;
            this.dateEdit1.EditValue = new DateTime(0x7dd, 8, 20, 15, 0x2d, 12, 0);
            this.dateEdit1.Location = new Point(0x1eb, 0x16);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.dateEdit1.Properties.EditFormat.FormatType = FormatType.DateTime;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.dateEdit1.Size = new Size(0x86, 20);
            this.dateEdit1.TabIndex = 6;
            this.btnSearch.Location = new Point(0x27b, 0x13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(90, 0x17);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查 询(Enter)";
            this.btnSearch.Click += new EventHandler(this.btn_Search_Click);
            this.panelControl1.Controls.Add(this.CbUser);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.TimeCheck);
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.txtFmrdid);
            this.panelControl1.Location = new Point(1, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x32e, 0x41);
            this.panelControl1.TabIndex = 8;
            this.labelControl3.Location = new Point(0xcd, 0x18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x30, 14);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "录入人：";
            this.TimeCheck.EditValue = true;
            this.TimeCheck.Location = new Point(0x19b, 0x16);
            this.TimeCheck.Name = "TimeCheck";
            this.TimeCheck.Properties.Caption = "checkEdit2";
            this.TimeCheck.Size = new Size(20, 0x13);
            this.TimeCheck.TabIndex = 11;
            this.btnPrint.Location = new Point(0x2dc, 0x13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x17);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "打 印(P)";
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.labelControl2.Location = new Point(0x1af, 0x18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "录入时间：";
            this.labelControl1.Location = new Point(11, 0x18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(40, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "病案号:";
            this.checkEdit1.Location = new Point(0x2c, 0x4b);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "checkEdit1";
            this.checkEdit1.Size = new Size(20, 0x13);
            this.checkEdit1.TabIndex = 9;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.CbUser.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CbUser.FormattingEnabled = true;
            this.CbUser.Location = new Point(250, 0x15);
            this.CbUser.Name = "CbUser";
            this.CbUser.Size = new Size(0x86, 0x16);
            this.CbUser.TabIndex = 15;
            this.gridColumn8.Caption = "录入人";
            this.gridColumn8.FieldName = "FRECORD";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x330, 0x1ef);
            base.Controls.Add(this.checkEdit1);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.gridFile);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "HealthFileSearch";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "九江市妇幼保健院病历袋打印工具";
            this.gridFile.EndInit();
            this.gridView1.EndInit();
            this.ischecked.EndInit();
            this.txtFmrdid.Properties.EndInit();
            this.dateEdit1.Properties.VistaTimeProperties.EndInit();
            this.dateEdit1.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.TimeCheck.Properties.EndInit();
            this.checkEdit1.Properties.EndInit();
            base.ResumeLayout(false);
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

