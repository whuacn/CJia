namespace CJia.Health.App.UI
{
    partial class HealthFilterView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.crtFilterFielt1 = new CJia.Controls.CJiaRTLookUp();
            this.ccbTypt1 = new CJia.Controls.CJiaComboBox();
            this.ccbLiftbracket1 = new CJia.Controls.CJiaComboBox();
            this.ccbYesNo1 = new CJia.Controls.CJiaComboBox();
            this.ctbValue1_1 = new CJia.Controls.CJiaTextBox();
            this.ctbValue1_2 = new CJia.Controls.CJiaTextBox();
            this.ccbRightbracket1 = new CJia.Controls.CJiaComboBox();
            this.ccbAndOr1 = new CJia.Controls.CJiaComboBox();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cJiaDateTime1 = new CJia.Controls.CJiaDateTime();
            this.cJiaDateTime2 = new CJia.Controls.CJiaDateTime();
            ((System.ComponentModel.ISupportInitialize)(this.crtFilterFielt1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbTypt1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbLiftbracket1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbYesNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctbValue1_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctbValue1_2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbRightbracket1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbAndOr1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // crtFilterFielt1
            // 
            this.crtFilterFielt1.Caption = "";
            this.crtFilterFielt1.DataSource = null;
            this.crtFilterFielt1.DisplayField = "";
            this.crtFilterFielt1.DisplayText = "";
            this.crtFilterFielt1.DisplayValue = "";
            this.crtFilterFielt1.EditValue = "";
            this.crtFilterFielt1.Location = new System.Drawing.Point(54, 5);
            this.crtFilterFielt1.Name = "crtFilterFielt1";
            this.crtFilterFielt1.OpenAfterEnter = false;
            this.crtFilterFielt1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.crtFilterFielt1.Properties.Appearance.Options.UseFont = true;
            this.crtFilterFielt1.Properties.Appearance.Options.UseTextOptions = true;
            this.crtFilterFielt1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.crtFilterFielt1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.crtFilterFielt1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.crtFilterFielt1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.crtFilterFielt1.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.crtFilterFielt1.Properties.PopupFormMinSize = new System.Drawing.Size(200, 200);
            this.crtFilterFielt1.Properties.PopupFormSize = new System.Drawing.Size(200, 200);
            this.crtFilterFielt1.Properties.PopupSizeable = false;
            this.crtFilterFielt1.Properties.ShowPopupCloseButton = false;
            this.crtFilterFielt1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.crtFilterFielt1.ResultRow = null;
            this.crtFilterFielt1.Size = new System.Drawing.Size(129, 22);
            this.crtFilterFielt1.TabIndex = 0;
            this.crtFilterFielt1.UseRowNumDirectSelect = false;
            this.crtFilterFielt1.UseRowNumLocate = false;
            this.crtFilterFielt1.ValueField = "";
            this.crtFilterFielt1.EditValueChanged += new System.EventHandler(this.crtFilterFielt_EditValueChanged);
            // 
            // ccbTypt1
            // 
            this.ccbTypt1.Location = new System.Drawing.Point(237, 5);
            this.ccbTypt1.Name = "ccbTypt1";
            this.ccbTypt1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ccbTypt1.Properties.Appearance.Options.UseFont = true;
            this.ccbTypt1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.ccbTypt1.Properties.Items.AddRange(new object[] {
            "等于",
            "包含",
            "之间"});
            this.ccbTypt1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ccbTypt1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ccbTypt1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ccbTypt1.Size = new System.Drawing.Size(56, 22);
            this.ccbTypt1.TabIndex = 4;
            this.ccbTypt1.SelectedIndexChanged += new System.EventHandler(this.ccbTypt_SelectedIndexChanged);
            // 
            // ccbLiftbracket1
            // 
            this.ccbLiftbracket1.Location = new System.Drawing.Point(6, 5);
            this.ccbLiftbracket1.Name = "ccbLiftbracket1";
            this.ccbLiftbracket1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ccbLiftbracket1.Properties.Appearance.Options.UseFont = true;
            this.ccbLiftbracket1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.ccbLiftbracket1.Properties.Items.AddRange(new object[] {
            "",
            "("});
            this.ccbLiftbracket1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ccbLiftbracket1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ccbLiftbracket1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ccbLiftbracket1.Size = new System.Drawing.Size(42, 22);
            this.ccbLiftbracket1.TabIndex = 5;
            // 
            // ccbYesNo1
            // 
            this.ccbYesNo1.Location = new System.Drawing.Point(189, 5);
            this.ccbYesNo1.Name = "ccbYesNo1";
            this.ccbYesNo1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ccbYesNo1.Properties.Appearance.Options.UseFont = true;
            this.ccbYesNo1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.ccbYesNo1.Properties.Items.AddRange(new object[] {
            "",
            "不"});
            this.ccbYesNo1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ccbYesNo1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ccbYesNo1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ccbYesNo1.Size = new System.Drawing.Size(42, 22);
            this.ccbYesNo1.TabIndex = 6;
            // 
            // ctbValue1_1
            // 
            this.ctbValue1_1.Location = new System.Drawing.Point(299, 5);
            this.ctbValue1_1.Name = "ctbValue1_1";
            this.ctbValue1_1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.ctbValue1_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctbValue1_1.Properties.Appearance.Options.UseBackColor = true;
            this.ctbValue1_1.Properties.Appearance.Options.UseFont = true;
            this.ctbValue1_1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ctbValue1_1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ctbValue1_1.Size = new System.Drawing.Size(123, 22);
            this.ctbValue1_1.TabIndex = 7;
            // 
            // ctbValue1_2
            // 
            this.ctbValue1_2.Location = new System.Drawing.Point(428, 5);
            this.ctbValue1_2.Name = "ctbValue1_2";
            this.ctbValue1_2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.ctbValue1_2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctbValue1_2.Properties.Appearance.Options.UseBackColor = true;
            this.ctbValue1_2.Properties.Appearance.Options.UseFont = true;
            this.ctbValue1_2.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ctbValue1_2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ctbValue1_2.Size = new System.Drawing.Size(123, 22);
            this.ctbValue1_2.TabIndex = 8;
            // 
            // ccbRightbracket1
            // 
            this.ccbRightbracket1.Location = new System.Drawing.Point(557, 5);
            this.ccbRightbracket1.Name = "ccbRightbracket1";
            this.ccbRightbracket1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ccbRightbracket1.Properties.Appearance.Options.UseFont = true;
            this.ccbRightbracket1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.ccbRightbracket1.Properties.Items.AddRange(new object[] {
            "",
            ")"});
            this.ccbRightbracket1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ccbRightbracket1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ccbRightbracket1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ccbRightbracket1.Size = new System.Drawing.Size(42, 22);
            this.ccbRightbracket1.TabIndex = 9;
            // 
            // ccbAndOr1
            // 
            this.ccbAndOr1.Location = new System.Drawing.Point(605, 5);
            this.ccbAndOr1.Name = "ccbAndOr1";
            this.ccbAndOr1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ccbAndOr1.Properties.Appearance.Options.UseFont = true;
            this.ccbAndOr1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.ccbAndOr1.Properties.Items.AddRange(new object[] {
            "",
            "且",
            "或"});
            this.ccbAndOr1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ccbAndOr1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ccbAndOr1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ccbAndOr1.Size = new System.Drawing.Size(45, 22);
            this.ccbAndOr1.TabIndex = 10;
            this.ccbAndOr1.SelectedIndexChanged += new System.EventHandler(this.ccbAndOr_SelectedIndexChanged);
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Controls.Add(this.cJiaDateTime2);
            this.cJiaPanel1.Controls.Add(this.cJiaDateTime1);
            this.cJiaPanel1.Controls.Add(this.ccbLiftbracket1);
            this.cJiaPanel1.Controls.Add(this.ccbAndOr1);
            this.cJiaPanel1.Controls.Add(this.crtFilterFielt1);
            this.cJiaPanel1.Controls.Add(this.ccbRightbracket1);
            this.cJiaPanel1.Controls.Add(this.ccbTypt1);
            this.cJiaPanel1.Controls.Add(this.ctbValue1_2);
            this.cJiaPanel1.Controls.Add(this.ccbYesNo1);
            this.cJiaPanel1.Controls.Add(this.ctbValue1_1);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(658, 483);
            this.cJiaPanel1.TabIndex = 11;
            // 
            // cJiaDateTime1
            // 
            this.cJiaDateTime1.EditValue = null;
            this.cJiaDateTime1.Location = new System.Drawing.Point(299, 34);
            this.cJiaDateTime1.Name = "cJiaDateTime1";
            this.cJiaDateTime1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cJiaDateTime1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaDateTime1.Properties.Appearance.Options.UseFont = true;
            this.cJiaDateTime1.Properties.Appearance.Options.UseTextOptions = true;
            this.cJiaDateTime1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cJiaDateTime1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cJiaDateTime1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.cJiaDateTime1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cJiaDateTime1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.cJiaDateTime1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cJiaDateTime1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaDateTime1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaDateTime1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.cJiaDateTime1.Properties.ShowToday = false;
            this.cJiaDateTime1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cJiaDateTime1.Size = new System.Drawing.Size(123, 22);
            this.cJiaDateTime1.TabIndex = 11;
            // 
            // cJiaDateTime2
            // 
            this.cJiaDateTime2.EditValue = null;
            this.cJiaDateTime2.Location = new System.Drawing.Point(428, 34);
            this.cJiaDateTime2.Name = "cJiaDateTime2";
            this.cJiaDateTime2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cJiaDateTime2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaDateTime2.Properties.Appearance.Options.UseFont = true;
            this.cJiaDateTime2.Properties.Appearance.Options.UseTextOptions = true;
            this.cJiaDateTime2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cJiaDateTime2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cJiaDateTime2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.cJiaDateTime2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cJiaDateTime2.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.cJiaDateTime2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cJiaDateTime2.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaDateTime2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaDateTime2.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.cJiaDateTime2.Properties.ShowToday = false;
            this.cJiaDateTime2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cJiaDateTime2.Size = new System.Drawing.Size(123, 22);
            this.cJiaDateTime2.TabIndex = 12;
            // 
            // HealthFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 483);
            this.Controls.Add(this.cJiaPanel1);
            this.Name = "HealthFilterView";
            ((System.ComponentModel.ISupportInitialize)(this.crtFilterFielt1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbTypt1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbLiftbracket1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbYesNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctbValue1_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctbValue1_2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbRightbracket1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbAndOr1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaDateTime2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaRTLookUp crtFilterFielt1;
        private Controls.CJiaComboBox ccbTypt1;
        private Controls.CJiaComboBox ccbLiftbracket1;
        private Controls.CJiaComboBox ccbYesNo1;
        private Controls.CJiaTextBox ctbValue1_1;
        private Controls.CJiaTextBox ctbValue1_2;
        private Controls.CJiaComboBox ccbRightbracket1;
        private Controls.CJiaComboBox ccbAndOr1;
        private Controls.CJiaPanel cJiaPanel1;
        private Controls.CJiaDateTime cJiaDateTime1;
        private Controls.CJiaDateTime cJiaDateTime2;

    }
}
