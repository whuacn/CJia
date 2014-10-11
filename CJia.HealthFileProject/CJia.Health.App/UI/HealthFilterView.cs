using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    enum FieldType
    {
        StringType,
        NumberType,
        DateTimeType,
        enumType
    }

    public partial class HealthFilterView : Form
    {

        private DataTable FieldDate;

        private int RowNumber = 2;

        public HealthFilterView()
        {
            InitializeComponent();
            this.FieldDate = this.init();
            this.BindFildDate(this.crtFilterFielt1);
        }

        /// <summary>
        /// 绑定字段
        /// </summary>
        /// <param name="crtlu"></param>
        private void BindFildDate(CJia.Controls.CJiaRTLookUp crtlu)
        {
            crtlu.DataSource = this.FieldDate;
            crtlu.DisplayField = "FieldName";
            crtlu.ValueField = "FieldMark";
        }

        private DataTable init()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FieldName", typeof(string));
            dt.Columns.Add("FieldMark", typeof(string));
            dt.Columns.Add("FieldType", typeof(FieldType));
            dt.Rows.Add("姓名", "PATIENT_NAME", FieldType.StringType);
            dt.Rows.Add("入院次数", "IN_HOSPITAL_TIME", FieldType.NumberType);
            dt.Rows.Add("性别", "GENDER", FieldType.enumType);
            dt.Rows.Add("生日", "BIRTHDAY", FieldType.DateTimeType);
            return dt;
        }

        // 根据FieldMark
        public delegate DataTable ResNoPar(string FieldMark);

        event ResNoPar OnBindData;

        // 过滤字段选择事件
        private void crtFilterFielt_EditValueChanged(object sender, EventArgs e)
        {
            CJia.Controls.CJiaRTLookUp ccb = sender as CJia.Controls.CJiaRTLookUp;
            string rowNumber = ccb.Name.Substring(ccb.Name.Length - 1, 1);
            DataRow[] selectRows = (ccb.DataSource as DataTable).Select(" FieldMark = '" + ccb.DisplayValue.ToString() + "' ");
            if(selectRows != null && selectRows.Length > 0)
            {
                DataRow row = selectRows[0];
                this.ModiyVauleType((FieldType)row["FieldType"], rowNumber);
            }
        }

        // 修改值类型输入框
        private void ModiyVauleType(FieldType fieldType, string rowNumber)
        {
            if(fieldType == FieldType.StringType)
            {

            }
            else if(fieldType == FieldType.NumberType)
            {

            }
            else if(fieldType == FieldType.enumType)
            {

            }
            else if(fieldType == FieldType.DateTimeType)
            {

            }

        }


        /// <summary>
        /// 增加一行
        /// </summary>
        private void AddRow()
        {
            Controls.CJiaRTLookUp crtFilterFielt = new Controls.CJiaRTLookUp();
            Controls.CJiaComboBox ccbTypt = new Controls.CJiaComboBox();
            Controls.CJiaComboBox ccbLiftbracket = new Controls.CJiaComboBox();
            Controls.CJiaComboBox ccbYesNo = new Controls.CJiaComboBox();
            Controls.CJiaTextBox ctbValue_1 = new CJia.Controls.CJiaTextBox();
            Controls.CJiaTextBox ctbValue_2 = new CJia.Controls.CJiaTextBox();
            Controls.CJiaComboBox ccbRightbracket = new CJia.Controls.CJiaComboBox();
            Controls.CJiaComboBox ccbAndOr = new CJia.Controls.CJiaComboBox();
            Controls.CJiaPanel cJiaPanel = new CJia.Controls.CJiaPanel();
            crtFilterFielt.Caption = "";
            crtFilterFielt.DataSource = null;
            crtFilterFielt.DisplayField = "";
            crtFilterFielt.DisplayText = "";
            crtFilterFielt.DisplayValue = "";
            crtFilterFielt.EditValue = "";
            crtFilterFielt.Location = new System.Drawing.Point(54, (this.RowNumber - 1) * 30 + 5);
            crtFilterFielt.Name = "crtFilterFielt" + this.RowNumber.ToString();
            crtFilterFielt.OpenAfterEnter = false;
            crtFilterFielt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            crtFilterFielt.Properties.Appearance.Options.UseFont = true;
            crtFilterFielt.Properties.Appearance.Options.UseTextOptions = true;
            crtFilterFielt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            crtFilterFielt.Properties.Buttons.Clear();
            crtFilterFielt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            crtFilterFielt.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            crtFilterFielt.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            crtFilterFielt.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            crtFilterFielt.Properties.PopupFormMinSize = new System.Drawing.Size(200, 200);
            crtFilterFielt.Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            crtFilterFielt.Properties.PopupSizeable = false;
            crtFilterFielt.Properties.ShowPopupCloseButton = false;
            crtFilterFielt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            crtFilterFielt.ResultRow = null;
            crtFilterFielt.Size = new System.Drawing.Size(129, 22);
            crtFilterFielt.TabIndex = (this.RowNumber * 10) + 1;
            crtFilterFielt.UseRowNumDirectSelect = false;
            crtFilterFielt.UseRowNumLocate = false;
            crtFilterFielt.ValueField = "";
            crtFilterFielt.EditValueChanged += new System.EventHandler(crtFilterFielt_EditValueChanged);
            this.BindFildDate(crtFilterFielt);


            ccbTypt.Location = new System.Drawing.Point(237, (this.RowNumber - 1) * 30 + 5);
            ccbTypt.Name = "ccbTypt" + this.RowNumber.ToString();
            ccbTypt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ccbTypt.Properties.Appearance.Options.UseFont = true;
            ccbTypt.Properties.Buttons.Clear();
            ccbTypt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            ccbTypt.Properties.Items.AddRange(new object[] {
            "等于",
            "包含",
            "之间"});
            ccbTypt.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ccbTypt.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ccbTypt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            ccbTypt.Size = new System.Drawing.Size(56, 22);
            ccbTypt.TabIndex = (this.RowNumber * 10) + 3;
            ccbTypt.SelectedIndexChanged += ccbTypt_SelectedIndexChanged;


            ccbLiftbracket.Location = new System.Drawing.Point(6, (this.RowNumber - 1) * 30 + 5);
            ccbLiftbracket.Name = "ccbLiftbracket" + this.RowNumber.ToString();
            ccbLiftbracket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ccbLiftbracket.Properties.Appearance.Options.UseFont = true;
            ccbLiftbracket.Properties.Buttons.Clear();
            ccbLiftbracket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            ccbLiftbracket.Properties.Items.AddRange(new object[] {
            "",
            "("});
            ccbLiftbracket.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ccbLiftbracket.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ccbLiftbracket.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            ccbLiftbracket.Size = new System.Drawing.Size(42, 22);
            ccbLiftbracket.TabIndex = (this.RowNumber * 10) + 0;


            ccbYesNo.Location = new System.Drawing.Point(189, (this.RowNumber - 1) * 30 + 5);
            ccbYesNo.Name = "ccbYesNo" + this.RowNumber.ToString();
            ccbYesNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ccbYesNo.Properties.Appearance.Options.UseFont = true;
            ccbYesNo.Properties.Buttons.Clear();
            ccbYesNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            ccbYesNo.Properties.Items.AddRange(new object[] {
            "",
            "不"});
            ccbYesNo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ccbYesNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ccbYesNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            ccbYesNo.Size = new System.Drawing.Size(42, 22);
            ccbYesNo.TabIndex = (this.RowNumber * 10) + 2;


            ctbValue_1.Location = new System.Drawing.Point(299, (this.RowNumber - 1) * 30 + 5);
            ctbValue_1.Name = "ctbValue" + this.RowNumber.ToString() + "_1";
            ctbValue_1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            ctbValue_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ctbValue_1.Properties.Appearance.Options.UseBackColor = true;
            ctbValue_1.Properties.Appearance.Options.UseFont = true;
            ctbValue_1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ctbValue_1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ctbValue_1.Size = new System.Drawing.Size(123, 22);
            ctbValue_1.TabIndex = (this.RowNumber * 10) + 4;


            ctbValue_2.Location = new System.Drawing.Point(428, (this.RowNumber - 1) * 30 + 5);
            ctbValue_2.Name = "ctbValue" + this.RowNumber.ToString() + "_2";
            ctbValue_2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            ctbValue_2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ctbValue_2.Properties.Appearance.Options.UseBackColor = true;
            ctbValue_2.Properties.Appearance.Options.UseFont = true;
            ctbValue_2.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ctbValue_2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ctbValue_2.Size = new System.Drawing.Size(123, 22);
            ctbValue_2.TabIndex = (this.RowNumber * 10) + 5;


            ccbRightbracket.Location = new System.Drawing.Point(557, (this.RowNumber - 1) * 30 + 5);
            ccbRightbracket.Name = "ccbRightbracket" + this.RowNumber.ToString();
            ccbRightbracket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ccbRightbracket.Properties.Appearance.Options.UseFont = true;
            ccbRightbracket.Properties.Buttons.Clear();
            ccbRightbracket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            ccbRightbracket.Properties.Items.AddRange(new object[] {
            "",
            ")"});
            ccbRightbracket.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ccbRightbracket.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ccbRightbracket.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            ccbRightbracket.Size = new System.Drawing.Size(42, 22);
            ccbRightbracket.TabIndex = (this.RowNumber * 10) + 6;


            ccbAndOr.Location = new System.Drawing.Point(605, (this.RowNumber - 1) * 30 + 5);
            ccbAndOr.Name = "ccbAndOr" + this.RowNumber.ToString();
            ccbAndOr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            ccbAndOr.Properties.Appearance.Options.UseFont = true;
            ccbAndOr.Properties.Buttons.Clear();
            ccbAndOr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            ccbAndOr.Properties.Items.AddRange(new object[] {
            "",
            "且",
            "或"});
            ccbAndOr.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            ccbAndOr.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            ccbAndOr.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            ccbAndOr.Size = new System.Drawing.Size(45, 22);
            ccbAndOr.TabIndex = (this.RowNumber * 10) + 7;
            ccbAndOr.SelectedIndexChanged += new System.EventHandler(ccbAndOr_SelectedIndexChanged);
            ccbAndOr.Tag = "";


            this.cJiaPanel1.Controls.Add(ccbLiftbracket);
            this.cJiaPanel1.Controls.Add(ccbAndOr);
            this.cJiaPanel1.Controls.Add(crtFilterFielt);
            this.cJiaPanel1.Controls.Add(ccbRightbracket);
            this.cJiaPanel1.Controls.Add(ccbTypt);
            this.cJiaPanel1.Controls.Add(ctbValue_2);
            this.cJiaPanel1.Controls.Add(ccbYesNo);
            this.cJiaPanel1.Controls.Add(ctbValue_1);

            this.cJiaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.RowNumber++;
        }

        // 切或下拉框修改事件
        private void ccbAndOr_SelectedIndexChanged(object sender, EventArgs e)
        {
            CJia.Controls.CJiaComboBox ccb = sender as CJia.Controls.CJiaComboBox;
            string rowNumber = ccb.Name.Substring(ccb.Name.Length - 1, 1);
            if(this.RowNumber == int.Parse(rowNumber) + 1)
            {
                if(this.isSucceed(rowNumber) && ccb.EditValue.ToString() != "")
                {
                    this.AddRow();
                }
                else
                {
                    ccb.EditValue = "";
                }
            }
            else
            {
                if(ccb.Tag.ToString() != "" && ccb.EditValue.ToString() == "")
                {
                    ccb.EditValue = ccb.Tag.ToString();
                }
            }
            ccb.Tag = ccb.EditValue;
        }

        // 判断类型下拉框修改事件
        private void ccbTypt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CJia.Controls.CJiaComboBox ccb = sender as CJia.Controls.CJiaComboBox;
            string rowNumber = ccb.Name.Substring(ccb.Name.Length - 1, 1);
        }

        /// <summary>
        /// 是否成功填写一行数据
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        private bool isSucceed(string rowNumber)
        {
            bool isSucceed = true;
            foreach(Control control in this.cJiaPanel1.Controls)
            {
                if(control.Name == "crtFilterFielt" + rowNumber)
                {
                    CJia.Controls.CJiaRTLookUp crtFilterFielt = control as CJia.Controls.CJiaRTLookUp;
                    if(crtFilterFielt.EditValue == "")
                    {
                        isSucceed = false;
                    }
                }
                if(control.Name == "ccbTypt" + rowNumber)
                {
                    CJia.Controls.CJiaComboBox ccbTypt = control as CJia.Controls.CJiaComboBox;
                    if(ccbTypt.EditValue == null)
                    {
                        isSucceed = false;
                    }
                }
            }
            return isSucceed;
        }

        /// <summary>
        /// 根据控件NAME获取控件
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private object GetControlByName( string controlName)
        {
            object result = null;
            if(this.cJiaPanel1.Controls != null && this.cJiaPanel1.Controls.Count > 0)
            {
                foreach( Control con in this.cJiaPanel1.Controls )
                {
                    if( con.Name == controlName)
                    {
                        result = con;
                    }
                }
                return result;
            }
            return result;
        }

        // 增加dateTime
        private CJia.Controls.CJiaDateTime NewDateTime(int rowNumber, int no)
        {
            Controls.CJiaDateTime cJiaDateTime = new CJia.Controls.CJiaDateTime();
            cJiaDateTime.EditValue = null;
            cJiaDateTime.Location = new System.Drawing.Point(299 + ((no-1) * 129), (this.RowNumber - 1) * 30 + 5);
            cJiaDateTime.Name = "cJiaDateTime" + rowNumber + "_" + no; 
            cJiaDateTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            cJiaDateTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            cJiaDateTime.Properties.Appearance.Options.UseFont = true;
            cJiaDateTime.Properties.Appearance.Options.UseTextOptions = true;
            cJiaDateTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cJiaDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            cJiaDateTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            cJiaDateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            cJiaDateTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            cJiaDateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            cJiaDateTime.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            cJiaDateTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            cJiaDateTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            cJiaDateTime.Properties.ShowToday = false;
            cJiaDateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            cJiaDateTime.Size = new System.Drawing.Size(123, 22);
            cJiaDateTime.TabIndex = rowNumber*10 + no +3;
            return cJiaDateTime;
        }
        

    }

    /// <summary>
    /// 病案过滤赛选条件
    /// </summary>
    public class HealthFilterArgs: EventArgs
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string FieldMark;

        /// <summary>
        /// 返回的数据
        /// </summary>
        public string Data;

    }
}
