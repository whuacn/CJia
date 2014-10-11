namespace CJia.HISOLAP.App.UI.HQMS
{
    partial class EditCheckScriptView
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCheckScriptView));
            this.lblMeg = new CJia.Controls.CJiaLabel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.txtNO = new CJia.Controls.CJiaTextBox();
            this.btnSave1 = new CJia.Controls.BtnSave();
            this.btnClose1 = new CJia.Controls.BtnClose();
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            this.txtTest = new CJia.Controls.TxtMultiLine();
            this.cJiaLabel3 = new CJia.Controls.CJiaLabel();
            this.txtError = new CJia.Controls.TxtMultiLine();
            this.cJiaLabel4 = new CJia.Controls.CJiaLabel();
            this.cbType = new CJia.Controls.CJiaComboBox2();
            this.cJiaComboBox21View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cJiaLabel5 = new CJia.Controls.CJiaLabel();
            this.txtLevel = new CJia.Controls.CJiaTextBox();
            this.txtClassfiy = new CJia.Controls.CJiaTextBox();
            this.cJiaLabel6 = new CJia.Controls.CJiaLabel();
            this.lblStatus = new CJia.Controls.CJiaLabel();
            this.cbStatus = new CJia.Controls.CJiaComboBox();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtError.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassfiy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMeg
            // 
            this.lblMeg.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblMeg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMeg.Location = new System.Drawing.Point(283, 10);
            this.lblMeg.Name = "lblMeg";
            this.lblMeg.Size = new System.Drawing.Size(114, 23);
            this.lblMeg.TabIndex = 2;
            this.lblMeg.Text = "新增审核脚本";
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(57, 65);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(45, 16);
            this.cJiaLabel1.TabIndex = 3;
            this.cJiaLabel1.Text = "编号：";
            // 
            // txtNO
            // 
            this.txtNO.Location = new System.Drawing.Point(108, 61);
            this.txtNO.Name = "txtNO";
            this.txtNO.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNO.Properties.Appearance.Options.UseBackColor = true;
            this.txtNO.Properties.Appearance.Options.UseFont = true;
            this.txtNO.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtNO.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNO.Size = new System.Drawing.Size(157, 22);
            this.txtNO.TabIndex = 4;
            // 
            // btnSave1
            // 
            this.btnSave1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSave1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSave1.Appearance.Options.UseFont = true;
            this.btnSave1.Appearance.Options.UseForeColor = true;
            this.btnSave1.CustomText = "保存(F8)";
            this.btnSave1.Image = ((System.Drawing.Image)(resources.GetObject("btnSave1.Image")));
            this.btnSave1.Location = new System.Drawing.Point(480, 372);
            this.btnSave1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSave1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Selectable = false;
            this.btnSave1.Size = new System.Drawing.Size(80, 28);
            this.btnSave1.TabIndex = 1;
            this.btnSave1.Text = "保存(F8)";
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // btnClose1
            // 
            this.btnClose1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnClose1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnClose1.Appearance.Options.UseFont = true;
            this.btnClose1.Appearance.Options.UseForeColor = true;
            this.btnClose1.CustomText = "关闭(F4)";
            this.btnClose1.Image = ((System.Drawing.Image)(resources.GetObject("btnClose1.Image")));
            this.btnClose1.Location = new System.Drawing.Point(581, 372);
            this.btnClose1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnClose1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Selectable = false;
            this.btnClose1.Size = new System.Drawing.Size(80, 28);
            this.btnClose1.TabIndex = 0;
            this.btnClose1.Text = "关闭(F4)";
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel2.Location = new System.Drawing.Point(27, 103);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel2.TabIndex = 5;
            this.cJiaLabel2.Text = "审核脚本：";
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(108, 100);
            this.txtTest.Name = "txtTest";
            this.txtTest.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTest.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTest.Properties.Appearance.Options.UseBackColor = true;
            this.txtTest.Properties.Appearance.Options.UseFont = true;
            this.txtTest.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtTest.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTest.Size = new System.Drawing.Size(553, 84);
            this.txtTest.TabIndex = 6;
            // 
            // cJiaLabel3
            // 
            this.cJiaLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel3.Location = new System.Drawing.Point(27, 203);
            this.cJiaLabel3.Name = "cJiaLabel3";
            this.cJiaLabel3.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel3.TabIndex = 7;
            this.cJiaLabel3.Text = "错误提示：";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(108, 201);
            this.txtError.Name = "txtError";
            this.txtError.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtError.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtError.Properties.Appearance.Options.UseBackColor = true;
            this.txtError.Properties.Appearance.Options.UseFont = true;
            this.txtError.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtError.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtError.Size = new System.Drawing.Size(553, 84);
            this.txtError.TabIndex = 8;
            // 
            // cJiaLabel4
            // 
            this.cJiaLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel4.Location = new System.Drawing.Point(27, 303);
            this.cJiaLabel4.Name = "cJiaLabel4";
            this.cJiaLabel4.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel4.TabIndex = 9;
            this.cJiaLabel4.Text = "审核类型：";
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(108, 300);
            this.cbType.Name = "cbType";
            this.cbType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbType.Properties.Appearance.Options.UseFont = true;
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cbType.Properties.ImmediatePopup = true;
            this.cbType.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cbType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbType.Properties.NullText = "";
            this.cbType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cbType.Properties.PopupFormMinSize = new System.Drawing.Size(150, 150);
            this.cbType.Properties.PopupFormSize = new System.Drawing.Size(150, 150);
            this.cbType.Properties.ShowFooter = false;
            this.cbType.Properties.View = this.cJiaComboBox21View;
            this.cbType.Size = new System.Drawing.Size(157, 22);
            this.cbType.TabIndex = 10;
            // 
            // cJiaComboBox21View
            // 
            this.cJiaComboBox21View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.cJiaComboBox21View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cJiaComboBox21View.Name = "cJiaComboBox21View";
            this.cJiaComboBox21View.OptionsBehavior.AutoPopulateColumns = false;
            this.cJiaComboBox21View.OptionsCustomization.AllowFilter = false;
            this.cJiaComboBox21View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cJiaComboBox21View.OptionsView.ShowColumnHeaders = false;
            this.cJiaComboBox21View.OptionsView.ShowGroupPanel = false;
            // 
            // cJiaLabel5
            // 
            this.cJiaLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel5.Location = new System.Drawing.Point(423, 303);
            this.cJiaLabel5.Name = "cJiaLabel5";
            this.cJiaLabel5.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel5.TabIndex = 11;
            this.cJiaLabel5.Text = "审核级别：";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(504, 300);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtLevel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLevel.Properties.Appearance.Options.UseBackColor = true;
            this.txtLevel.Properties.Appearance.Options.UseFont = true;
            this.txtLevel.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtLevel.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtLevel.Size = new System.Drawing.Size(157, 22);
            this.txtLevel.TabIndex = 12;
            // 
            // txtClassfiy
            // 
            this.txtClassfiy.Location = new System.Drawing.Point(108, 341);
            this.txtClassfiy.Name = "txtClassfiy";
            this.txtClassfiy.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtClassfiy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtClassfiy.Properties.Appearance.Options.UseBackColor = true;
            this.txtClassfiy.Properties.Appearance.Options.UseFont = true;
            this.txtClassfiy.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtClassfiy.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtClassfiy.Size = new System.Drawing.Size(157, 22);
            this.txtClassfiy.TabIndex = 14;
            // 
            // cJiaLabel6
            // 
            this.cJiaLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel6.Location = new System.Drawing.Point(27, 344);
            this.cJiaLabel6.Name = "cJiaLabel6";
            this.cJiaLabel6.Size = new System.Drawing.Size(75, 16);
            this.cJiaLabel6.TabIndex = 13;
            this.cJiaLabel6.Text = "错误归类：";
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblStatus.Location = new System.Drawing.Point(453, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 16);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "状态：";
            // 
            // cbStatus
            // 
            this.cbStatus.Location = new System.Drawing.Point(504, 61);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbStatus.Properties.Appearance.Options.UseFont = true;
            this.cbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cbStatus.Properties.Items.AddRange(new object[] {
            "有效",
            "无效"});
            this.cbStatus.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cbStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbStatus.Size = new System.Drawing.Size(157, 22);
            this.cbStatus.TabIndex = 16;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.FieldName = "NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // EditCheckScriptView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtClassfiy);
            this.Controls.Add(this.cJiaLabel6);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.cJiaLabel5);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cJiaLabel4);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.cJiaLabel3);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.txtNO);
            this.Controls.Add(this.cJiaLabel1);
            this.Controls.Add(this.lblMeg);
            this.Controls.Add(this.btnSave1);
            this.Controls.Add(this.btnClose1);
            this.Name = "EditCheckScriptView";
            this.Size = new System.Drawing.Size(680, 421);
            ((System.ComponentModel.ISupportInitialize)(this.txtNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtError.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassfiy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.BtnClose btnClose1;
        private Controls.BtnSave btnSave1;
        private Controls.CJiaLabel lblMeg;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaTextBox txtNO;
        private Controls.CJiaLabel cJiaLabel2;
        private Controls.TxtMultiLine txtTest;
        private Controls.CJiaLabel cJiaLabel3;
        private Controls.TxtMultiLine txtError;
        private Controls.CJiaLabel cJiaLabel4;
        private Controls.CJiaComboBox2 cbType;
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaComboBox21View;
        private Controls.CJiaLabel cJiaLabel5;
        private Controls.CJiaTextBox txtLevel;
        private Controls.CJiaTextBox txtClassfiy;
        private Controls.CJiaLabel cJiaLabel6;
        private Controls.CJiaLabel lblStatus;
        private Controls.CJiaComboBox cbStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
