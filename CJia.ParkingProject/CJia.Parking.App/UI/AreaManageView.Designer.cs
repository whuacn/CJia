namespace CJia.Parking.App.UI
{
    partial class AreaManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaManageView));
            this.gridArea = new DevExpress.XtraGrid.GridControl();
            this.gvwArea = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAreaDelete = new CJia.Controls.BtnDelete();
            this.btnAreaAdd = new CJia.Controls.BtnAdd();
            this.btnAreaSave = new CJia.Controls.BtnSave();
            this.txtAreaNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnFloorDelete = new CJia.Controls.BtnDelete();
            this.btnFloorAdd = new CJia.Controls.BtnAdd();
            this.gridFloor = new DevExpress.XtraGrid.GridControl();
            this.gvwFloor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnFloorSave = new CJia.Controls.BtnSave();
            this.txtFloorNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridPark = new DevExpress.XtraGrid.GridControl();
            this.gvwPark = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnParkDelete = new CJia.Controls.BtnDelete();
            this.btnParkAdd = new CJia.Controls.BtnAdd();
            this.btnParkSave = new CJia.Controls.BtnSave();
            this.pnlFloor = new DevExpress.XtraEditors.GroupControl();
            this.pnlArea = new DevExpress.XtraEditors.GroupControl();
            this.pnlPark = new DevExpress.XtraEditors.GroupControl();
            this.txtCameraNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtParkNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloorNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwPark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFloor)).BeginInit();
            this.pnlFloor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlArea)).BeginInit();
            this.pnlArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPark)).BeginInit();
            this.pnlPark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCameraNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParkNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridArea
            // 
            this.gridArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridArea.Location = new System.Drawing.Point(5, 25);
            this.gridArea.MainView = this.gvwArea;
            this.gridArea.Name = "gridArea";
            this.gridArea.Size = new System.Drawing.Size(322, 482);
            this.gridArea.TabIndex = 31;
            this.gridArea.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwArea});
            // 
            // gvwArea
            // 
            this.gvwArea.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.Window;
            this.gvwArea.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwArea.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.gvwArea.GridControl = this.gridArea;
            this.gvwArea.Name = "gvwArea";
            this.gvwArea.OptionsBehavior.Editable = false;
            this.gvwArea.OptionsView.ShowGroupPanel = false;
            this.gvwArea.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gvwArea_CustomDrawEmptyForeground);
            this.gvwArea.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwArea_FocusedRowChanged);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "区域编号";
            this.gridColumn2.FieldName = "area_no";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "所属楼层";
            this.gridColumn3.FieldName = "floor_no";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // btnAreaDelete
            // 
            this.btnAreaDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAreaDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAreaDelete.Appearance.Options.UseFont = true;
            this.btnAreaDelete.Appearance.Options.UseForeColor = true;
            this.btnAreaDelete.CustomText = "删除(F6)";
            this.btnAreaDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnAreaDelete.Image")));
            this.btnAreaDelete.Location = new System.Drawing.Point(247, 560);
            this.btnAreaDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAreaDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAreaDelete.Name = "btnAreaDelete";
            this.btnAreaDelete.Selectable = false;
            this.btnAreaDelete.Size = new System.Drawing.Size(80, 28);
            this.btnAreaDelete.TabIndex = 13;
            this.btnAreaDelete.Text = "删除(F6)";
            this.btnAreaDelete.Click += new System.EventHandler(this.btnAreaDelete_Click);
            // 
            // btnAreaAdd
            // 
            this.btnAreaAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaAdd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAreaAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAreaAdd.Appearance.Options.UseFont = true;
            this.btnAreaAdd.Appearance.Options.UseForeColor = true;
            this.btnAreaAdd.CustomText = "添加(F5)";
            this.btnAreaAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAreaAdd.Image")));
            this.btnAreaAdd.Location = new System.Drawing.Point(161, 560);
            this.btnAreaAdd.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAreaAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAreaAdd.Name = "btnAreaAdd";
            this.btnAreaAdd.Selectable = false;
            this.btnAreaAdd.Size = new System.Drawing.Size(80, 28);
            this.btnAreaAdd.TabIndex = 12;
            this.btnAreaAdd.Text = "添加(F5)";
            this.btnAreaAdd.Click += new System.EventHandler(this.btnAreaAdd_Click);
            // 
            // btnAreaSave
            // 
            this.btnAreaSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAreaSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAreaSave.Appearance.Options.UseFont = true;
            this.btnAreaSave.Appearance.Options.UseForeColor = true;
            this.btnAreaSave.CustomText = "保存(F4)";
            this.btnAreaSave.Image = ((System.Drawing.Image)(resources.GetObject("btnAreaSave.Image")));
            this.btnAreaSave.Location = new System.Drawing.Point(74, 560);
            this.btnAreaSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAreaSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAreaSave.Name = "btnAreaSave";
            this.btnAreaSave.Selectable = false;
            this.btnAreaSave.Size = new System.Drawing.Size(80, 28);
            this.btnAreaSave.TabIndex = 14;
            this.btnAreaSave.Text = "保存(F4)";
            this.btnAreaSave.Click += new System.EventHandler(this.btnAreaSave_Click);
            // 
            // txtAreaNo
            // 
            this.txtAreaNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAreaNo.Location = new System.Drawing.Point(84, 524);
            this.txtAreaNo.Name = "txtAreaNo";
            this.txtAreaNo.Size = new System.Drawing.Size(157, 20);
            this.txtAreaNo.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Location = new System.Drawing.Point(18, 530);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 160;
            this.labelControl5.Text = "区域编号：";
            // 
            // btnFloorDelete
            // 
            this.btnFloorDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFloorDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnFloorDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnFloorDelete.Appearance.Options.UseFont = true;
            this.btnFloorDelete.Appearance.Options.UseForeColor = true;
            this.btnFloorDelete.CustomText = "删除(F3)";
            this.btnFloorDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnFloorDelete.Image")));
            this.btnFloorDelete.Location = new System.Drawing.Point(201, 560);
            this.btnFloorDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnFloorDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFloorDelete.Name = "btnFloorDelete";
            this.btnFloorDelete.Selectable = false;
            this.btnFloorDelete.Size = new System.Drawing.Size(80, 28);
            this.btnFloorDelete.TabIndex = 4;
            this.btnFloorDelete.Text = "删除(F3)";
            this.btnFloorDelete.Click += new System.EventHandler(this.btnFloorDelete_Click);
            // 
            // btnFloorAdd
            // 
            this.btnFloorAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFloorAdd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnFloorAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnFloorAdd.Appearance.Options.UseFont = true;
            this.btnFloorAdd.Appearance.Options.UseForeColor = true;
            this.btnFloorAdd.CustomText = "添加(F2)";
            this.btnFloorAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnFloorAdd.Image")));
            this.btnFloorAdd.Location = new System.Drawing.Point(115, 560);
            this.btnFloorAdd.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnFloorAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFloorAdd.Name = "btnFloorAdd";
            this.btnFloorAdd.Selectable = false;
            this.btnFloorAdd.Size = new System.Drawing.Size(80, 28);
            this.btnFloorAdd.TabIndex = 3;
            this.btnFloorAdd.Text = "添加(F2)";
            this.btnFloorAdd.Click += new System.EventHandler(this.btnFloorAdd_Click);
            // 
            // gridFloor
            // 
            this.gridFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFloor.Location = new System.Drawing.Point(5, 25);
            this.gridFloor.MainView = this.gvwFloor;
            this.gridFloor.Name = "gridFloor";
            this.gridFloor.Size = new System.Drawing.Size(276, 482);
            this.gridFloor.TabIndex = 30;
            this.gridFloor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwFloor});
            // 
            // gvwFloor
            // 
            this.gvwFloor.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gvwFloor.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwFloor.Appearance.OddRow.BackColor = System.Drawing.SystemColors.MenuBar;
            this.gvwFloor.Appearance.OddRow.Options.UseBackColor = true;
            this.gvwFloor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvwFloor.GridControl = this.gridFloor;
            this.gvwFloor.Name = "gvwFloor";
            this.gvwFloor.OptionsBehavior.Editable = false;
            this.gvwFloor.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwFloor.OptionsView.EnableAppearanceOddRow = true;
            this.gvwFloor.OptionsView.ShowGroupPanel = false;
            this.gvwFloor.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gvwFloor_CustomDrawEmptyForeground);
            this.gvwFloor.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwFloor_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "楼层编号";
            this.gridColumn1.FieldName = "floor_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // btnFloorSave
            // 
            this.btnFloorSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFloorSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnFloorSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnFloorSave.Appearance.Options.UseFont = true;
            this.btnFloorSave.Appearance.Options.UseForeColor = true;
            this.btnFloorSave.CustomText = "保存(F1)";
            this.btnFloorSave.Image = ((System.Drawing.Image)(resources.GetObject("btnFloorSave.Image")));
            this.btnFloorSave.Location = new System.Drawing.Point(29, 560);
            this.btnFloorSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnFloorSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFloorSave.Name = "btnFloorSave";
            this.btnFloorSave.Selectable = false;
            this.btnFloorSave.Size = new System.Drawing.Size(80, 28);
            this.btnFloorSave.TabIndex = 2;
            this.btnFloorSave.Text = "保存(F1)";
            this.btnFloorSave.Click += new System.EventHandler(this.btnFloorSave_Click);
            // 
            // txtFloorNo
            // 
            this.txtFloorNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFloorNo.Location = new System.Drawing.Point(77, 524);
            this.txtFloorNo.Name = "txtFloorNo";
            this.txtFloorNo.Size = new System.Drawing.Size(157, 20);
            this.txtFloorNo.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(13, 527);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 110;
            this.labelControl2.Text = "楼层编号：";
            // 
            // gridPark
            // 
            this.gridPark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPark.Location = new System.Drawing.Point(5, 25);
            this.gridPark.MainView = this.gvwPark;
            this.gridPark.Name = "gridPark";
            this.gridPark.Size = new System.Drawing.Size(554, 485);
            this.gridPark.TabIndex = 32;
            this.gridPark.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwPark});
            // 
            // gvwPark
            // 
            this.gvwPark.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gvwPark.Appearance.Row.Options.UseFont = true;
            this.gvwPark.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9});
            this.gvwPark.GridControl = this.gridPark;
            this.gvwPark.Name = "gvwPark";
            this.gvwPark.OptionsBehavior.Editable = false;
            this.gvwPark.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwPark.OptionsView.EnableAppearanceOddRow = true;
            this.gvwPark.OptionsView.ShowGroupPanel = false;
            this.gvwPark.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gvwPark_CustomDrawEmptyForeground);
            this.gvwPark.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwPark_FocusedRowChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "车位编号";
            this.gridColumn6.FieldName = "park_no";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "所属区域";
            this.gridColumn7.FieldName = "area_no";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "所在楼层";
            this.gridColumn4.FieldName = "floor_no";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "摄像头编号";
            this.gridColumn8.FieldName = "camera_no";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "车位状态";
            this.gridColumn9.FieldName = "park_status_name";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // btnParkDelete
            // 
            this.btnParkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParkDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnParkDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnParkDelete.Appearance.Options.UseFont = true;
            this.btnParkDelete.Appearance.Options.UseForeColor = true;
            this.btnParkDelete.CustomText = "删除(F9)";
            this.btnParkDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnParkDelete.Image")));
            this.btnParkDelete.Location = new System.Drawing.Point(479, 560);
            this.btnParkDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnParkDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnParkDelete.Name = "btnParkDelete";
            this.btnParkDelete.Selectable = false;
            this.btnParkDelete.Size = new System.Drawing.Size(80, 28);
            this.btnParkDelete.TabIndex = 13;
            this.btnParkDelete.Text = "删除(F9)";
            this.btnParkDelete.Click += new System.EventHandler(this.btnParkDelete_Click);
            // 
            // btnParkAdd
            // 
            this.btnParkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParkAdd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnParkAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnParkAdd.Appearance.Options.UseFont = true;
            this.btnParkAdd.Appearance.Options.UseForeColor = true;
            this.btnParkAdd.CustomText = "添加(F8)";
            this.btnParkAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnParkAdd.Image")));
            this.btnParkAdd.Location = new System.Drawing.Point(393, 560);
            this.btnParkAdd.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnParkAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnParkAdd.Name = "btnParkAdd";
            this.btnParkAdd.Selectable = false;
            this.btnParkAdd.Size = new System.Drawing.Size(80, 28);
            this.btnParkAdd.TabIndex = 12;
            this.btnParkAdd.Text = "添加(F8)";
            this.btnParkAdd.Click += new System.EventHandler(this.btnParkAdd_Click);
            // 
            // btnParkSave
            // 
            this.btnParkSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParkSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnParkSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnParkSave.Appearance.Options.UseFont = true;
            this.btnParkSave.Appearance.Options.UseForeColor = true;
            this.btnParkSave.CustomText = "保存(F7)";
            this.btnParkSave.Image = ((System.Drawing.Image)(resources.GetObject("btnParkSave.Image")));
            this.btnParkSave.Location = new System.Drawing.Point(307, 560);
            this.btnParkSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnParkSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnParkSave.Name = "btnParkSave";
            this.btnParkSave.Selectable = false;
            this.btnParkSave.Size = new System.Drawing.Size(80, 28);
            this.btnParkSave.TabIndex = 14;
            this.btnParkSave.Text = "保存(F7)";
            this.btnParkSave.Click += new System.EventHandler(this.btnParkSave_Click);
            // 
            // pnlFloor
            // 
            this.pnlFloor.Controls.Add(this.btnFloorDelete);
            this.pnlFloor.Controls.Add(this.gridFloor);
            this.pnlFloor.Controls.Add(this.btnFloorAdd);
            this.pnlFloor.Controls.Add(this.labelControl2);
            this.pnlFloor.Controls.Add(this.btnFloorSave);
            this.pnlFloor.Controls.Add(this.txtFloorNo);
            this.pnlFloor.Location = new System.Drawing.Point(3, 3);
            this.pnlFloor.Name = "pnlFloor";
            this.pnlFloor.Size = new System.Drawing.Size(286, 593);
            this.pnlFloor.TabIndex = 60;
            this.pnlFloor.Text = "楼层维护";
            // 
            // pnlArea
            // 
            this.pnlArea.Controls.Add(this.gridArea);
            this.pnlArea.Controls.Add(this.btnAreaDelete);
            this.pnlArea.Controls.Add(this.labelControl5);
            this.pnlArea.Controls.Add(this.txtAreaNo);
            this.pnlArea.Controls.Add(this.btnAreaAdd);
            this.pnlArea.Controls.Add(this.btnAreaSave);
            this.pnlArea.Location = new System.Drawing.Point(295, 3);
            this.pnlArea.Name = "pnlArea";
            this.pnlArea.Size = new System.Drawing.Size(332, 593);
            this.pnlArea.TabIndex = 70;
            this.pnlArea.Text = "区域维护";
            // 
            // pnlPark
            // 
            this.pnlPark.Controls.Add(this.txtCameraNo);
            this.pnlPark.Controls.Add(this.labelControl6);
            this.pnlPark.Controls.Add(this.txtParkNo);
            this.pnlPark.Controls.Add(this.labelControl1);
            this.pnlPark.Controls.Add(this.btnParkDelete);
            this.pnlPark.Controls.Add(this.gridPark);
            this.pnlPark.Controls.Add(this.btnParkSave);
            this.pnlPark.Controls.Add(this.btnParkAdd);
            this.pnlPark.Location = new System.Drawing.Point(633, 3);
            this.pnlPark.Name = "pnlPark";
            this.pnlPark.Size = new System.Drawing.Size(564, 593);
            this.pnlPark.TabIndex = 200;
            this.pnlPark.Text = "区域维护";
            // 
            // txtCameraNo
            // 
            this.txtCameraNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCameraNo.Location = new System.Drawing.Point(340, 524);
            this.txtCameraNo.Name = "txtCameraNo";
            this.txtCameraNo.Size = new System.Drawing.Size(157, 20);
            this.txtCameraNo.TabIndex = 25;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Location = new System.Drawing.Point(262, 530);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 14);
            this.labelControl6.TabIndex = 26;
            this.labelControl6.Text = "摄像头编号：";
            // 
            // txtParkNo
            // 
            this.txtParkNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtParkNo.Location = new System.Drawing.Point(87, 527);
            this.txtParkNo.Name = "txtParkNo";
            this.txtParkNo.Size = new System.Drawing.Size(157, 20);
            this.txtParkNo.TabIndex = 22;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(21, 533);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "车位编号：";
            // 
            // AreaManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPark);
            this.Controls.Add(this.pnlArea);
            this.Controls.Add(this.pnlFloor);
            this.Name = "AreaManageView";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.AreaManageView_Load);
            this.SizeChanged += new System.EventHandler(this.AreaManageView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloorNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwPark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFloor)).EndInit();
            this.pnlFloor.ResumeLayout(false);
            this.pnlFloor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlArea)).EndInit();
            this.pnlArea.ResumeLayout(false);
            this.pnlArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPark)).EndInit();
            this.pnlPark.ResumeLayout(false);
            this.pnlPark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCameraNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParkNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridArea;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwArea;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtAreaNo;
        private Controls.BtnSave btnAreaSave;
        private Controls.BtnDelete btnAreaDelete;
        private Controls.BtnAdd btnAreaAdd;
        private Controls.BtnDelete btnFloorDelete;
        private Controls.BtnAdd btnFloorAdd;
        private DevExpress.XtraGrid.GridControl gridFloor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwFloor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private Controls.BtnSave btnFloorSave;
        private DevExpress.XtraEditors.TextEdit txtFloorNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridPark;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwPark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private Controls.BtnDelete btnParkDelete;
        private Controls.BtnAdd btnParkAdd;
        private Controls.BtnSave btnParkSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.GroupControl pnlFloor;
        private DevExpress.XtraEditors.GroupControl pnlArea;
        private DevExpress.XtraEditors.GroupControl pnlPark;
        private DevExpress.XtraEditors.TextEdit txtCameraNo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtParkNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
