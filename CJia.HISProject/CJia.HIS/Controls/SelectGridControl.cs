using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.HIS.Controls
{
    public partial class SelectGridControl : DevExpress.XtraEditors.XtraUserControl
    {

        //// 例 select col1 TEXT,col2 VALUE from where col3 like :1  
        //private string SqlText;

        private DevExpress.XtraEditors.TextEdit textEdit;

        //public DevExpress.XtraEditors.TextEdit[] textEditParameters = null;

        /// <summary>
        /// 是否当绑定控件获得焦点时就显示
        /// true 当绑定控件获得焦点是就显示
        /// false 当控件的text发生改变时发生
        /// </summary>
        private bool IsFoucedShow = false;

        /// <summary>
        /// 初始化查询下拉列表 
        /// </summary>
        /// <param name="textEdit">待绑定的textedit</param>
        public SelectGridControl(DevExpress.XtraEditors.TextEdit textEdit)
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.gvwResult.IndicatorWidth = 30;
            this.BringToFront();
            //this.SqlText = sqlText;
            this.textEdit = textEdit;
            this.textEdit.TextChanged += textEdit_TextChanged;
            this.textEdit.KeyDown += textEdit_KeyDown;
            this.textEdit.GotFocus += textEdit_GotFocus;
            this.textEdit.LostFocus += textEdit_LostFocus;
            this.Visible = false;
        }

        /// <summary>
        /// 初始化查询下拉列表 
        /// </summary>
        /// <param name="textEdit">待绑定的textedit</param>
        /// <param name="isFoucedShow">是否在控件获得焦点是马上显示出下拉列表</param>
        public SelectGridControl(DevExpress.XtraEditors.TextEdit textEdit, bool isFoucedShow)
        {
            InitializeComponent();
            this.IsFoucedShow = isFoucedShow;
            this.BackColor = Color.White;
            this.gvwResult.IndicatorWidth = 30;
            this.BringToFront();
            //this.SqlText = sqlText;
            this.textEdit = textEdit;
            this.textEdit.TextChanged += textEdit_TextChanged;
            this.textEdit.KeyDown += textEdit_KeyDown;
            this.textEdit.GotFocus += textEdit_GotFocus;
            this.textEdit.LostFocus += textEdit_LostFocus;
            this.Visible = false;
        }

        /// <summary>
        /// 为下拉列表绑定数据源
        /// </summary>
        public object DataSource
        {
            get
            {
                return this.gctResult.DataSource;
            }
            set
            {
                this.gctResult.DataSource = value;
            }
        }

        //绑定控件的键盘单机时
        void textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Down:
                    this.Focus();
                    break;
                default:
                    break;
            }
        }

        //绑定控件获得焦点时
        void textEdit_GotFocus(object sender, EventArgs e)
        {
            if(this.IsFoucedShow)
            {
                this.Show();
            }
        }

        //显示该控件
        private void Show()
        {
            this.BringToFront();
            this.Visible = true;
            this.gctResult.BringToFront();
            this.textEdit.Parent.FindForm();
            this.Location = new Point(this.textEdit.Location.X, this.textEdit.Location.Y + 20);
        }

        //绑定控件失去焦点时
        void textEdit_LostFocus(object sender, EventArgs e)
        {
            if(this.Focused != true)
            {
                this.Visible = false;
            }
        }

        //绑定控件文本改变时
        void textEdit_TextChanged(object sender, EventArgs e)
        {
            this.Show();
        }

        //查询到结果
        //private DataTable Select(string parameter)
        //{
        //    parameter = parameter.ToUpper();
        //    DataTable allResult = new DataTable();
        //    DataColumn textCol = new DataColumn("TEXT");
        //    DataColumn valueCol = new DataColumn("VALUE");
        //    allResult.Columns.Add(textCol);
        //    allResult.Columns.Add(valueCol);
        //    allResult.PrimaryKey = new DataColumn[] { valueCol };
        //    object[] parameters = new object[] { textEditParameters.Length + 1 };
        //    for(int i = 0; i < textEditParameters.Length; i++)
        //    {
        //        parameters[i] = textEditParameters[i].Tag;
        //    }
        //    string par1 = "%" + parameter + "%";
        //    parameters[textEditParameters.Length] = par1;
        //    DataTable result1 = CJia.DefaultData.Query(this.SqlText, new object[] { par1 });
        //    string par2 = "%";
        //    foreach(char c in parameter)
        //    {
        //        par2 += c.ToString() + "%";
        //    }
        //    par2 += "%";
        //    parameters[textEditParameters.Length] = par2;
        //    DataTable result2 = CJia.DefaultData.Query(this.SqlText, new object[] { par2 });
        //    this.addTable(allResult, result1);
        //    this.addTable(allResult, result2);
        //    return allResult;
        //}

        ///// <summary>
        ///// 将一个datatable加到另一个datatable中 去除重复的信息
        ///// </summary>
        ///// <param name="all">总的datatable</param>
        ///// <param name="add">要加进去的datatable</param>
        //private void addTable(DataTable all, DataTable add)
        //{
        //    object[] obj = new object[all.Columns.Count];
        //    foreach(DataRow row in add.Rows)
        //    {
        //        if(all.Rows.Find( new object[]{row["VALUE"].ToString()}) == null)
        //        {
        //            row.ItemArray.CopyTo(obj, 0);
        //            all.Rows.Add(obj);
        //        }
        //    }
        //}

        //列表的键盘事件
        private void gctResult_KeyDown(object sender, KeyEventArgs e)
        {
            DataRow row = null;
            switch(e.KeyData)
            {
                case Keys.Enter:
                    row = this.gvwResult.GetFocusedDataRow();
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    row = this.gvwResult.GetDataRow(0);
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    row = this.gvwResult.GetDataRow(1);
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    row = this.gvwResult.GetDataRow(2);
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    row = this.gvwResult.GetDataRow(3);
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    row = this.gvwResult.GetDataRow(4);
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    row = this.gvwResult.GetDataRow(5);
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    row = this.gvwResult.GetDataRow(6);
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    row = this.gvwResult.GetDataRow(7);
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    row = this.gvwResult.GetDataRow(8);
                    break;
                case Keys.NumPad0:
                case Keys.D0:
                    row = this.gvwResult.GetDataRow(9);
                    break;
                default:
                    break;
            }
            if(row != null)
            {
                this.textEdit.Text = row["TEXT"].ToString();
                this.textEdit.Tag = row["VALUE"].ToString();
                this.textEdit.Focus();
            }
        }


        // 行号显示
        private void gvwResult_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if(e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }


    }
}
