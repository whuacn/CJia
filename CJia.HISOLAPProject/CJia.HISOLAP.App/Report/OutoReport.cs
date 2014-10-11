using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using CJia.HISOLAP.App.Tools;

namespace CJia.HISOLAP.App.Report
{
    /// <summary>
    /// 列类型
    /// </summary>
    public enum CelType
    {
        /// <summary>
        /// 是分组列
        /// </summary>
        FZ,
        /// <summary>
        /// 是数据列
        /// </summary>
        SJ
    }

    public enum ReportType
    {
        /// <summary>
        /// 窄报表
        /// </summary>
        Horizontal,
        /// <summary>
        /// 宽报表
        /// </summary>
        Vertical
    }

    /// <summary>
    /// 统计报表
    /// </summary>
    public partial class OutoReport : DevExpress.XtraReports.UI.XtraReport
    {

        public OutoReport(ReportType reportType)
        {
            //InitializeComponent();
            if (reportType == ReportType.Horizontal)
            {
                InitializeHorizontalComponent();
            }
            if (reportType == ReportType.Vertical)
            {
                InitializeVerticalComponent();
            }
        }

        /// <summary>
        /// 实验方法
        /// </summary>
        private void Test()
        {

            DataTable result = CJia.DefaultOleDb.Query(" SELECT NON EMPTY { [Measures].[HOSPITALISE FEE], [Measures].[OPERATION DATA 计数], [Measures].[HOSPITALISE DAYS] } ON COLUMNS, NON EMPTY { ([OPERATION DIM].[OPERATION NAME].[OPERATION NAME].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM [JJFB] CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS");
            DataTable data = new DataTable();
            data.Columns.Add("项目列1");
            data.Columns.Add("数据列分组1_1.数据列");
            data.Columns.Add("数据列分组1_2.数据列");
            data.Columns.Add("数据列分组1_3.数据列");
            data.Columns.Add("数据列分组2_1.数据列");
            data.Columns.Add("数据列分组2_2.数据列");
            data.Columns.Add("数据列分组2_3.数据列");
            data.Columns.Add("数据列分组2_4.数据列");
            data.Rows.Add("数据行分组1_      数据行1", "12", "12", "13", "21", "22", "23", "24");
            data.Rows.Add("数据行分组2_      数据行2", "12", "12", "13", "21", "22", "23", "24");
            //this.txtBT = "这是标题";
            this.txtRQ = "这是日期";
            this.txtZZJJDM = "这是组织机构代码";
            this.txtZZJJMC = "这是组织机构名称";
            this.BindData(data);
            this.CreateDocument();
            this.ShowPreview();
        }

        #region 内部属性

        private StringLengthHelper stringLengthHelper = new StringLengthHelper();

        /// <summary>
        /// 表格宽度
        /// </summary>
        private float allWidth
        {
            get
            {
                return this.lbZBT.WidthF;
            }
        }

        /// <summary>
        /// 表格高度
        /// </summary>
        private float labelHeight
        {
            get
            {
                return 25;
            }
        }

        #endregion

        #region 显示设置

        /// <summary>
        /// 设置报表主标题
        /// </summary>
        public string txtZBT
        {
            set
            {
                this.lbZBT.Text = value;
            }
        }

        /// <summary>
        /// 设置报表副标题
        /// </summary>
        public string txtFBT
        {
            set
            {
                this.lbFBT.Text = value;
            }
        }

        /// <summary>
        /// 设置报表日期
        /// </summary>
        public string txtRQ
        {
            set
            {
                this.lbRQ.Text = value;
            }
        }

        /// <summary>
        /// 设置组织机构代码
        /// </summary>
        public string txtZZJJDM
        {
            set
            {
                this.lbZZJGDM.Text = value;
            }
        }

        /// <summary>
        /// 设置组织机构名称
        /// </summary>
        public string txtZZJJMC
        {
            set
            {
                this.lbZZJJMC.Text = value;
            }
        }

        /// <summary>
        /// 设置科室名称
        /// </summary>
        public string txtDeptName
        {
            set
            {
                this.xrLabel2.Visible = true;
                this.lbDeptName.Visible = true;
                this.lbDeptName.Text = value;
            }
        }
        #endregion

        #region 显示表格设置

        public int FirstBT = 15;

        /// <summary>
        /// 各列的宽度
        /// </summary>
        private List<float> columnsWidth;

        /// <summary>
        /// 标题的行数
        /// </summary>
        private int btRowCount = 1;

        private List<string> columns;
        /// <summary>
        /// 设置表格每列名称
        /// </summary>
        private List<string> Columns
        {
            set
            {
                if(value != null && value.Count >= 2)
                {
                    //this.columns = value;
                    //this.ColumnsCount = value.Count - 1;
                    //columnsWidth = new List<float>();
                    //int allLength = this.FirstBT;
                    //for(int i = 1; i < value.Count; i++)
                    //{
                    //    string[] strs = value[i].Split('_');
                    //    allLength += strs[strs.Length -  1].Length;
                    //}
                    //columnsWidth.Add(this.allWidth * this.FirstBT / allLength);
                    //for(int i = 1; i < value.Count; i++)
                    //{
                    //    if(value[i].IndexOf('_') != -1 || value[i - 1].IndexOf('_') != -1)
                    //    {
                    //        this.btRowCount = 2;
                    //    }
                    //    string[] strs = value[i].Split('_');
                    //    columnsWidth.Add(this.allWidth * strs[strs.Length - 1].Length / allLength);
                    //}

                    this.columns = value;
                    //this.columns.Clear();
                    this.ColumnsCount = value.Count - 1;
                    columnsWidth = new List<float>();
                    int allLength = this.FirstBT;
                    for (int i = 0; i < value.Count; i++)
                    {
                        string[] strs = value[i].Split('$');
                        float a = float.Parse(strs[strs.Length - 1].Substring(0, strs[strs.Length - 1].Length - 1))/100;
                        columnsWidth.Add(this.allWidth * float.Parse(strs[strs.Length - 1].Substring(0, strs[strs.Length - 1].Length - 1))/100);
                        //this.columns.Add(strs[strs.Length - 2]);
                    }
                    //columnsWidth.Add(this.allWidth * this.FirstBT / allLength);
                    for (int i = 1; i < value.Count; i++)
                    {
                        if (value[i].IndexOf('_') != -1 || value[i - 1].IndexOf('_') != -1)
                        {
                            this.btRowCount = 2;
                        }
                    }
                }
                else
                {
                    throw new Exception("列名称设置错误！");
                }
            }
            get
            {
                return this.columns;
            }
        }

        /// <summary>
        /// 共有多少列数据
        /// </summary>
        private int ColumnsCount;

        #endregion

        #region 外部方法

        /// <summary>
        /// 将报表以图片格式返回
        /// </summary>
        /// <returns></returns>
        public Image GenImage()
        {
            this.CreateDocument();
            Directory.CreateDirectory(Application.StartupPath + "\\ReportPreview");
            string path = Application.StartupPath + "\\ReportPreview\\" + DateTime.Now.ToString("yyyyMMddhhmmssfffffff") + ".jpg";
            this.ExportToImage(path);
            return Image.FromFile(path);
        }

        /// <summary>
        /// 绑定报表数据
        /// </summary>
        /// <param name="data">数据源</param>
        public void BindData(DataTable data)
        {
            if(data != null && data.Rows != null && data.Rows.Count > 0)
            {
                List<string> colStr = new List<string>();
                foreach(DataColumn col in data.Columns)
                {
                    colStr.Add(col.ColumnName);
                }
                this.Columns = colStr;
                List<string> newColumns = new List<string>();
                foreach (string a in colStr)
                {
                    newColumns.Add(a.Split('$')[a.Split('$').Length - 2]);
                }
                this.addBTRow(newColumns);
                foreach(DataRow row in data.Rows)
                {
                    List<string> rowStr = new List<string>();
                    foreach(DataColumn col in data.Columns)
                    {
                        rowStr.Add(row[col.ColumnName].ToString());
                    }
                    this.addRow(rowStr,CelType.SJ);
                }
            }
            this.CreateDocument();
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 现在Y位置
        /// </summary>
        private float newY = 0;

        private List<string> BigFz = new List<string>();

        private List<XRLabel> rowLabel;
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="rowDate"></param>
        private void addRow(List<string> rowData,CelType celType)
        {
            float newX = 0F;
            rowLabel = new List<XRLabel>();
            for(int i = 0; i < rowData.Count; i++)
            {
                string rowStr = rowData[i];
                if(i == 0)
                {
                    string[] btStrs = rowData[i].Split('_');
                    if(btStrs.Length > 1)
                    {
                        rowStr = btStrs[1];
                        if(!this.BigFz.Contains(btStrs[0]))
                        {
                            List<string> newRowData = new List<string>();
                            for(int j = 0; j < rowData.Count; j++)
                            {
                                if(j == 0)
                                {
                                    newRowData.Add(btStrs[0]);
                                }
                                else
                                {
                                    newRowData.Add("-");
                                }
                            }
                            this.addRow(newRowData,CelType.FZ);
                            this.BigFz.Add(btStrs[0]);
                        }
                    }
                }
                XRLabel label = new XRLabel();
                label = new XRLabel();
                label.LocationF = new PointF(newX, newY);
                label.WidthF = this.columnsWidth[i];
                label.HeightF = this.labelHeight;
                label.Text = rowStr;
                if (i < rowData.Count-1)
                {
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left;
                }
                else
                {
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
                }

                if (i == 0)
                {
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                }
                else
                {
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                }

                if(celType == CelType.FZ)
                {
                    label.Font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);
                }
                else
                {
                    label.Font = new System.Drawing.Font("微软雅黑", 10F);
                }
                rowLabel.Add(label);
                this.Detail.Controls.Add(label);
                newX = newX + this.columnsWidth[i];
            }
            this.AdjustRowHeight();
        }

        /// <summary>
        /// 调整行数据的高度
        /// </summary>
        private void AdjustRowHeight()
        {
            int newRowCount = 1;
            foreach(XRLabel label in this.rowLabel)
            {
                int rowCount = ((int)(stringLengthHelper.StringLength(label.Text, label.Font))) / label.Width + 1;
                if(rowCount > newRowCount)
                {
                    newRowCount = rowCount;
                }
            }

            foreach(XRLabel label in this.rowLabel)
            {
                label.HeightF = this.labelHeight * newRowCount;
            }

            this.newY = this.newY + this.labelHeight * newRowCount;
            this.rowLabel.Clear();
        }

        private Dictionary<string, DevExpress.XtraReports.UI.XRLabel> UpLabel;
        private List<DevExpress.XtraReports.UI.XRLabel> BigLabel;
        private List<DevExpress.XtraReports.UI.XRLabel> BtoLabel; 
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="btData"></param>
        private void addBTRow(List<string> btData)
        {
            float newX = 0F;
            float rowHeight = this.labelHeight * btRowCount;
            this.UpLabel = new Dictionary<string, XRLabel>();
            this.BigLabel = new List<XRLabel>();
            this.BtoLabel = new List<XRLabel>();
            for(int i = 0; i < btData.Count; i++)
            {
                string[] btStrs = btData[i].Split('_');
                if(btStrs.Length > 1)
                {
                    DevExpress.XtraReports.UI.XRLabel uplabel;
                    if(this.UpLabel.ContainsKey(btStrs[0]))
                    {
                        uplabel = this.UpLabel[btStrs[0]];
                        uplabel.WidthF = uplabel.WidthF + this.columnsWidth[i];
                    }
                    else
                    {
                        uplabel = new XRLabel();
                        uplabel.LocationF = new PointF(newX, newY);
                        uplabel.WidthF = this.columnsWidth[i];
                        uplabel.HeightF = rowHeight / 2;
                        uplabel.Text = btStrs[0];
                        uplabel.Font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);
                        uplabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        if (i < btData.Count - 1)
                        {
                            uplabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left;
                        }
                        else 
                        {
                            uplabel.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Right;
                        }
                        
                        this.UpLabel.Add(btStrs[0], uplabel);
                        this.Detail.Controls.Add(uplabel);
                    }

                    DevExpress.XtraReports.UI.XRLabel label = new XRLabel();
                    label.LocationF = new PointF(newX, newY + this.labelHeight);
                    label.WidthF = this.columnsWidth[i];
                    label.HeightF = rowHeight / 2;
                    label.Text = btStrs[1];
                    label.Font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    if (i < btData.Count - 1)
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left;
                    }
                    else
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Right;
                    }
                    this.BtoLabel.Add(label);
                    this.Detail.Controls.Add(label);

                    newX = newX + label.WidthF;
                }
                else
                {
                    DevExpress.XtraReports.UI.XRLabel label = new XRLabel();
                    label.LocationF = new PointF(newX, newY);
                    label.WidthF = this.columnsWidth[i];
                    label.HeightF = rowHeight;
                    label.Text = btData[i];
                    label.Font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    if (i < btData.Count - 1)
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left;
                    }
                    else
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Right;
                    }
                    this.BigLabel.Add(label);
                    this.Detail.Controls.Add(label);
                    newX = newX + label.WidthF;
                }
            }
            this.AdjustBTHeight();
        }

        /// <summary>
        /// 调整标题的高度
        /// </summary>
        private void AdjustBTHeight()
        {
            int bigRowCount = 1;
            if(this.BigLabel.Count > 0)
            {
                foreach(XRLabel label in this.BigLabel)
                {
                    int newRowCount = ((int)(stringLengthHelper.StringLength(label.Text, label.Font) - 4)) / label.Width + 1;
                    if(newRowCount > bigRowCount)
                    {
                        bigRowCount = newRowCount;
                    }
                }
            }

            int upRowCount = 0;
            if(this.UpLabel.Keys.Count > 0)
            {
                foreach(XRLabel label in this.UpLabel.Values)
                {
                    int newRowCount = ((int)(stringLengthHelper.StringLength(label.Text, label.Font) - 4)) / label.Width + 1;
                    if(newRowCount > upRowCount)
                    {
                        upRowCount = newRowCount;
                    }
                }
            }

            int btoRowCount = 0;
            if(this.BtoLabel.Count > 0)
            {
                foreach(XRLabel label in this.BtoLabel)
                {
                    int newRowCount = ((int)(stringLengthHelper.StringLength(label.Text, label.Font) - 4)) / label.Width + 1;
                    if(newRowCount > btoRowCount)
                    {
                        btoRowCount = newRowCount;
                    }
                }
            }

            if(bigRowCount >= upRowCount + btoRowCount)
            {
                btoRowCount = bigRowCount - upRowCount;
            }
            else
            {
                bigRowCount = upRowCount + btoRowCount;
            }

            if(this.BigLabel.Count > 0)
            {
                foreach(XRLabel label in this.BigLabel)
                {
                    label.HeightF = bigRowCount * this.labelHeight;
                }
            }

            if(this.UpLabel.Keys.Count > 0)
            {
                foreach(XRLabel label in this.UpLabel.Values)
                {
                    label.HeightF = upRowCount * this.labelHeight;
                }
            }

            if(this.BtoLabel.Count > 0)
            {
                foreach(XRLabel label in this.BtoLabel)
                {
                    label.HeightF = btoRowCount * this.labelHeight;
                }
            }

            this.newY = this.newY + bigRowCount * this.labelHeight;
        }

        #endregion

        private void InitializeComponent()
        {
            this.topMarginBand7 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand7 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand7 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand7
            // 
            this.topMarginBand7.Name = "topMarginBand7";
            // 
            // detailBand7
            // 
            this.detailBand7.Name = "detailBand7";
            // 
            // bottomMarginBand7
            // 
            this.bottomMarginBand7.Name = "bottomMarginBand7";
            // 
            // OutoReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand7,
            this.detailBand7,
            this.bottomMarginBand7});
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        //private void InitializeComponent()
        //{
        //    this.topMarginBand6 = new DevExpress.XtraReports.UI.TopMarginBand();
        //    this.detailBand6 = new DevExpress.XtraReports.UI.DetailBand();
        //    this.bottomMarginBand6 = new DevExpress.XtraReports.UI.BottomMarginBand();
        //    ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        //    // 
        //    // topMarginBand6
        //    // 
        //    this.topMarginBand6.Name = "topMarginBand6";
        //    // 
        //    // detailBand6
        //    // 
        //    this.detailBand6.Name = "detailBand6";
        //    // 
        //    // bottomMarginBand6
        //    // 
        //    this.bottomMarginBand6.Name = "bottomMarginBand6";
        //    // 
        //    // OutoReport
        //    // 
        //    this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
        //    this.topMarginBand6,
        //    this.detailBand6,
        //    this.bottomMarginBand6});
        //    this.Version = "12.1";
        //    ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        //}
    }
}
