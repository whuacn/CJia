﻿namespace CJia.Health.App.UI
{
    partial class MyPatientInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPatientInputView));
            this.cJiaPanel3 = new CJia.Controls.CJiaPanel();
            this.btnRefresh = new CJia.Controls.BtnRefresh();
            this.ckAll = new CJia.Controls.CJiaCheck();
            this.btnDelete = new CJia.Controls.BtnDelete();
            this.crbCheckState = new CJia.Controls.CJiaRadioBox();
            this.btnUndo = new CJia.Controls.CJiaButton();
            this.btnCommit = new CJia.Controls.CJiaButton();
            this.patientGrid = new CJia.Controls.CJiaGrid();
            this.patientView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckPatient = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel3)).BeginInit();
            this.cJiaPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crbCheckState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaPanel3
            // 
            this.cJiaPanel3.Controls.Add(this.btnRefresh);
            this.cJiaPanel3.Controls.Add(this.ckAll);
            this.cJiaPanel3.Controls.Add(this.btnDelete);
            this.cJiaPanel3.Controls.Add(this.crbCheckState);
            this.cJiaPanel3.Controls.Add(this.btnUndo);
            this.cJiaPanel3.Controls.Add(this.btnCommit);
            this.cJiaPanel3.Controls.Add(this.patientGrid);
            this.cJiaPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cJiaPanel3.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel3.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel3.Name = "cJiaPanel3";
            this.cJiaPanel3.Size = new System.Drawing.Size(1598, 817);
            this.cJiaPanel3.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.CustomText = "刷新(F5)";
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1199, 779);
            this.btnRefresh.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Selectable = false;
            this.btnRefresh.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "刷新(F5)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ckAll
            // 
            this.ckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckAll.Location = new System.Drawing.Point(22, 782);
            this.ckAll.Name = "ckAll";
            this.ckAll.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ckAll.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ckAll.Properties.Appearance.Options.UseBackColor = true;
            this.ckAll.Properties.Appearance.Options.UseFont = true;
            this.ckAll.Properties.Caption = "全选";
            this.ckAll.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ckAll.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ckAll.Selectable = true;
            this.ckAll.Size = new System.Drawing.Size(75, 21);
            this.ckAll.TabIndex = 7;
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.CustomText = "删除(F6)";
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(1297, 779);
            this.btnDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Selectable = false;
            this.btnDelete.Size = new System.Drawing.Size(80, 28);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除(F6)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // crbCheckState
            // 
            this.crbCheckState.EditValue = 100;
            this.crbCheckState.Location = new System.Drawing.Point(2, 8);
            this.crbCheckState.Name = "crbCheckState";
            this.crbCheckState.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.crbCheckState.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.crbCheckState.Properties.Appearance.Options.UseBackColor = true;
            this.crbCheckState.Properties.Appearance.Options.UseFont = true;
            this.crbCheckState.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(104, "已合并未提交"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(103, "已提交未审核")});
            this.crbCheckState.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.crbCheckState.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.crbCheckState.Size = new System.Drawing.Size(296, 33);
            this.crbCheckState.TabIndex = 5;
            this.crbCheckState.SelectedIndexChanged += new System.EventHandler(this.crbCheckState_SelectedIndexChanged);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUndo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnUndo.Appearance.Options.UseFont = true;
            this.btnUndo.Appearance.Options.UseForeColor = true;
            this.btnUndo.CustomText = "撤销提交";
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(1395, 779);
            this.btnUndo.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUndo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Selectable = false;
            this.btnUndo.Size = new System.Drawing.Size(80, 28);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "撤销提交";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCommit.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnCommit.Appearance.Options.UseFont = true;
            this.btnCommit.Appearance.Options.UseForeColor = true;
            this.btnCommit.CustomText = "提交审核";
            this.btnCommit.Location = new System.Drawing.Point(1493, 779);
            this.btnCommit.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnCommit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Selectable = false;
            this.btnCommit.Size = new System.Drawing.Size(80, 28);
            this.btnCommit.TabIndex = 3;
            this.btnCommit.Text = "提交审核";
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // patientGrid
            // 
            this.patientGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientGrid.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.patientGrid.IndicatorWidth = 30;
            this.patientGrid.Location = new System.Drawing.Point(2, 49);
            this.patientGrid.LookAndFeel.SkinName = "Office 2010 Blue";
            this.patientGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.patientGrid.MainView = this.patientView;
            this.patientGrid.Name = "patientGrid";
            this.patientGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ckPatient,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.patientGrid.ShowRowNumber = true;
            this.patientGrid.Size = new System.Drawing.Size(1594, 719);
            this.patientGrid.TabIndex = 1;
            this.patientGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.patientView});
            // 
            // patientView
            // 
            this.patientView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.patientView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.patientView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.patientView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.patientView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.patientView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.patientView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.patientView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.patientView.Appearance.Empty.Options.UseBackColor = true;
            this.patientView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.EvenRow.Options.UseBackColor = true;
            this.patientView.Appearance.EvenRow.Options.UseBorderColor = true;
            this.patientView.Appearance.EvenRow.Options.UseForeColor = true;
            this.patientView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.patientView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.patientView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.patientView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.patientView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.patientView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.patientView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.patientView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.FixedLine.Options.UseBackColor = true;
            this.patientView.Appearance.FixedLine.Options.UseBorderColor = true;
            this.patientView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.patientView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.patientView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.patientView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.patientView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            this.patientView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.patientView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.patientView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.patientView.Appearance.FocusedRow.Options.UseFont = true;
            this.patientView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.patientView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.patientView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.patientView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.patientView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.GroupButton.Options.UseBackColor = true;
            this.patientView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.patientView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.patientView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.patientView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.patientView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.patientView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.patientView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.patientView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.GroupRow.Options.UseBackColor = true;
            this.patientView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.patientView.Appearance.GroupRow.Options.UseForeColor = true;
            this.patientView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.patientView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.patientView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.patientView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.patientView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.patientView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.patientView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.patientView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.patientView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.HorzLine.Options.UseBackColor = true;
            this.patientView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.OddRow.Options.UseBackColor = true;
            this.patientView.Appearance.OddRow.Options.UseBorderColor = true;
            this.patientView.Appearance.OddRow.Options.UseForeColor = true;
            this.patientView.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.patientView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.patientView.Appearance.Preview.Options.UseFont = true;
            this.patientView.Appearance.Preview.Options.UseForeColor = true;
            this.patientView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.patientView.Appearance.Row.Options.UseBackColor = true;
            this.patientView.Appearance.Row.Options.UseForeColor = true;
            this.patientView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.patientView.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.patientView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.patientView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.patientView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.patientView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.patientView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.patientView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.patientView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.patientView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.patientView.Appearance.VertLine.Options.UseBackColor = true;
            this.patientView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.patientView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.patientView.GridControl = this.patientGrid;
            this.patientView.IndicatorWidth = 30;
            this.patientView.Name = "patientView";
            this.patientView.OptionsCustomization.AllowFilter = false;
            this.patientView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.patientView.OptionsSelection.MultiSelect = true;
            this.patientView.OptionsView.EnableAppearanceEvenRow = true;
            this.patientView.OptionsView.EnableAppearanceOddRow = true;
            this.patientView.OptionsView.ShowGroupPanel = false;
            this.patientView.RowHeight = 25;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.ColumnEdit = this.ckPatient;
            this.gridColumn1.FieldName = "ISCHECK";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // ckPatient
            // 
            this.ckPatient.AutoHeight = false;
            this.ckPatient.Name = "ckPatient";
            this.ckPatient.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "病案号";
            this.gridColumn2.FieldName = "RECORDNO";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 98;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "病人ID";
            this.gridColumn3.FieldName = "PATIENT_ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 98;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "入院次数";
            this.gridColumn4.FieldName = "IN_HOSPITAL_TIME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 56;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "病人姓名";
            this.gridColumn5.FieldName = "PATIENT_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "性别";
            this.gridColumn6.FieldName = "GENDER_NAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 53;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "入院日期";
            this.gridColumn7.FieldName = "IN_HOSPITAL_DATE";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 103;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "入院科室";
            this.gridColumn8.FieldName = "IN_HOSPITAL_DEPT_NAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 103;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "入院医生";
            this.gridColumn9.FieldName = "IN_HOSPITAL_DOCTOR_NAME";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 103;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "出院日期";
            this.gridColumn10.FieldName = "OUT_HOSPITAL_DATE";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 103;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "出院科室";
            this.gridColumn11.FieldName = "OUT_HOSPITAL_DEPT_NAME";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 103;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "出院医生";
            this.gridColumn12.FieldName = "OUT_HOSPITAL_DOCTOR_NAME";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 103;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "信息录入人";
            this.gridColumn13.FieldName = "PAT_COMMIT_NAME";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            this.gridColumn13.Width = 117;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "录入时间";
            this.gridColumn14.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn14.FieldName = "PAT_COMMIT_DATE";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            this.gridColumn14.Width = 112;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "病案最后录入人";
            this.gridColumn15.FieldName = "PIC_COMMIT_NAME";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 14;
            this.gridColumn15.Width = 113;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "最后录入时间";
            this.gridColumn16.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn16.FieldName = "PIC_COMMIT_DATE";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 15;
            this.gridColumn16.Width = 144;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "最后提交审核时间";
            this.gridColumn17.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn17.FieldName = "PAT_REVIEW_DATE";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 16;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // MyPatientInputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaPanel3);
            this.Name = "MyPatientInputView";
            this.Size = new System.Drawing.Size(1598, 817);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel3)).EndInit();
            this.cJiaPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crbCheckState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPanel cJiaPanel3;
        private Controls.BtnDelete btnDelete;
        private Controls.CJiaRadioBox crbCheckState;
        private Controls.CJiaButton btnUndo;
        private Controls.CJiaButton btnCommit;
        private Controls.CJiaGrid patientGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView patientView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckPatient;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Controls.CJiaCheck ckAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private Controls.BtnRefresh btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}
