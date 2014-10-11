using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.HISOLAP.Views;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace CJia.HISOLAP.App.UI.HQMS
{
    public partial class CheckReportView : CJia.HISOLAP.Tools.View, Views.ICheckReportView
    {
        /// <summary>
        /// 判断是否已审核
        /// </summary>
        private bool isCheck = false;
        private DateTime StartDate;
        private DateTime EndDate;
        /// <summary>
        /// 审核结果
        /// </summary>
        private DataTable CheckResultData;
        public CheckReportView()
        {
            InitializeComponent();
            InitView();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.CheckReportPresenter(this);
        }
        CheckReportArgs checkReportArgs = new CheckReportArgs();
        public event EventHandler OnInitView;
        public event EventHandler<CheckReportArgs> OnSearch;
        public event EventHandler<CheckReportArgs> OnCheckData;
        public event EventHandler<CheckReportArgs> OnReportData;
        public void ExeBindCheckType(DataTable data)
        {
            if (data == null) return;
            DataRow dr = data.NewRow();
            dr["NAME"] = "全部";
            dr["CODE"] = "0";
            data.Rows.InsertAt(dr, 0);
            cbType.Properties.DataSource = data;
            cbType.Properties.DisplayMember = "NAME";
            cbType.Properties.ValueMember = "CODE";
        }
        public void ExeBindSearchResult(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
                cgPatient.DataSource = data;
            else
                cgPatient.DataSource = null;
            cgCheckResult.DataSource = null;
            isCheck = false;
        }
        public void ExeBindCheckResult(DataTable data)
        {
            cgCheckResult.DataSource = data;
            CheckResultData = data;
            isCheck = true;
        }
        public bool ExeBindIsSuccessReport(bool bol)
        {
            if (bol)
            {
                DataTable data = cgPatient.DataSource as DataTable;
                bool success = ReportData(StartDate, EndDate, data);
                if (success)
                {
                    cgPatient.DataSource = null;
                    cgCheckResult.DataSource = null;
                    isCheck = false;
                }
                return success;
            }
            else
            {
                return false;
            }
        }


        #region 内部调用方法
        public bool ReportData(DateTime start, DateTime end, DataTable data)
        {
            string savePath = CJia.HISOLAP.Tools.ConfigHelper.GetAppStrings("DBFSavePath");
            DateTime date = start;
            while (date < end)
            {
                string dateStr = date.ToString("yyyy-MM-dd");
                string fileName1 = "hqms_tmpl_" + dateStr + "_part1.dbf";
                string tempPDF1 = Application.StartupPath + @"\" + @"hqms_tmpl_part1.dbf";
                string fileName2 = "hqms_tmpl_" + dateStr + "_part2.dbf";
                string tempPDF2 = Application.StartupPath + @"\" + @"hqms_tmpl_part2.dbf";
                DataTable PDFDate = data.Clone();
                foreach (DataRow dr in data.Rows)
                {
                    if (DateTime.Parse(dr["INPUT_DATE"].ToString()).ToString("yyyy-MM-dd") == dateStr)
                    {
                        PDFDate.Rows.Add(dr.ItemArray);
                    }
                }
                if (PDFDate.Rows.Count > 0)
                {
                    DataTable part1 = PDFDate.Copy();
                    for (int i = part1.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i > 253)
                        {
                            part1.Columns.Remove(part1.Columns[i]);
                        }
                    }
                    DataTable part2 = PDFDate.Copy();
                    part2.Columns.Remove("INPUT_DATE");
                    int j = 0;
                    int k = 0;
                    while (j < 254)//保留P22  入院时间  P3 住院号
                    {
                        if (part2.Columns[k].ColumnName == "P3" || part2.Columns[k].ColumnName == "P22")
                        {
                            k++;
                        }
                        else
                        {
                            part2.Columns.Remove(part2.Columns[k]);
                        }
                        j++;
                    }
                    if (part1 != null && part1.Rows.Count > 0)
                    {
                        bool bol1 = CreateDBF(part1, savePath, fileName1, tempPDF1, true);//导出某天的part1 PDF文件
                        if (!bol1)
                        {
                            return false;
                        }
                    }
                    if (part2 != null && part1.Rows.Count > 0)
                    {
                        bool bol2 = CreateDBF(part2, savePath, fileName2, tempPDF2, false);//导出某天的part2 PDF文件
                        if (!bol2)
                        {
                            return false;
                        }
                    }
                }
                date = date.AddDays(+1);
            }
            return true;
        }
        public void InitView()
        {
            dtStart.DateTime = Sysdate;
            dtEnd.DateTime = Sysdate;
            if (OnInitView != null)
                OnInitView(null, null);
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderName">文件夹名</param>
        public void CreaterFolder(string folderName)
        {
            if (!Directory.Exists(folderName))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(folderName); //新建文件夹   
            }
        }
        /// <summary>
        /// 将dataTable转换成DBF文件
        /// </summary>
        /// <param name="data"></param>
        public void CreateDBF(DataTable data)
        {
            string savePath = CJia.HISOLAP.Tools.ConfigHelper.GetAppStrings("DBFSavePath");
            //string str_oleConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\;Extended Properties=dBASE IV;";
            string str_oleConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + savePath + ";Extended Properties=dBASE IV;";
            System.Data.OleDb.OleDbConnection ole_conn = new System.Data.OleDb.OleDbConnection(str_oleConn);
            try
            {
                ole_conn.Open();
                string fileName = "HQMS_" + StartDate.ToString("yyyy.MM.dd") + "~" + EndDate.ToString("yyyy.MM.dd");
                string sqlCreat = "create table " + fileName + "({0})";
                string columns = "";
                foreach (DataColumn col in data.Columns)
                {
                    columns += col.ColumnName;
                    columns += " char(200),";
                }
                columns = columns.Remove(columns.Length - 1, 1);
                sqlCreat = string.Format(sqlCreat, columns);
                System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand
                         (sqlCreat, ole_conn);
                cmd1.ExecuteNonQuery();
                CJia.Controls.UCForWaitingForm waitUC = new CJia.Controls.UCForWaitingForm("正在努力上报....", 0, data.Rows.Count);
                this.Enabled = false;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string sqlInsert = "insert into " + fileName + " values({0})";
                    string invalues = "";
                    foreach (DataColumn col in data.Columns)
                    {
                        invalues += "'" + data.Rows[i][col].ToString() + "',";
                    }
                    invalues = invalues.Remove(invalues.Length - 1, 1);
                    sqlInsert = string.Format(sqlInsert, invalues);
                    System.Data.OleDb.OleDbCommand cmd2 = new System.Data.OleDb.OleDbCommand
                         (sqlInsert, ole_conn);
                    cmd2.ExecuteNonQuery();
                    waitUC.Do("执行进度(" + i + "/" + data.Rows.Count + ")");
                }
                waitUC.ParentForm.Close();
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ole_conn.Close();
            }
        }
        private void CreateSqlParam(System.Data.Odbc.OdbcCommand oCmd, object[] SqlParams)
        {
            if (SqlParams == null || SqlParams.Length == 0)
                return;
            for (int i = 0; i < SqlParams.Length; i++)
            {
                System.Data.Odbc.OdbcParameter oParam = new System.Data.Odbc.OdbcParameter();
                oParam.ParameterName = (i + 1).ToString();
                oParam.Value = SqlParams[i];
                oCmd.Parameters.Add(oParam);
            }
        }
        public bool Execute(System.Data.Odbc.OdbcConnection oConn, string SqlText, object[] SqlParams)
        {
            try
            {
                using (System.Data.Odbc.OdbcCommand oCmd = new System.Data.Odbc.OdbcCommand(SqlText, oConn))
                {
                    CreateSqlParam(oCmd, SqlParams);
                    return oCmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 将dataTable转换成DBF文件
        /// </summary>
        /// <param name="dt">需要导出数据的DataTable</param>
        /// <param name="strExportPath">导出路径</param>
        /// <param name="strExportFile">导出文件名，要带有.dbf的后缀</param>
        /// <param name="strStructFile">标准库的文件名，含有路径</param>
        public bool CreateDBF(DataTable dt, string strExportPath, string strExportFile, string strStructFile, bool bol)
        {
            //第一步：拷贝标准库
            CreaterFolder(strExportPath);
            System.IO.File.Copy(strStructFile, strExportPath + @"\" + strExportFile, true);
            //建立连接，读取拷贝过去的那个库，注意连接字符串，使用的是vfp9.0的driver
            System.Data.Odbc.OdbcConnection conn1 = new System.Data.Odbc.OdbcConnection();
            //conn1.ConnectionString = @"Provider=VFPOLEDB.1;DATA Source=" + strExportPath + @"\" + strExportFile + ";";
            //conn1.ConnectionString = @"Provider=vfpoledb;DATA Source=" + strExportPath + @"\" + ";Collating Sequence=machine;";
            conn1.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + strExportPath + @"\" + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            //conn1.ConnectionString = @"Provider=vfpoledb;Data Source=C:\Users\deng\Desktop\HQMS\HQMS2013\数据文件模板\数据文件模板\DBF文件模板（20121214）\完整的DBF模板\;Collating Sequence=machine;";
            string strSQL = "SELECT * FROM " + strExportFile.Replace(".dbf", "");
            System.Data.Odbc.OdbcDataAdapter adp = new System.Data.Odbc.OdbcDataAdapter(strSQL, conn1);
            System.Data.DataSet ds = new DataSet();
            conn1.Open();
            adp.Fill(ds, "DBF");
            DataTable dtDBF = ds.Tables["DBF"];
            string sqlInsert = "";
            if (bol)
            {
                sqlInsert = @"insert into " + strExportFile.Replace(".dbf", "") + @"(p900, p6891, p686, p800, p1, p2, p3, p4, p5, p6, p7, p8, p9, p101, p102, p103, p11, p12, p13, p801, p802, p803, p14, p15, p16, p17, p171, p18, p19, p20, p804, p21, p22, p23, p231, p24, p25, p26, p261, p27, p28, p281, p29, p30, p301, p31, p321, p322, p805, p323, p324, p325, p806, p326, p327, p328, p807, p329, p3291, p3292, p808, p3293, p3294, p3295, p809, p3296, p3297, p3298, p810, p3299, p3281, p3282, p811, p3283, p3284, p3285, p812, p3286, p3287, p3288, p813, p3289, p3271, p3272, p814, p3273, p3274, p3275, p815, p3276, p689, p351, p352, p816, p353, p354, p817, p355, p356, p818, p361, p362, p363, p364, p365, p366, p371, p372, p38, p39, p40, p411, p412, p413, p414, p415, p421, p422, p687, p688, p431, p432, p433, p434, p819, p435, p436, p437, p438, p44, p45, p46, p47, p490, p491, p820, p492, p493, p494, p495, p496, p497, p498, p4981, p499, p4910, p4911, p4912, p821, p4913, p4914, p4915, p4916, p4917, p4918, p4919, p4982, p4920, p4921, p4922, p4923, p822, p4924, p4925, p4526, p4527, p4528, p4529, p4530, p4983, p4531, p4532, p4533, p4534, p823, p4535, p4536, p4537, p4538, p4539, p4540, p4541, p4984, p4542, p4543, p4544, p4545, p824, p4546, p4547, p4548, p4549, p4550, p4551, p4552, p4985, p4553, p4554, p45002, p45003, p825, p45004, p45005, p45006, p45007, p45008, p45009, p45010, p45011, p45012, p45013, p45014, p45015, p826, p45016, p45017, p45018, p45019, p45020, p45021, p45022, p45023, p45024, p45025, p45026, p45027, p827, p45028, p45029, p45030, p45031, p45032, p45033, p45034, p45035, p45036, p45037, p45038, p45039, p828, p45040, p45041, p45042, p45043, p45044, p45045, p45046, p45047, p45048, p45049, p45050, p45051, p829, p45052)
                    values
                      ( ?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            }
            else
            {
                sqlInsert = @"insert into " + strExportFile.Replace(".dbf", "") + @"( p3,p22, p45053, p45054, p45055, p45056, p45057, p45058, p45059, p45060, p45061, p561, p562, p563, p564, p6911, p6912, p6913, p6914, p6915, p6916, p6917, p6918, p6919, p6920, p6921, p6922, p6923, p6924, p6925, p57, p58, p581, p60, p611, p612, p613, p59, p62, p63, p64, p651, p652, p653, p654, p655, p656, p66, p681, p682, p683, p684, p685, p67, p731, p732, p733, p734, p72, p830, p831, p741, p742, p743, p782, p751, p752, p754, p755, p756, p757, p758, p759, p760, p761, p762, p763, p764, p765, p767, p768, p769, p770, p771, p772, p773, p774, p775, p776, p777, p778, p779, p780, p781)
                    values
                      (?,?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List<object> sqlparams = new List<object>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Type type = dt.Columns[j].DataType;
                    Type typeDBF = dtDBF.Columns[j].DataType;
                    if (dt.Rows[i][j].ToString().Length == 0)
                    {
                        double a = 1.56;
                        object b = (object)a;
                        sqlparams.Add(DBNull.Value);
                    }
                    else
                    {
                        if (type.Name != typeDBF.Name)
                        {
                            if (typeDBF == typeof(int))
                                sqlparams.Add(int.Parse(dt.Rows[i][j].ToString()));
                            else if (typeDBF == typeof(decimal))
                            {
                                sqlparams.Add(dt.Rows[i][j]);
                            }
                            else if (typeDBF == typeof(string))
                                sqlparams.Add(dt.Rows[i][j].ToString());
                            else if (typeDBF == typeof(DateTime))
                                sqlparams.Add(DateTime.Parse(dt.Rows[i][j].ToString()));
                        }
                        else
                        {
                            if (dt.Columns[j].ColumnName == "P66")
                            {
                                object o = dt.Rows[i][j];
                                string s = dt.Rows[i][j].ToString();
                                decimal d = (decimal)dt.Rows[i][j];
                                sqlparams.Add(int.Parse(dt.Rows[i][j].ToString()));
                            }
                            else
                                sqlparams.Add(dt.Rows[i][j]);
                        }
                    }
                }
                bool bl = Execute(conn1, sqlInsert, sqlparams.ToArray());
                if (!bl)
                {
                    MessageBox.Show("生成PDF文件失败");
                    return false;
                }
            }
            conn1.Close();
            return true;
            #region
            //string strSQL = "SELECT * FROM " + strExportFile.Replace(".dbf", "");
            //System.Data.Odbc.OdbcDataAdapter adp = new System.Data.Odbc.OdbcDataAdapter(strSQL, conn1);
            ////初始化一个CommandBuilder，目的是使得adp的更新操作初始化
            //System.Data.Odbc.OdbcCommandBuilder cmdBld = new System.Data.Odbc.OdbcCommandBuilder(adp);
            ////adp.InsertCommand = cmdBld.GetInsertCommand();
            ////adp.DeleteCommand = cmdBld.GetDeleteCommand();
            ////adp.UpdateCommand = cmdBld.GetUpdateCommand();
            //System.Data.DataSet ds = new DataSet();
            //conn1.Open();
            //adp.Fill(ds, "DBF");
            //conn1.Close();
            //DataTable dt1 = ds.Tables["DBF"];
            //dt1.PrimaryKey = new DataColumn[] { dt1.Columns["P3"], dt1.Columns["P2"] };//建立一个主键
            ////循环读取dt的数据添加到dt1，注意方法，还有一个就是null值的处理，具体要根据你的dbf库结构来设定。
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt1.NewRow();
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        //如果是null，则赋值为DBNull.Value；如果不是null，则插入原始值dt.Rows[i][dt1.Colums[j].ColumnName.ToString()]
            //        dr[j] = dt.Rows[i][dt1.Columns[j].ColumnName.ToString()] == null ? DBNull.Value : dt.Rows[i][dt1.Columns[j].ColumnName.ToString()];
            //    }
            //    dt1.Rows.Add(dr);
            //}
            ////更新dt1，系统自动将数据添加到dbf库中
            //adp.Update(ds, "DBF");
            #endregion
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (OnSearch != null)
            {
                checkReportArgs.StartDate = DateTime.Parse(dtStart.DateTime.ToShortDateString());
                checkReportArgs.EndDate = DateTime.Parse(dtEnd.DateTime.ToShortDateString()).AddDays(1).AddSeconds(-1);
                EndDate = checkReportArgs.EndDate;
                StartDate = checkReportArgs.StartDate;//记录用户查询的时间（防止用户选择时间后不点查询）
                OnSearch(null, checkReportArgs);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (cgPatient.DataSource != null)
            {
                if (OnCheckData != null)
                {
                    checkReportArgs.PatientData = cgPatient.DataSource as DataTable;
                    OnCheckData(null, checkReportArgs);
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (cgPatient.DataSource != null)
            {
                if (isCheck)
                {
                    checkReportArgs.PatientData = cgPatient.DataSource as DataTable;
                    checkReportArgs.CheckResultPatientData = CheckResultData;
                    OnReportData(null, checkReportArgs);
                }
                else
                {
                    Message.Show("请先审核数据！");
                }
            }
        }

        private void cgCheckResult_DoubleClick(object sender, EventArgs e)
        {
            if (cgCheckResult.DataSource != null)
            {
                string appExeNamePath = CJia.HISOLAP.Tools.ConfigHelper.GetAppStrings("JinChuangSoftwarePath");
                string exeName = CJia.HISOLAP.Tools.ConfigHelper.GetAppStrings("JinChuangSoftwareName");
                if (CheckExistProcess(exeName))
                {

                }
                else
                {
                    if (File.Exists(appExeNamePath))
                    {
                        try
                        {
                            Process.Start(appExeNamePath);
                        }
                        catch { }
                    }
                }
            }
        }

        private void cbType_TextChanged(object sender, EventArgs e)
        {
            if (CheckResultData != null && CheckResultData.Rows.Count > 0)
            {
                string checkId = cbType.EditValue.ToString();
                if (checkId == "0")
                {
                    cgCheckResult.DataSource = CheckResultData;
                }
                else
                {
                    DataRow[] drs = CheckResultData.Select(" CHECK_ID=" + checkId);
                    DataTable dt = new DataTable();
                    dt = CheckResultData.Clone();
                    foreach (DataRow dr in drs)
                    {
                        dt.ImportRow(dr);
                    }
                    cgCheckResult.DataSource = dt;
                }
            }
        }

        #region 程序获得焦点
        [DllImport("USER32.DLL", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(
            System.IntPtr hWnd,
            int nCmdShow
        );
        [DllImport("USER32.DLL", CharSet = CharSet.Auto)]
        private static extern bool SetForegroundWindow(
            System.IntPtr hWnd
        );
        private const int SW_NORMAL = 1;
        //判断是否存在名为processName的进程(程序)，存在的话使它获得焦点
        //例 if (CheckExistProcess("JobExec") == false)
        private static bool CheckExistProcess(string processName)
        {
            bool aRet = false;
            System.Diagnostics.Process[] arrProcess
                = System.Diagnostics.Process.GetProcessesByName(processName);
            if (arrProcess.Length > 0) { aRet = true; }
            if (aRet)
            {
                try
                {
                    foreach (System.Diagnostics.Process hProcess in arrProcess)
                    {
                        ShowWindow(hProcess.MainWindowHandle, SW_NORMAL);
                        SetForegroundWindow(hProcess.MainWindowHandle);
                        break;
                    }
                }
                catch { }
            }
            return aRet;
        }
        #endregion

        private void gvCheckResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "CHECK_NAME")
                {
                    string checkID = gvCheckResult.GetDataRow(e.RowHandle)["CHECK_ID"].ToString();
                    if (checkID == "1001")//强制性错误
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    if (checkID == "1002")//逻辑错误
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
        }

    }

}
