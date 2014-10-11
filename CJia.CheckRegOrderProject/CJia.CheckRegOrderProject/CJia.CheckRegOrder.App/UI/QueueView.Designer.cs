namespace CJia.CheckRegOrder.App.UI
{
    partial class QueueView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueView));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.splitContainerControl6 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.rgClinic = new DevExpress.XtraEditors.RadioGroup();
            this.gridQueue = new DevExpress.XtraGrid.GridControl();
            this.gvQueue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnUpdateClinic = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancleQueue = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton13 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.gridNoQueue = new DevExpress.XtraGrid.GridControl();
            this.gvNoQueue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancleWait = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllocationClinic = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl6)).BeginInit();
            this.splitContainerControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgClinic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNoQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNoQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl6
            // 
            this.splitContainerControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl6.Horizontal = false;
            this.splitContainerControl6.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl6.Name = "splitContainerControl6";
            this.splitContainerControl6.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl6.Panel1.Text = "Panel1";
            this.splitContainerControl6.Panel2.Controls.Add(this.groupControl8);
            this.splitContainerControl6.Panel2.Text = "Panel2";
            this.splitContainerControl6.Size = new System.Drawing.Size(1112, 566);
            this.splitContainerControl6.SplitterPosition = 289;
            this.splitContainerControl6.TabIndex = 4;
            this.splitContainerControl6.Text = "splitContainerControl6";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.btnRefresh);
            this.groupControl2.Controls.Add(this.rgClinic);
            this.groupControl2.Controls.Add(this.gridQueue);
            this.groupControl2.Controls.Add(this.btnUpdateClinic);
            this.groupControl2.Controls.Add(this.btnCancleQueue);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.simpleButton13);
            this.groupControl2.Location = new System.Drawing.Point(2, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1107, 282);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "病人排队队列(排队中)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(983, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // rgClinic
            // 
            this.rgClinic.Location = new System.Drawing.Point(66, 28);
            this.rgClinic.Name = "rgClinic";
            this.rgClinic.Size = new System.Drawing.Size(373, 24);
            this.rgClinic.TabIndex = 21;
            this.rgClinic.SelectedIndexChanged += new System.EventHandler(this.rgClinic_SelectedIndexChanged);
            // 
            // gridQueue
            // 
            this.gridQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridQueue.Location = new System.Drawing.Point(2, 55);
            this.gridQueue.MainView = this.gvQueue;
            this.gridQueue.Name = "gridQueue";
            this.gridQueue.Size = new System.Drawing.Size(1103, 185);
            this.gridQueue.TabIndex = 19;
            this.gridQueue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQueue,
            this.gridView1});
            this.gridQueue.DoubleClick += new System.EventHandler(this.gridQueue_DoubleClick);
            // 
            // gvQueue
            // 
            this.gvQueue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gvQueue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30});
            this.gvQueue.GridControl = this.gridQueue;
            this.gvQueue.Name = "gvQueue";
            this.gvQueue.OptionsBehavior.Editable = false;
            this.gvQueue.OptionsView.ShowGroupPanel = false;
            this.gvQueue.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GridView_CustomDrawEmptyForeground);
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "队列编号";
            this.gridColumn27.FieldName = "queue_no";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 0;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "姓名";
            this.gridColumn28.FieldName = "patient_name";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "诊室号";
            this.gridColumn29.FieldName = "clinic_name";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 2;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "检查状态";
            this.gridColumn30.FieldName = "code_value";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 3;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridQueue;
            this.gridView1.Name = "gridView1";
            // 
            // btnUpdateClinic
            // 
            this.btnUpdateClinic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateClinic.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateClinic.Image")));
            this.btnUpdateClinic.Location = new System.Drawing.Point(1004, 247);
            this.btnUpdateClinic.Name = "btnUpdateClinic";
            this.btnUpdateClinic.Size = new System.Drawing.Size(97, 29);
            this.btnUpdateClinic.TabIndex = 13;
            this.btnUpdateClinic.Text = "修改诊室(&U)";
            this.btnUpdateClinic.Click += new System.EventHandler(this.gridQueue_DoubleClick);
            // 
            // btnCancleQueue
            // 
            this.btnCancleQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancleQueue.Image = ((System.Drawing.Image)(resources.GetObject("btnCancleQueue.Image")));
            this.btnCancleQueue.Location = new System.Drawing.Point(772, 248);
            this.btnCancleQueue.Name = "btnCancleQueue";
            this.btnCancleQueue.Size = new System.Drawing.Size(97, 29);
            this.btnCancleQueue.TabIndex = 12;
            this.btnCancleQueue.Text = "取消排队";
            this.btnCancleQueue.Click += new System.EventHandler(this.btnCancleQueue_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 31);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 14);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "诊室号：";
            // 
            // simpleButton13
            // 
            this.simpleButton13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton13.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton13.Image")));
            this.simpleButton13.Location = new System.Drawing.Point(888, 247);
            this.simpleButton13.Name = "simpleButton13";
            this.simpleButton13.Size = new System.Drawing.Size(97, 29);
            this.simpleButton13.TabIndex = 9;
            this.simpleButton13.Text = "病人插队(&J)";
            // 
            // groupControl8
            // 
            this.groupControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl8.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl8.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl8.Controls.Add(this.gridNoQueue);
            this.groupControl8.Controls.Add(this.btnCancleWait);
            this.groupControl8.Controls.Add(this.btnAllocationClinic);
            this.groupControl8.Location = new System.Drawing.Point(4, 2);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(1105, 267);
            this.groupControl8.TabIndex = 2;
            this.groupControl8.Text = "病人等待排队队列（未排队）";
            // 
            // gridNoQueue
            // 
            this.gridNoQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gridNoQueue.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridNoQueue.Location = new System.Drawing.Point(2, 25);
            this.gridNoQueue.MainView = this.gvNoQueue;
            this.gridNoQueue.Name = "gridNoQueue";
            this.gridNoQueue.Size = new System.Drawing.Size(1101, 201);
            this.gridNoQueue.TabIndex = 19;
            this.gridNoQueue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNoQueue});
            this.gridNoQueue.DoubleClick += new System.EventHandler(this.gridNoQueue_DoubleClick);
            // 
            // gvNoQueue
            // 
            this.gvNoQueue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gvNoQueue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn53,
            this.gridColumn31,
            this.gridColumn26,
            this.gridColumn32});
            this.gvNoQueue.GridControl = this.gridNoQueue;
            this.gvNoQueue.Name = "gvNoQueue";
            this.gvNoQueue.OptionsBehavior.Editable = false;
            this.gvNoQueue.OptionsView.ShowGroupPanel = false;
            this.gvNoQueue.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.GridView_CustomDrawEmptyForeground);
            // 
            // gridColumn53
            // 
            this.gridColumn53.Caption = "姓名";
            this.gridColumn53.FieldName = "patient_name";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 0;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "登记时间";
            this.gridColumn31.FieldName = "register_date";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 1;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "诊室号";
            this.gridColumn26.FieldName = "clinic_name";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 2;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "检查状态";
            this.gridColumn32.FieldName = "code_value";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 3;
            // 
            // btnCancleWait
            // 
            this.btnCancleWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancleWait.Image = ((System.Drawing.Image)(resources.GetObject("btnCancleWait.Image")));
            this.btnCancleWait.Location = new System.Drawing.Point(886, 233);
            this.btnCancleWait.Name = "btnCancleWait";
            this.btnCancleWait.Size = new System.Drawing.Size(97, 29);
            this.btnCancleWait.TabIndex = 12;
            this.btnCancleWait.Text = "取消等待";
            this.btnCancleWait.Click += new System.EventHandler(this.btnCancleWait_Click);
            // 
            // btnAllocationClinic
            // 
            this.btnAllocationClinic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllocationClinic.Image = ((System.Drawing.Image)(resources.GetObject("btnAllocationClinic.Image")));
            this.btnAllocationClinic.Location = new System.Drawing.Point(1002, 233);
            this.btnAllocationClinic.Name = "btnAllocationClinic";
            this.btnAllocationClinic.Size = new System.Drawing.Size(97, 29);
            this.btnAllocationClinic.TabIndex = 10;
            this.btnAllocationClinic.Text = "分配诊室(&B)";
            this.btnAllocationClinic.Click += new System.EventHandler(this.gridNoQueue_DoubleClick);
            // 
            // QueueView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl6);
            this.Name = "QueueView";
            this.Size = new System.Drawing.Size(1112, 566);
            this.Load += new System.EventHandler(this.QueueView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl6)).EndInit();
            this.splitContainerControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgClinic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNoQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNoQueue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl6;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private DevExpress.XtraGrid.GridControl gridNoQueue;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNoQueue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraEditors.SimpleButton btnCancleWait;
        private DevExpress.XtraEditors.SimpleButton btnAllocationClinic;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.RadioGroup rgClinic;
        private DevExpress.XtraGrid.GridControl gridQueue;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQueue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraEditors.SimpleButton btnUpdateClinic;
        private DevExpress.XtraEditors.SimpleButton btnCancleQueue;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButton13;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
