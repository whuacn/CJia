using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 实时搜索控件
    /// </summary>
    public class CJiaGridSearch : CJiaGrid
    {

        #region 属性

        private Control bindTextBox;
        /// <summary>
        /// 该控件绑定的控件
        /// </summary>
        public Control BindTextBox
        {
            get
            {
                return bindTextBox;
            }
            set
            {
                this.bindTextBox = value;
                if(this.bindTextBox != null)
                {
                    this.bindTextBox.TextChanged += BindTextBox_TextChanged;
                    this.bindTextBox.LostFocus += BindTextBox_LostFocus;
                    this.bindTextBox.PreviewKeyDown += bindTextBox_PreviewKeyDown;
                }
            }
        }

        private bool isFoucs;
        /// <summary>
        /// 是否是焦点
        /// </summary>
        private bool IsFoucs
        {
            get
            {
                return this.isFoucs;
            }
            set
            {
                this.isFoucs = value;
                if(this.isFoucs == true)
                {
                    this.Focus();
                }
            }
        }

        private string[] textCels;
        /// <summary>
        /// 显示列 多显示列  显示列将以“，”分割的形式赋值到 绑定控件的text属性中
        /// </summary>
        public string[] TextCels
        {
            get
            {
                return this.textCels;
            }
            set
            {
                this.textCels = value;
                this.InitGridView();
            }
        }

        private string textCel;
        /// <summary>
        /// 单显示列 显示列将绑定到控件的text属性中
        /// </summary>
        public string TextCel
        {
            get
            {
                return this.textCel;
            }
            set
            {
                this.textCel = value;
                this.InitGridView();
            }
        }

        /// <summary>
        /// 对应的值列  多值列  多值将以object数组赋值到 绑定控件的Tag属性中
        /// </summary>
        public string[] ValueCels;

        /// <summary>
        /// 单值列 值将赋值到 绑定控件的Tag属性中
        /// </summary>
        public string ValueCel;

        /// <summary>
        /// 是否是控件赋值使绑定的输入框text改变
        /// </summary>
        public bool SetValue;

        #endregion

        /// <summary>
        /// 初始化方法
        /// </summary>
        public CJiaGridSearch()
        {
            this.IndicatorWidth = 30;
            this.GotFocus += CJiaSearch_GotFocus;
            this.PreviewKeyDown += CJiaSearch_PreviewKeyDown;
            this.gridView1.DoubleClick += gridView1_DoubleClick;
            this.Visible = false;
        }

        #region 事件绑定方法

        //绑定输入框文字发生改变
        void BindTextBox_TextChanged(object sender, EventArgs e)
        {
            if(this.SetValue)
            {
                this.SetValue = false;
            }
            else
            {
                if(this.BindTextBox.Text != "")
                {
                    CJiaSearchEventArgs cJiaSearchEventArgs = new CJiaSearchEventArgs()
                    {
                        SearchValue = this.BindTextBox.Text
                    };
                    this.GetData(this, cJiaSearchEventArgs);
                    this.Visible = true;
                }
            }
        }

        //绑定输入框失去焦点
        void BindTextBox_LostFocus(object sender, EventArgs e)
        {
            if(!this.IsFoucs)
            {
                this.Visible = false;
            }
        }

        //绑定输入框按键事件
        void bindTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyData == Keys.Enter )
            {
                this.IsFoucs = true;
                DataRow r = this.gridView1.GetFocusedDataRow();
                this.SetValue = true;
                this.SetBindTextBox(r);
                this.BindTextBox.Focus();
                this.Visible = false;
            }
            if(e.KeyData == Keys.Down)
            {
                this.IsFoucs = true;
                this.gridView1.MoveNext();
            }
        }

        //控件获得焦点时
        void CJiaSearch_GotFocus(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        string allNumber = "";
        //控件按键事件
        void CJiaSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int keyInt = this.KeysToInt(e.KeyData);
            if(keyInt == -1)
            {
                allNumber = "";
                if(e.KeyData == Keys.Space || e.KeyData == Keys.Enter)
                {
                    DataRow r = this.gridView1.GetFocusedDataRow();
                    this.SetValue = true;
                    this.SetBindTextBox(r);
                    this.BindTextBox.Focus();
                    this.Visible = false;
                }
            }
            else
            {
                allNumber += keyInt;
            }
            if(allNumber != "")
            {
                int allInt = int.Parse(allNumber);
                this.gridView1.MoveFirst();
                this.gridView1.MoveBy(allInt - 1);
            }
        }

        //鼠标双击事件
        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow r = this.gridView1.GetFocusedDataRow();
            this.SetValue = true;
            this.SetBindTextBox(r);
            this.BindTextBox.Focus();
            this.Visible = false;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将建值转化成对应的数字
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns> -1 为不是数字控件</returns>
        private int KeysToInt(Keys keyData)
        {
            int value = -1;
            switch(keyData)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    value = 0;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    value = 1;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    value = 2;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    value = 3;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    value = 4;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    value = 5;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    value = 6;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    value = 7;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    value = 8;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    value = 9;
                    break;
            }
            return value;
        }

        /// <summary>
        /// 给绑定的控件赋值
        /// </summary>
        /// <param name="row"></param>
        private void SetBindTextBox(DataRow row)
        {
            StringBuilder text = new StringBuilder("");
            if(!string.IsNullOrEmpty(this.TextCel))
            {
                text.Append(row[this.TextCel].ToString());
                text.Append(",");
            }
            if(this.TextCels != null && this.TextCels.Length != 0)
            {
                foreach(string str in this.TextCels)
                {
                    text.Append(row[str].ToString());
                    text.Append(",");
                }
            }
            text.Remove(text.Length - 1, 1);
            this.BindTextBox.Text = text.ToString();

            List<object> value = new List<object>();
            if(!string.IsNullOrEmpty(this.TextCel))
            {
                value.Add(row[this.ValueCel]);
            }
            if(this.ValueCels != null && this.TextCels.Length != 0)
            {
                foreach(string str in this.TextCels)
                {
                    value.Add(row[str]);
                }
            }
            this.BindTextBox.Tag = value.ToArray();
        }

        /// <summary>
        /// 初始化gridView
        /// </summary>
        private void InitGridView()
        {
            this.gridView1.Columns.Clear();
            if(this.textCel != null && this.textCel != "")
            {
                DevExpress.XtraGrid.Columns.GridColumn gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
                gridColumn.Caption = this.textCel;
                gridColumn.FieldName = this.textCel;
                gridColumn.Name = "gridColumn";
                gridColumn.Visible = true;
                this.gridView1.Columns.Add(gridColumn);
            }
            if(this.textCels != null && this.textCels.Length != 0)
            {
                foreach(string str in this.textCels)
                {
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
                    gridColumn.Caption = str;
                    gridColumn.FieldName = str;
                    gridColumn.Name = str;
                    gridColumn.Visible = true;
                    this.gridView1.Columns.Add(gridColumn);
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 获取数据方法
        /// </summary>
        public event EventHandler<CJiaSearchEventArgs> GetData;

        #endregion

    }

    /// <summary>
    /// 搜索控件获取数据事件   在该事件绑定方法中需要给控件的DataSource赋值
    /// </summary>
    public class CJiaSearchEventArgs : EventArgs
    {
        /// <summary>
        /// 搜索值
        /// </summary>
       public string SearchValue;
    }
}
