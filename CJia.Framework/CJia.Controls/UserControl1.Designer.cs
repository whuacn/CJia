namespace CJia.Controls
{
    partial class UserControl1
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
            this.cJiaGridLookUp1 = new CJia.Controls.CJiaGridLookUp();
            this.cJiaGridLookUp1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaGridLookUp1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaGridLookUp1View)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaGridLookUp1
            // 
            this.cJiaGridLookUp1.Location = new System.Drawing.Point(115, 88);
            this.cJiaGridLookUp1.Name = "cJiaGridLookUp1";
            this.cJiaGridLookUp1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cJiaGridLookUp1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaGridLookUp1.Properties.Appearance.Options.UseFont = true;
            this.cJiaGridLookUp1.Properties.Appearance.Options.UseTextOptions = true;
            this.cJiaGridLookUp1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cJiaGridLookUp1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cJiaGridLookUp1.Properties.ImmediatePopup = true;
            this.cJiaGridLookUp1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaGridLookUp1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaGridLookUp1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cJiaGridLookUp1.Properties.PopupFormMinSize = new System.Drawing.Size(150, 150);
            this.cJiaGridLookUp1.Properties.PopupFormSize = new System.Drawing.Size(150, 150);
            this.cJiaGridLookUp1.Properties.ShowFooter = false;
            this.cJiaGridLookUp1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cJiaGridLookUp1.Properties.View = this.cJiaGridLookUp1View;
            this.cJiaGridLookUp1.Size = new System.Drawing.Size(137, 22);
            this.cJiaGridLookUp1.TabIndex = 0;
            // 
            // cJiaGridLookUp1View
            // 
            this.cJiaGridLookUp1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cJiaGridLookUp1View.Name = "cJiaGridLookUp1View";
            this.cJiaGridLookUp1View.OptionsBehavior.AutoPopulateColumns = false;
            this.cJiaGridLookUp1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cJiaGridLookUp1View.OptionsView.ShowGroupPanel = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaGridLookUp1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(615, 432);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaGridLookUp1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaGridLookUp1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CJiaGrid cJiaGrid1;
        private CJiaGridLookUp cJiaGridLookUp1;
        private DevExpress.XtraGrid.Views.Grid.GridView cJiaGridLookUp1View;
    }
}
