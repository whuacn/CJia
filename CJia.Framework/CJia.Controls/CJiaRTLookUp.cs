using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace CJia.Controls
{
    /// <summary>
    /// 实时查询下拉框
    /// </summary>
    public class CJiaRTLookUp : DevExpress.XtraEditors.PopupContainerEdit
    {
        DevExpress.XtraEditors.PopupContainerControl popupControl;
        CJia.Controls.CJiaGrid gridData;
        DevExpress.XtraGrid.Views.Grid.GridView viewData;
        DevExpress.XtraGrid.Columns.GridColumn gridColumn;
        /// <summary>
        /// CJiaRTLookUp 构造函数
        /// </summary>
        public CJiaRTLookUp()
        {
            popupControl = new DevExpress.XtraEditors.PopupContainerControl();
            gridData = new CJiaGrid();
            gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            // 
            // popupControl
            // 
            this.popupControl.Controls.Add(this.gridData);
            //
            //gridData
            //
            gridData.Dock = DockStyle.Fill;
            gridData.Name = "cJiaGrid1";
            gridData.ShowRowNumber = false;
            gridData.IndicatorWidth = 20;
            //
            //viewData
            //
            viewData = gridData.gridView1;
            viewData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn});
            viewData.DoubleClick += viewData_DoubleClick;
            viewData.KeyDown += viewData_KeyDown;
            //
            //viewData.Click += viewData_Click;
            //viewData.FocusedRowChanged += viewData_FocusedRowChanged;
            //gridColumn
            //
            gridColumn.Name = "gridColumn1";
            gridColumn.Visible = true;
            // 
            // CJiaRTLookUp
            // 
            #region CJiaRTLookUp
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Appearance.Options.UseTextOptions = true;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            //Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            Properties.PopupControl = this.popupControl;
            Properties.PopupFormMinSize = new System.Drawing.Size(200, 200);
            Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            //Properties.PopupSizeable = false;
            //Properties.ShowPopupCloseButton = false;
            Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Size = new System.Drawing.Size(200, 22);
            Text = "";

            Enter += CJiaRTLookUp_Enter;
            Popup += CJiaRTLookUp_Popup;
            KeyDown += CJiaRTLookUp_KeyDown;
            TextChanged += CJiaRTLookUp_TextChanged;

            //SizeChanged += CJiaRTLookUp_SizeChanged;
            #endregion
        }

        void CJiaRTLookUp_TextChanged(object sender, EventArgs e)
        {
            this.isRTLookUpEnter = false;
        }

        void CJiaRTLookUp_SizeChanged(object sender, EventArgs e)
        {
            Properties.PopupFormMinSize = new System.Drawing.Size(this.Width, this.Width);
            Properties.PopupFormSize = new System.Drawing.Size(this.Width, this.Width);
        }

        void viewData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetMoveSelectText();
        }

        void BindData()
        {
            if (this.isRTLookUpEnter)
            {
                this.isRTLookUpEnter = false;
            }
            else
            {
                if (this.Text != this.displayText)
                {
                    this.displayText = "";
                    this.displayValue = "";
                    this.resultRow = null;
                    this.dataSource = null;
                    CJiaRTLookUpArgs args = new CJiaRTLookUpArgs();
                    args.SearchValue = Text.ToString();
                    if (GetData != null)
                        GetData(null, args);
                    this.ShowPopup();
                    this.isRTLookUpEnter = true;
                }
            }
        }
        private bool isRTLookUpEnter = false;
        void CJiaRTLookUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool bol = this.isRTLookUpEnter;
                BindData();//update by 07-09
                if (this.IsPopupOpen && bol)
                {
                    SetSelectData();
                    this.ClosePopup();
                }
                else
                {
                    this.ShowPopup();
                    this.isRTLookUpEnter = true;
                }
                this.SelectAll();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.ClearContent();
            }
            else
            {
                KeyMoveing(e);
            }
        }

        void CJiaRTLookUp_Popup(object sender, EventArgs e)
        {
            this.Focus();
        }

        void CJiaRTLookUp_Enter(object sender, EventArgs e)
        {
            if (this.openAfterEnter)
            {
                if (!this.IsPopupOpen)
                {
                    this.ShowPopup();
                }
            }
        }

        void viewData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetSelectData();
                this.ClosePopup();
            }
            else
            {
                //OneKeySelect(e);
            }
        }

        void viewData_Click(object sender, EventArgs e)
        {
            SetMoveSelectText();
        }

        void viewData_DoubleClick(object sender, EventArgs e)
        {
            SetSelectData();
            this.ClosePopup();
        }
        //按键上下移动时赋值
        void KeyMoveing(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (this.viewData.RowCount == (this.viewData.FocusedRowHandle + 1))
                    {
                        this.viewData.MoveFirst();
                    }
                    else
                    {
                        this.viewData.FocusedRowHandle++;
                    }
                    break;
                case Keys.Up:
                    if (this.viewData.FocusedRowHandle == 0)
                    {
                        this.viewData.MoveLast();
                    }
                    else
                    {
                        this.viewData.FocusedRowHandle--;
                    }
                    break;
                case Keys.PageDown: this.viewData.MoveNextPage(); break;
                case Keys.PageUp: this.viewData.MovePrevPage(); break;
            }
        }
        //按键上下移动时赋值
        void SetMoveSelectText()
        {
            if (String.IsNullOrEmpty(this.displayField) || String.IsNullOrEmpty(this.valueField)) return;
            if (this.viewData.GetDataRow(this.viewData.FocusedRowHandle) == null) return;
            this.isMoveSelectText = true;
            DataRow drResult = this.viewData.GetDataRow(this.viewData.FocusedRowHandle);
            //this.Text = drResult[this.displayField].ToString();
        }

        void SetData(DataRow dr)
        {
            resultRow = dr;
            this.displayText = dr[this.displayField].ToString();
            this.displayValue = dr[this.valueField].ToString();
            this.Text = this.displayText;
            this.SelectAll();
        }

        void SetSelectData()
        {
            if (String.IsNullOrEmpty(this.displayField) || String.IsNullOrEmpty(this.valueField)) return;
            DataRow drResult = this.viewData.GetDataRow(this.viewData.FocusedRowHandle);
            if (drResult != null)
            {
                SetData(drResult);
                if (this.SelectValueChanged != null)
                {
                    this.SelectValueChanged(this, null);
                }
            }
            else
            {
                ClearContent();
            }
        }
        /// <summary>
        /// 清空内容
        /// </summary>
        public void ClearContent()
        {
            this.displayText = "";
            this.displayValue = "";
            this.Text = "";
            this.resultRow = null;
            this.dataSource = null;
        }
        /// <summary>
        /// 根据gridview行标一键定位到的某列 适用于少量数据1-36
        /// </summary>
        /// <param name="e"></param>
        private void OneKeySelect(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                case Keys.D1: this.viewData.FocusedRowHandle = 0; break;
                case Keys.NumPad2:
                case Keys.D2: this.viewData.FocusedRowHandle = 1; break;
                case Keys.NumPad3:
                case Keys.D3: this.viewData.FocusedRowHandle = 2; break;
                case Keys.NumPad4:
                case Keys.D4: this.viewData.FocusedRowHandle = 3; break;
                case Keys.NumPad5:
                case Keys.D5: this.viewData.FocusedRowHandle = 4; break;
                case Keys.NumPad6:
                case Keys.D6: this.viewData.FocusedRowHandle = 5; break;
                case Keys.NumPad7:
                case Keys.D7: this.viewData.FocusedRowHandle = 6; break;
                case Keys.NumPad8:
                case Keys.D8: this.viewData.FocusedRowHandle = 7; break;
                case Keys.NumPad9:
                case Keys.D9: this.viewData.FocusedRowHandle = 8; break;
                case Keys.NumPad0:
                case Keys.D0: this.viewData.FocusedRowHandle = 9; break;
                case Keys.A: this.viewData.FocusedRowHandle = 10; break;
                case Keys.B: this.viewData.FocusedRowHandle = 11; break;
                case Keys.C: this.viewData.FocusedRowHandle = 12; break;
                case Keys.D: this.viewData.FocusedRowHandle = 13; break;
                case Keys.E: this.viewData.FocusedRowHandle = 14; break;
                case Keys.F: this.viewData.FocusedRowHandle = 15; break;
                case Keys.G: this.viewData.FocusedRowHandle = 16; break;
                case Keys.H: this.viewData.FocusedRowHandle = 17; break;
                case Keys.I: this.viewData.FocusedRowHandle = 18; break;
                case Keys.J: this.viewData.FocusedRowHandle = 19; break;
                case Keys.K: this.viewData.FocusedRowHandle = 20; break;
                case Keys.L: this.viewData.FocusedRowHandle = 21; break;
                case Keys.M: this.viewData.FocusedRowHandle = 22; break;
                case Keys.N: this.viewData.FocusedRowHandle = 23; break;
                case Keys.O: this.viewData.FocusedRowHandle = 24; break;
                case Keys.P: this.viewData.FocusedRowHandle = 25; break;
                case Keys.Q: this.viewData.FocusedRowHandle = 26; break;
                case Keys.R: this.viewData.FocusedRowHandle = 27; break;
                case Keys.S: this.viewData.FocusedRowHandle = 28; break;
                case Keys.T: this.viewData.FocusedRowHandle = 29; break;
                case Keys.U: this.viewData.FocusedRowHandle = 30; break;
                case Keys.V: this.viewData.FocusedRowHandle = 31; break;
                case Keys.W: this.viewData.FocusedRowHandle = 32; break;
                case Keys.X: this.viewData.FocusedRowHandle = 33; break;
                case Keys.Y: this.viewData.FocusedRowHandle = 34; break;
                case Keys.Z: this.viewData.FocusedRowHandle = 35; break;
            }
        }
        #region CJia 属性
        /// <summary>
        /// 是否是下拉框赋的值
        /// </summary>
        private bool isMoveSelectText = false;

        private string caption = string.Empty;
        /// <summary>
        /// 网格中显示的标题
        /// </summary>
        public string Caption
        {
            get { return caption; }
            set { caption = value; gridColumn.Caption = caption; }
        }
        private bool openAfterEnter = false;
        /// <summary>
        /// 标识进入控件后是否立即展开下拉框,默认为False
        /// </summary>
        [Category("CJia 数据绑定"), Description("标识进入控件后是否立即展开下拉框,默认为False")]
        public bool OpenAfterEnter
        {
            get { return openAfterEnter; }
            set { openAfterEnter = value; }
        }

        private DataRow resultRow = null;
        /// <summary>
        /// 结果数据行
        /// </summary>
        [Category("CJia 数据绑定"), Description("结果数据行")]
        public DataRow ResultRow
        {
            get { return resultRow; }
            set { resultRow = null; }
        }

        private DataTable dataSource;
        /// <summary>
        /// 数据源
        /// </summary>
        [Category("CJia 数据绑定"), Description("设置数据源")]
        public DataTable DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                this.gridData.DataSource = dataSource;
            }
        }

        /// <summary>
        /// 数据网格
        /// </summary>
        [Category("CJia 数据绑定"), Description("数据网格")]
        public CJiaGrid DataGrid
        {
            get { return gridData; }
            set { gridData = value; }
        }
        /// <summary>
        /// 数据视图
        /// </summary>
        [Category("ESoSi 数据绑定"), Description("数据视图")]
        public DevExpress.XtraGrid.Views.Grid.GridView DataView
        {
            get { return viewData; }
            set { viewData = value; }
        }
        /// <summary>
        /// 弹出面板
        /// </summary>
        [Category("CJia 数据绑定"), Description("弹出面板")]
        public DevExpress.XtraEditors.PopupContainerControl PopupPanel
        {
            get { return this.popupControl; }
            set { this.popupControl = value; }
        }

        private string displayField = string.Empty;
        /// <summary>
        /// 显示字段
        /// </summary>
        [Category("CJia 数据绑定"), Description("设置显示在输入框中的字段")]
        public string DisplayField
        {
            get { return displayField; }
            set
            {
                displayField = value;
                gridColumn.FieldName = displayField;
            }
        }

        private string valueField = string.Empty;
        /// <summary>
        /// 值字段
        /// </summary>
        [Category("CJia 数据绑定"), Description("设置输入框的值字段")]
        public string ValueField
        {
            get { return valueField; }
            set { valueField = value; }
        }

        private string displayText = string.Empty;
        /// <summary>
        /// 显示文本
        /// </summary>
        [Category("CJia 数据绑定"), Description("显示文本")]
        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

        private string displayValue = string.Empty;
        /// <summary>
        /// 不显示的值
        /// </summary>
        [Category("CJia 数据绑定"), Description("不显示的值")]
        public string DisplayValue
        {
            get { return displayValue; }
            set
            {
                displayValue = value;
                if ((value.Length == 0) || (dataSource == null)) return;
                AutoLocate(value);
            }
        }
        /// <summary>
        /// 自动定位，根据设定的显示值显示对应文本
        /// </summary>
        /// <param name="value"></param>
        private void AutoLocate(string value)
        {
            string strSelect = "";
            if (dataSource.Columns[this.valueField].DataType.ToString() == "System.String")
            {
                strSelect = this.valueField + "='" + value + "'";
            }
            else
            {
                strSelect = this.valueField + "=" + value;
            }
            DataRow[] drs = dataSource.Select(strSelect);
            if (drs.Length > 0)
            {
                SetData(drs[0]);
            }
        }

        private bool useRowNumLocate = false;
        /// <summary>
        /// 使用行号定位，适用于数据量小的下拉框
        /// </summary>
        [Category("CJia 数据绑定"), Description("使用行号定位，适用于数据量小的下拉框")]
        public bool UseRowNumLocate
        {
            get { return useRowNumLocate; }
            set
            {
                useRowNumLocate = value;
            }
        }

        private bool useRowNumDirectSelect = false;
        /// <summary>
        /// 使用行号直接选择，默认是先定位再按回车选择
        /// </summary>
        [Category("ESoSi 数据绑定"), Description("使用行号直接选择，默认是先定位再按回车选择")]
        public bool UseRowNumDirectSelect
        {
            get { return useRowNumDirectSelect; }
            set { useRowNumDirectSelect = value; }
        }
        #endregion
        /// <summary>
        /// 获取数据源方法
        /// </summary>
        [Category("CJia属性"), Description("自定义获取数据源方法")]
        public event EventHandler<CJiaRTLookUpArgs> GetData;

        /// <summary>
        /// DisPlayValue值改变时，触发事件
        /// </summary>
        [Category("CJia属性"), Description("选择值改变触发事件")]
        public event EventHandler SelectValueChanged;

    }
    /// <summary>
    /// 实时查询下拉框参数类
    /// </summary>
    public class CJiaRTLookUpArgs : EventArgs
    {
        /// <summary>
        /// 搜索值
        /// </summary>
        public string SearchValue = string.Empty;
    }
}
