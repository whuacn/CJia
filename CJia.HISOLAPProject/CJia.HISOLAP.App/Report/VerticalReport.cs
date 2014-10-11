using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace CJia.HISOLAP.App.Report
{

    /// <summary>
    /// 行类型
    /// </summary>
    enum RowType
    {
        /// <summary>
        /// 标题行
        /// </summary>
        BT,
        /// <summary>
        /// 分组行
        /// </summary>
        FZ,
        /// <summary>
        /// 数据行
        /// </summary>
        SJ
    }

    /// <summary>
    /// 发药统计报表
    /// </summary>
    public partial class VerticalReport : DevExpress.XtraReports.UI.XtraReport
    {
         public VerticalReport()
        {
            InitializeComponent();
            //this.Init();
        }

        /// <summary>
        /// 实验方法
        /// </summary>
        private void Init()
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

        #endregion

        #region 显示表格设置

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
                    this.columns = value;
                    this.ColumnsCount = value.Count - 1;
                    columnsWidth = new List<float>();
                    int allLength = 20;
                    for(int i = 1; i < value.Count; i++)
                    {
                        string[] strs = value[i].Split('_');
                        allLength += strs[strs.Length -  1].Length;
                    }
                    columnsWidth.Add(this.allWidth * 20 / allLength);
                    for(int i = 1; i < value.Count; i++)
                    {
                        if(value[i].IndexOf('_') != -1 || value[i - 1].IndexOf('_') != -1)
                        {
                            this.btRowCount = 2;
                        }
                        string[] strs = value[i].Split('_');
                        columnsWidth.Add(this.allWidth * strs[strs.Length - 1].Length / allLength);
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
                this.addBTRow(this.Columns);
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
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="rowDate"></param>
        private void addRow(List<string> rowData,CelType celType)
        {
            float newX = 12.5F;
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
                if(i == 0)
                {
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else
                {
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left;
                }
                if(celType == CelType.FZ)
                {
                    label.Font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);
                }
                else
                {
                    label.Font = new System.Drawing.Font("微软雅黑", 10F);
                }
                this.Detail.Controls.Add(label);

                newX = newX + this.columnsWidth[i];
            }
            this.newY = this.newY + this.labelHeight;
        }

        private Dictionary<string, DevExpress.XtraReports.UI.XRLabel> BigLabel;
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="btData"></param>
        private void addBTRow(List<string> btData)
        {
            float newX = 12.5F;
            float rowHeight = this.labelHeight * btRowCount;
            this.BigLabel = new Dictionary<string, XRLabel>();
            for(int i = 0; i < btData.Count; i++)
            {
                string[] btStrs = btData[i].Split('_');
                if(btStrs.Length > 1)
                {
                    DevExpress.XtraReports.UI.XRLabel uplabel;
                    if(this.BigLabel.ContainsKey(btStrs[0]))
                    {
                        uplabel = this.BigLabel[btStrs[0]];
                        uplabel.WidthF = uplabel.WidthF + this.columnsWidth[i];
                    }
                    else
                    {
                        uplabel = new XRLabel();
                        uplabel.LocationF = new PointF(newX, newY);
                        uplabel.WidthF = this.columnsWidth[i];
                        uplabel.HeightF = rowHeight / 2;
                        uplabel.Text = btStrs[0];
                        uplabel.Font = new System.Drawing.Font("微软雅黑", 10F);
                        uplabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        if(i == 0)
                        {
                            uplabel.Borders = DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                        }
                        else
                        {
                            uplabel.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                        }
                        this.BigLabel.Add(btStrs[0], uplabel);
                        this.Detail.Controls.Add(uplabel);
                    }

                    DevExpress.XtraReports.UI.XRLabel label = new XRLabel();
                    label.LocationF = new PointF(newX, newY + this.labelHeight);
                    label.WidthF = this.columnsWidth[i];
                    label.HeightF = rowHeight / 2;
                    label.Text = btStrs[1];
                    label.Font = new System.Drawing.Font("微软雅黑", 10F);
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    if(i == 0)
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                    }
                    else
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom;
                    }
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
                    label.Font = new System.Drawing.Font("微软雅黑", 9F);
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    this.Detail.Controls.Add(label);
                    if(i == 0)
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                    }
                    else
                    {
                        label.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                    }
                    newX = newX + label.WidthF;
                }
            }
            this.newY = this.newY + rowHeight;
        }

        #endregion
    }

        //    public VerticalReport()
        //    {
        //        InitializeComponent();
        //        //this.Init();
        //    }

        //    /// <summary>
        //    /// 实验方法
        //    /// </summary>
        //    private void Init()
        //    {
        //        DataTable data = new DataTable();
        //        data.Columns.Add("[dfsdf].[（一）标题一_          1 数据列]");
        //        data.Columns.Add("[dfsdf].[sdfsdfsdfdsfdsf]");
        //        data.Columns.Add("[dfsdf].[（一）标题一_          2 数据列]");
        //        data.Columns.Add("[dfsdf].[（一）标题一_          3 数据列]");
        //        data.Columns.Add("[dfsdf].[（二）标题一_          1 数据列]");
        //        data.Columns.Add("[dfsdf].[（二）标题一_          2 数据列]");
        //        data.Columns.Add("[dfsdf].[（二）标题一_          3 数据列]");
        //        data.Columns.Add("[dfsdf].[（二）标题一_          4 数据列]");
        //        data.Rows.Add("11", "12", "13", "21", "22", "23", "24", "24");
        //        data.Rows.Add("11", "12", "13", "21", "22", "23", "24", "24");
        //        this.Columns = new List<string>() { "项目名称", "项目数据", "项目数据" };
        //        this.txtZBT = "这是主标题";
        //        this.txtFBT = "这是副标题";
        //        this.txtRQ = "这是日期";
        //        this.txtZZJJDM = "这是组织机构代码";
        //        this.txtZZJJMC = "这是组织机构名称";
        //        this.BindData(data,1);
        //        this.CreateDocument();
        //        this.ShowPreview();
        //    }

        //    #region 内部属性

        //    /// <summary>
        //    /// 表格宽度
        //    /// </summary>
        //    private float allWidth
        //    {
        //        get
        //        {
        //            return this.lbZBT.WidthF;
        //        }
        //    }

        //    #endregion

        //    #region 显示设置

        //    /// <summary>
        //    /// 设置报表主标题
        //    /// </summary>
        //    public string txtZBT
        //    {
        //        set
        //        {
        //            this.lbZBT.Text = value;
        //        }
        //    }

        //    /// <summary>
        //    /// 设置报表副标题
        //    /// </summary>
        //    public string txtFBT
        //    {
        //        set
        //        {
        //            this.lbFBT.Text = value;
        //        }
        //    }

        //    /// <summary>
        //    /// 设置报表日期
        //    /// </summary>
        //    public string txtRQ
        //    {
        //        set
        //        {
        //            this.lbRQ.Text = value;
        //        }
        //    }

        //    /// <summary>
        //    /// 设置组织机构代码
        //    /// </summary>
        //    public string txtZZJJDM
        //    {
        //        set
        //        {
        //            this.lbZZJGDM.Text = value;
        //        }
        //    }

        //    /// <summary>
        //    /// 设置组织机构名称
        //    /// </summary>
        //    public string txtZZJJMC
        //    {
        //        set
        //        {
        //            this.lbZZJJMC.Text = value;
        //        }
        //    }

        //    #endregion

        //    #region 显示表格设置

        //    /// <summary>
        //    /// 各列的宽度
        //    /// </summary>
        //    private List<float> columnsWidth;

        //    private List<string> columns;
        //    /// <summary>
        //    /// 设置表格每列名称
        //    /// </summary>
        //    public List<string> Columns
        //    {
        //        set
        //        {
        //            if(value != null && value.Count >= 2)
        //            {
        //                this.columns = value;
        //                this.ColumnsCount = value.Count - 1;
        //                columnsWidth = new List<float>();
        //                int FS = value.Count > 3 ? 3 : value.Count;
        //                columnsWidth.Add(this.allWidth / FS);
        //                for(int i = 1; i < value.Count; i++)
        //                {
        //                    columnsWidth.Add(this.allWidth * (FS - 1) / FS / (value.Count - 1));
        //                }
        //            }
        //            else
        //            {
        //                throw new Exception("列名称设置错误！");
        //            }
        //        }
        //        get
        //        {
        //            return this.columns;
        //        }
        //    }

        //    /// <summary>
        //    /// 共有多少列数据
        //    /// </summary>
        //    private int ColumnsCount;

        //    #endregion

        //    #region 外部方法

        //    /// <summary>
        //    /// 将报表以图片格式返回
        //    /// </summary>
        //    /// <returns></returns>
        //    public Image GenImage()
        //    {
        //        this.CreateDocument();
        //        Directory.CreateDirectory(Application.StartupPath + "\\ReportPreview");
        //        string path = Application.StartupPath + "\\ReportPreview\\" + DateTime.Now.ToString("yyyyMMddhhmmssfffffff") + ".jpg";
        //        this.ExportToImage(path);
        //        return Image.FromFile(path);
        //    }

        //    /// <summary>
        //    /// 绑定报表数据
        //    /// </summary>
        //    /// <param name="data">数据源</param>
        //    public void BindData(DataTable data, int wdCount)
        //    {
        //        DataTable newData = this.updateData(data, wdCount);
        //        if(newData != null && newData.Rows != null && newData.Rows.Count > 0)
        //        {
        //            if(newData.Rows.Count == this.ColumnsCount)
        //            {
        //                this.newY = 0;
        //                this.addRow(this.Columns, RowType.BT);
        //                List<string> addFZ = new List<string>();
        //                foreach(DataColumn col in newData.Columns)
        //                {
        //                    string[] colStrs = col.ColumnName.Split('_');
        //                    string sjStr = "";
        //                    if(colStrs != null && colStrs.Length == 2)
        //                    {
        //                        if(!addFZ.Contains(colStrs[0]))
        //                        {
        //                            List<string> fzColumnsStr = new List<string>();
        //                            fzColumnsStr.Add(colStrs[0]);
        //                            foreach(DataRow row in newData.Rows)
        //                            {
        //                                fzColumnsStr.Add("-");
        //                            }
        //                            this.addRow(fzColumnsStr, RowType.FZ);
        //                            addFZ.Add(colStrs[0]);
        //                        }
        //                        sjStr = colStrs[1];
        //                    }
        //                    else
        //                    {
        //                        sjStr = colStrs[0];
        //                    }
        //                    List<string> sjColumnsStr = new List<string>();
        //                    sjColumnsStr.Add(sjStr);
        //                    foreach(DataRow row in newData.Rows)
        //                    {
        //                        sjColumnsStr.Add(row[col.ColumnName].ToString());
        //                    }
        //                    this.addRow(sjColumnsStr, RowType.SJ);
        //                }
        //                this.CreateDocument();
        //                return;
        //            }
        //        }
        //        throw new Exception("数据列与绑定数据不能相对应！");
        //    }

        //    #endregion

        //    #region 内部方法

        //    /// <summary>
        //    /// 处理data
        //    /// </summary>
        //    /// <param name="oldData"></param>
        //    /// <param name="wdCount"></param>
        //    /// <returns></returns>
        //    public DataTable updateData(DataTable oldData, int wdCount)
        //    {
        //        DataTable newData = new DataTable();
        //        for( int i = 0;i< oldData.Columns.Count ;i++)
        //        {
        //            //if(i + 1 >  wdCount*2 || i % 2 == 0)
        //            if(i + 1 >  wdCount*2)
        //            {
        //                newData.Columns.Add(oldData.Columns[i].ColumnName);
        //            }
        //        }
        //        for(int i = 0; i < oldData.Rows.Count; i++)
        //        {
        //            List<object> newRowList = new List<object>();
        //            for(int j = 0; j < oldData.Columns.Count; j++)
        //            {
        //                //if(j + 1 > wdCount * 2 || j % 2 == 0)
        //                if(j + 1 > wdCount * 2 )
        //                {
        //                    newRowList.Add(oldData.Rows[i][j]);
        //                }
        //            }
        //            DataRow newRow = newData.NewRow();
        //            newRow.ItemArray = newRowList.ToArray();
        //            newData.Rows.Add(newRow);
        //        }
        //        for(int i = 0; i < newData.Columns.Count; i++)
        //        {
        //            string columnName = newData.Columns[i].ColumnName;
        //            if(columnName.IndexOf('[') != -1 && columnName.IndexOf(']') != -1 && columnName.IndexOf('.') != -1)
        //            {
        //                string[] colStrs = columnName.Split('.');
        //                string newColumnName = colStrs[colStrs.Length - 1].Replace("[", "").Replace("]", "");
        //                newData.Columns[i].ColumnName = newColumnName;
        //            }
        //        }
        //        return newData;
        //    }

        //    /// <summary>
        //    /// 现在Y位置
        //    /// </summary>
        //    private float newY = 0;
        //    /// <summary>
        //    /// 增加一行数据
        //    /// </summary>
        //    /// <param name="rowDate"></param>
        //    private void addRow(List<string> rowDate, RowType rowType)
        //    {
        //        float newX = 12.5F;
        //        for(int i = 0; i < this.Columns.Count; i++)
        //        {
        //            DevExpress.XtraReports.UI.XRLabel label = new XRLabel();
        //            label.LocationF = new PointF(newX, newY);
        //            label.WidthF = this.columnsWidth[i];
        //            label.HeightF = 20F;
        //            label.Text = rowDate[i];
        //            label.Font = new System.Drawing.Font("Times New Roman", 9F);
        //            newX = newX + label.WidthF;
        //            label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        //            if(i == 0)
        //            {
        //                label.Borders = DevExpress.XtraPrinting.BorderSide.Top;
        //                switch(rowType)
        //                {
        //                    case RowType.BT:
        //                        label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        //                        break;
        //                    case RowType.FZ:
        //                        label.Font = new Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
        //                        label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        //                        break;
        //                    case RowType.SJ:
        //                        label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                label.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        //            }
        //            this.Detail.Controls.Add(label);
        //        }
        //        this.newY = this.newY + 20;
        //    }

        //    #endregion
        //}
}
