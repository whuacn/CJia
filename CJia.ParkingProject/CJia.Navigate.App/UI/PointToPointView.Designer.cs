namespace CJia.Navigate.App.UI
{
    partial class PointToPointView
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.cmbEnd = new CJia.Controls.CJiaCheckedComboBox();
            this.cmbStart = new CJia.Controls.CJiaComboBox2();
            this.cJiaComboBox21View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(58, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "起点:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(58, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "终点：";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(161, 183);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // cmbEnd
            // 
            this.cmbEnd.EditValue = "";
            this.cmbEnd.Location = new System.Drawing.Point(116, 90);
            this.cmbEnd.Name = "cmbEnd";
            this.cmbEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbEnd.Properties.Appearance.Options.UseFont = true;
            this.cmbEnd.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbEnd.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.cmbEnd.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.cmbEnd.Properties.AppearanceDropDown.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.cmbEnd.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.cmbEnd.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.cmbEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cmbEnd.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cmbEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbEnd.Properties.PopupFormMinSize = new System.Drawing.Size(160, 150);
            this.cmbEnd.Properties.PopupFormSize = new System.Drawing.Size(160, 150);
            this.cmbEnd.Properties.PopupSizeable = false;
            this.cmbEnd.Properties.SelectAllItemCaption = "(全选)";
            this.cmbEnd.Size = new System.Drawing.Size(287, 22);
            this.cmbEnd.TabIndex = 5;
            // 
            // cmbStart
            // 
            this.cmbStart.Location = new System.Drawing.Point(116, 40);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbStart.Properties.Appearance.Options.UseFont = true;
            this.cmbStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cmbStart.Properties.ImmediatePopup = true;
            this.cmbStart.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cmbStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbStart.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmbStart.Properties.PopupFormMinSize = new System.Drawing.Size(150, 150);
            this.cmbStart.Properties.PopupFormSize = new System.Drawing.Size(150, 150);
            this.cmbStart.Properties.ShowFooter = false;
            this.cmbStart.Properties.View = this.cJiaComboBox21View;
            this.cmbStart.Size = new System.Drawing.Size(160, 22);
            this.cmbStart.TabIndex = 4;
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "点";
            this.gridColumn1.FieldName = "point_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // PointToPointView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.cmbEnd);
            this.Controls.Add(this.cmbStart);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "PointToPointView";
            this.Size = new System.Drawing.Size(445, 312);
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaComboBox21View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Controls.CJiaComboBox2 cmbStart;
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaComboBox21View;
        private Controls.CJiaCheckedComboBox cmbEnd;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
