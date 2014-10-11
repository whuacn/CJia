namespace CJia.Health.App.UI
{
    partial class CheckReasonView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckReasonView));
            this.txtCheckReason = new System.Windows.Forms.TextBox();
            this.btnPass = new CJia.Controls.BtnSave();
            this.cgCheckReason = new CJia.Controls.CJiaGrid();
            this.gvCheckReason = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddCheckReason = new CJia.Controls.BtnAdd();
            this.btnRemonCheckReason = new CJia.Controls.BtnRemove();
            ((System.ComponentModel.ISupportInitialize)(this.cgCheckReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckReason)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCheckReason
            // 
            this.txtCheckReason.Location = new System.Drawing.Point(8, 9);
            this.txtCheckReason.Name = "txtCheckReason";
            this.txtCheckReason.Size = new System.Drawing.Size(200, 21);
            this.txtCheckReason.TabIndex = 1;
            this.txtCheckReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheckReason_KeyDown);
            // 
            // btnPass
            // 
            this.btnPass.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPass.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnPass.Appearance.Options.UseFont = true;
            this.btnPass.Appearance.Options.UseForeColor = true;
            this.btnPass.CustomText = "确认(F5)";
            this.btnPass.Image = ((System.Drawing.Image)(resources.GetObject("btnPass.Image")));
            this.btnPass.Location = new System.Drawing.Point(297, 375);
            this.btnPass.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnPass.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPass.Name = "btnPass";
            this.btnPass.Selectable = false;
            this.btnPass.Size = new System.Drawing.Size(86, 28);
            this.btnPass.TabIndex = 3;
            this.btnPass.Text = "确认(F5)";
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // cgCheckReason
            // 
            this.cgCheckReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cgCheckReason.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cgCheckReason.IndicatorWidth = 30;
            this.cgCheckReason.Location = new System.Drawing.Point(8, 36);
            this.cgCheckReason.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cgCheckReason.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cgCheckReason.MainView = this.gvCheckReason;
            this.cgCheckReason.Name = "cgCheckReason";
            this.cgCheckReason.ShowRowNumber = true;
            this.cgCheckReason.Size = new System.Drawing.Size(375, 333);
            this.cgCheckReason.TabIndex = 0;
            this.cgCheckReason.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCheckReason});
            this.cgCheckReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cgCheckReason_KeyDown);
            // 
            // gvCheckReason
            // 
            this.gvCheckReason.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.Empty.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.FixedLine.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvCheckReason.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.gvCheckReason.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.FocusedRow.Options.UseFont = true;
            this.gvCheckReason.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvCheckReason.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gvCheckReason.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvCheckReason.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.OddRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvCheckReason.Appearance.OddRow.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvCheckReason.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvCheckReason.Appearance.Preview.Options.UseFont = true;
            this.gvCheckReason.Appearance.Preview.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvCheckReason.Appearance.Row.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.Row.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvCheckReason.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvCheckReason.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvCheckReason.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvCheckReason.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvCheckReason.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvCheckReason.Appearance.VertLine.Options.UseBackColor = true;
            this.gvCheckReason.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvCheckReason.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvCheckReason.GridControl = this.cgCheckReason;
            this.gvCheckReason.IndicatorWidth = 30;
            this.gvCheckReason.Name = "gvCheckReason";
            this.gvCheckReason.OptionsBehavior.Editable = false;
            this.gvCheckReason.OptionsCustomization.AllowFilter = false;
            this.gvCheckReason.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCheckReason.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCheckReason.OptionsView.EnableAppearanceOddRow = true;
            this.gvCheckReason.OptionsView.ShowGroupPanel = false;
            this.gvCheckReason.RowHeight = 25;
            this.gvCheckReason.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCheckReason_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "审核原因";
            this.gridColumn1.FieldName = "CHECK_REASON";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // btnAddCheckReason
            // 
            this.btnAddCheckReason.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAddCheckReason.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAddCheckReason.Appearance.Options.UseFont = true;
            this.btnAddCheckReason.Appearance.Options.UseForeColor = true;
            this.btnAddCheckReason.CustomText = "添加(F6)";
            this.btnAddCheckReason.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCheckReason.Image")));
            this.btnAddCheckReason.Location = new System.Drawing.Point(214, 6);
            this.btnAddCheckReason.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAddCheckReason.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddCheckReason.Name = "btnAddCheckReason";
            this.btnAddCheckReason.Selectable = false;
            this.btnAddCheckReason.Size = new System.Drawing.Size(83, 25);
            this.btnAddCheckReason.TabIndex = 2;
            this.btnAddCheckReason.Text = "添加(F6)";
            this.btnAddCheckReason.Click += new System.EventHandler(this.btnAddCheckReason_Click);
            // 
            // btnRemonCheckReason
            // 
            this.btnRemonCheckReason.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRemonCheckReason.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnRemonCheckReason.Appearance.Options.UseFont = true;
            this.btnRemonCheckReason.Appearance.Options.UseForeColor = true;
            this.btnRemonCheckReason.CustomText = "移除(F7)";
            this.btnRemonCheckReason.Image = ((System.Drawing.Image)(resources.GetObject("btnRemonCheckReason.Image")));
            this.btnRemonCheckReason.Location = new System.Drawing.Point(300, 6);
            this.btnRemonCheckReason.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnRemonCheckReason.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemonCheckReason.Name = "btnRemonCheckReason";
            this.btnRemonCheckReason.Selectable = false;
            this.btnRemonCheckReason.Size = new System.Drawing.Size(83, 25);
            this.btnRemonCheckReason.TabIndex = 4;
            this.btnRemonCheckReason.Text = "移除(F7)";
            this.btnRemonCheckReason.Click += new System.EventHandler(this.btnRemonCheckReason_Click);
            // 
            // CheckReasonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemonCheckReason);
            this.Controls.Add(this.btnAddCheckReason);
            this.Controls.Add(this.cgCheckReason);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.txtCheckReason);
            this.Name = "CheckReasonView";
            this.Size = new System.Drawing.Size(389, 409);
            ((System.ComponentModel.ISupportInitialize)(this.cgCheckReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckReason)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCheckReason;
        private Controls.BtnSave btnPass;
        private Controls.CJiaGrid cgCheckReason;
        private Controls.BtnAdd btnAddCheckReason;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCheckReason;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private Controls.BtnRemove btnRemonCheckReason;

    }
}
