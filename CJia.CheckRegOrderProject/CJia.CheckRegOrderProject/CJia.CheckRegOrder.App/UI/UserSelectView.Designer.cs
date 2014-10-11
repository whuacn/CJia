namespace CJia.CheckRegOrder.App.UI
{
    partial class UserSelectView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSelectView));
            this.panelControl21 = new DevExpress.XtraEditors.PanelControl();
            this.btnResetPswd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnModify = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.txtUserNO = new DevExpress.XtraEditors.TextEdit();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).BeginInit();
            this.panelControl21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl21
            // 
            this.panelControl21.Controls.Add(this.btnResetPswd);
            this.panelControl21.Controls.Add(this.btnDelete);
            this.panelControl21.Controls.Add(this.btnModify);
            this.panelControl21.Controls.Add(this.btnSelect);
            this.panelControl21.Controls.Add(this.txtUserNO);
            this.panelControl21.Controls.Add(this.labelControl33);
            this.panelControl21.Controls.Add(this.gcUser);
            this.panelControl21.Controls.Add(this.txtUserName);
            this.panelControl21.Controls.Add(this.labelControl23);
            this.panelControl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl21.Location = new System.Drawing.Point(0, 0);
            this.panelControl21.Name = "panelControl21";
            this.panelControl21.Size = new System.Drawing.Size(919, 531);
            this.panelControl21.TabIndex = 2;
            // 
            // btnResetPswd
            // 
            this.btnResetPswd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetPswd.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPswd.Image")));
            this.btnResetPswd.Location = new System.Drawing.Point(588, 493);
            this.btnResetPswd.Name = "btnResetPswd";
            this.btnResetPswd.Size = new System.Drawing.Size(95, 29);
            this.btnResetPswd.TabIndex = 36;
            this.btnResetPswd.Text = "重置密码(&R)";
            this.btnResetPswd.Click += new System.EventHandler(this.btnResetPswd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(812, 493);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 29);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "删除用户(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.Location = new System.Drawing.Point(700, 493);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(95, 29);
            this.btnModify.TabIndex = 34;
            this.btnModify.Text = "编辑用户(&E)";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(431, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 29);
            this.btnSelect.TabIndex = 33;
            this.btnSelect.Text = "查询(&Q)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtUserNO
            // 
            this.txtUserNO.Location = new System.Drawing.Point(280, 13);
            this.txtUserNO.Name = "txtUserNO";
            this.txtUserNO.Size = new System.Drawing.Size(128, 20);
            this.txtUserNO.TabIndex = 32;
            this.txtUserNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserNO_KeyDown);
            // 
            // labelControl33
            // 
            this.labelControl33.Location = new System.Drawing.Point(213, 15);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(60, 14);
            this.labelControl33.TabIndex = 31;
            this.labelControl33.Text = "用户工号：";
            // 
            // gcUser
            // 
            this.gcUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcUser.Location = new System.Drawing.Point(0, 43);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(919, 441);
            this.gcUser.TabIndex = 4;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser,
            this.gridView15});
            // 
            // gvUser
            // 
            this.gvUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn35,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn2});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsBehavior.Editable = false;
            this.gvUser.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户工号";
            this.gridColumn1.FieldName = "user_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "用户姓名";
            this.gridColumn35.FieldName = "user_name";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 1;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "创建时间";
            this.gridColumn37.FieldName = "create_date";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 2;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "创建人";
            this.gridColumn38.FieldName = "create_name";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "管理员";
            this.gridColumn2.FieldName = "user_type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridView15
            // 
            this.gridView15.GridControl = this.gcUser;
            this.gridView15.Name = "gridView15";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(79, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(128, 20);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(12, 15);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(60, 14);
            this.labelControl23.TabIndex = 2;
            this.labelControl23.Text = "用户姓名：";
            // 
            // UserSelectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl21);
            this.Name = "UserSelectView";
            this.Size = new System.Drawing.Size(919, 531);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).EndInit();
            this.panelControl21.ResumeLayout(false);
            this.panelControl21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl21;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.TextEdit txtUserNO;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.SimpleButton btnResetPswd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnModify;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
