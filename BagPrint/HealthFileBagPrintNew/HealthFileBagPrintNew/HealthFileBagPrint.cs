using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;
using System.Configuration;
namespace HealthFileBagPrintNew
{
    public partial class HealthFileBagPrint : Form
    {
        public HealthFileBagPrint()
        {
            InitializeComponent();
            this.DEBegin.EditValue = DateTime.Now.ToShortDateString() + " 00:00:00";
            this.DEEnd.EditValue = DateTime.Now.ToShortDateString()+" 23:59:59";
            LoadData();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            using (DBHelper helper = new DBHelper())
            {
                string sql = "SELECT V.FMRDID,V.FBIHID, V.FNAME, T.FDESC, V.FICD_D, V.FODATE, V.FUDATE, TUSER.FDESC FRECORD\r\n                              FROM VTMRDDEPUB001 V, TOFFIM T, TUSERM TUSER \r\n                             WHERE v.FOOFFI = T.FOFFN\r\n                               AND V.FUSER=TUSER.FUSER\r\n                               AND V.FUSER LIKE ?\r\n                               AND V.FBIHID LIKE ? AND (V.FOOFFI = ? OR ?='quanbu') order by V.FUDATE desc";
                string str2 = "SELECT V.FMRDID,V.FBIHID, V.FNAME, T.FDESC, V.FICD_D, V.FODATE, V.FUDATE, TUSER.FDESC FRECORD\r\n                              FROM VTMRDDEPUB001 V, TOFFIM T, TUSERM TUSER\r\n                             WHERE v.FOOFFI = T.FOFFN\r\n                               AND V.FUSER=TUSER.FUSER\r\n                               AND V.FUSER LIKE ?\r\n                               AND V.FBIHID LIKE ? \r\n                               AND V.FUDATE between ? and ? AND (V.FOOFFI = ? OR ?='quanbu') order by V.FUDATE desc";
                string text = this.txtFmrdid.Text;
                string str4 = this.CbUser.SelectedValue.ToString();
                string str5 = (str4 == "quanbu") ? "%%" : str4;
                DataTable table = new DataTable();
                //if (!this.TimeCheck.Checked)
                //{
                //    OleDbParameter[] opm = new OleDbParameter[] { new OleDbParameter("1", str5), new OleDbParameter("2", text + "%"), new OleDbParameter("3", this.CbDept.SelectedValue.ToString()), new OleDbParameter("4", this.CbDept.SelectedValue.ToString()) };
                //    table = helper.Query(sql, opm);
                //}
                //else
                //{
                DateTime date = DateTime.Parse(this.DEBegin.EditValue.ToString());
                DateTime end = DateTime.Parse(this.DEEnd.EditValue.ToString()) ;
                DateTime time2 = date;
                DateTime time3 = end;//new DateTime(date.Year, date.Month, date.Day, 0x17, 0x3b, 0x3b);
                OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("1", str5), new OleDbParameter("2", text + "%"), new OleDbParameter("3", time2), new OleDbParameter("4", time3), new OleDbParameter("5", this.CbDept.SelectedValue.ToString()), new OleDbParameter("6", this.CbDept.SelectedValue.ToString()) };
                table = helper.Query(str2, parameterArray2);
                //}
                DataColumn column = new DataColumn("ISCHECK", typeof(bool))
                {
                    DefaultValue = false
                };
                table.Columns.Add(column);
                this.gridFile.DataSource = table;
                lblRowsCount.Text = "查询结果共【"+table.Rows.Count+"】行";
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
                    string str2 = checkeDataTable.Rows[i]["FBIHID"].ToString();
                    file.strBlackTag = str2.Substring(str2.Length - 3, 1);
                    string str = checkeDataTable.Rows[i]["FMRDID"].ToString();
                    file.DataBind(checkeDataTable.Rows[i]["FBIHID"].ToString(), str.Insert(str.Length - 2, "_"), checkeDataTable.Rows[i]["FNAME"].ToString(), checkeDataTable.Rows[i]["FDESC"].ToString(), checkeDataTable.Rows[i]["FICD_D"].ToString(), Convert.ToDateTime(checkeDataTable.Rows[i]["FODATE"]).ToShortDateString());
                }
            }

        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dataSource = (DataTable)this.gridFile.DataSource;
            if (((dataSource != null) && (dataSource.Rows != null)) && (dataSource.Rows.Count > 0))
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    dataSource.Rows[i]["ISCHECK"] = this.checkEdit1.Checked;
                }
            }
            this.gridFile.DataSource = dataSource;
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (this.components != null))
        //    {
        //        this.components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private DataTable GetCheckeDataTable()
        {
            if (this.gridFile.DataSource != null) 
            {
                DataTable dataSource = (DataTable)this.gridFile.DataSource;
                DataTable table2 = dataSource.Copy();
                table2.Clear();
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if ((bool)dataSource.Rows[i]["ISCHECK"])
                    {
                        table2.ImportRow(dataSource.Rows[i]);
                    }
                }
                return table2;
            }
            else
            {
                MessageBox.Show("没有病案需要打印！");
                return null;
            }
        }
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // HealthFileSearch
        //    // 
        //    this.ClientSize = new System.Drawing.Size(709, 375);
        //    this.Name = "HealthFileSearch";
        //    this.ResumeLayout(false);

        //}
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

                string sqlDept = "select t.FOFFN,t.FDESC from VTOFFIM t where t.FTYPE='I'";

                DataTable tableDept = helper.Query(sqlDept);
                DataRow rowDept = tableDept.NewRow();
                rowDept["FOFFN"] = "quanbu";
                rowDept["FDESC"] = "全部";
                tableDept.Rows.InsertAt(rowDept, 0);
                this.CbDept.DataSource = tableDept;
                this.CbDept.DisplayMember = "FDESC";
                this.CbDept.ValueMember = "FOFFN";
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

        private void CbUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintSetting_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new System.Windows.Forms.PrintDialog();
            if (printDialog1.ShowDialog() == DialogResult.OK)//弹出选择印表机的窗体
            {
                string strBagPrint = printDialog1.PrinterSettings.PrinterName.ToString();

                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["bagPrint"].Value = strBagPrint;
                cfa.Save(); 
                //UpdateConfig("bagPrint", strBagPrint);
            }
        }

        /// <summary>
        /// 更新配置文件信息
        /// </summary>
        /// <param name="name">配置文件字段名称</param>
        /// <param name="Xvalue">值</param>
        private void UpdateConfig(string name, string Xvalue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + name + "']");
            XmlElement ele = (XmlElement)node;
            ele.SetAttribute("value", Xvalue);
            doc.Save(Application.ExecutablePath + ".config");
        }

    }
}
