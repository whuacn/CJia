namespace CJia.Parking.App.UI
{
    partial class UserManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManageView));
            this.pnlUser = new DevExpress.XtraEditors.PanelControl();
            this.gridUser = new DevExpress.XtraGrid.GridControl();
            this.gvwUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUserDelete = new CJia.Controls.BtnDelete();
            this.btnUserAdd = new CJia.Controls.BtnAdd();
            this.btnUserSave = new CJia.Controls.BtnSave();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.chkRole = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkDefaultPwd = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllRole = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUser)).BeginInit();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefaultPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllRole.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUser
            // 
            this.pnlUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUser.Controls.Add(this.gridUser);
            this.pnlUser.Location = new System.Drawing.Point(3, 3);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(882, 593);
            this.pnlUser.TabIndex = 0;
            // 
            // gridUser
            // 
            this.gridUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUser.Location = new System.Drawing.Point(6, 6);
            this.gridUser.MainView = this.gvwUser;
            this.gridUser.Name = "gridUser";
            this.gridUser.Size = new System.Drawing.Size(871, 582);
            this.gridUser.TabIndex = 0;
            this.gridUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwUser});
            // 
            // gvwUser
            // 
            this.gvwUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5});
            this.gvwUser.GridControl = this.gridUser;
            this.gvwUser.Name = "gvwUser";
            this.gvwUser.OptionsBehavior.Editable = false;
            this.gvwUser.OptionsView.EnableAppearanceEvenRow = true;
            this.gvwUser.OptionsView.EnableAppearanceOddRow = true;
            this.gvwUser.OptionsView.ShowGroupPanel = false;
            this.gvwUser.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gvwUser_CustomDrawEmptyForeground);
            this.gvwUser.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwUser_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户工号";
            this.gridColumn1.FieldName = "user_no";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 166;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用户姓名";
            this.gridColumn2.FieldName = "user_name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 133;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "角色";
            this.gridColumn5.FieldName = "union_role_name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 291;
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnUserDelete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnUserDelete.Appearance.Options.UseFont = true;
            this.btnUserDelete.Appearance.Options.UseForeColor = true;
            this.btnUserDelete.CustomText = "删除(F6)";
            this.btnUserDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnUserDelete.Image")));
            this.btnUserDelete.Location = new System.Drawing.Point(109, 367);
            this.btnUserDelete.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUserDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Selectable = false;
            this.btnUserDelete.Size = new System.Drawing.Size(195, 28);
            this.btnUserDelete.TabIndex = 8;
            this.btnUserDelete.Text = "删除(F6)";
            this.btnUserDelete.Click += new System.EventHandler(this.btnUserDelete_Click);
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnUserAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnUserAdd.Appearance.Options.UseFont = true;
            this.btnUserAdd.Appearance.Options.UseForeColor = true;
            this.btnUserAdd.CustomText = "添加(F2)";
            this.btnUserAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnUserAdd.Image")));
            this.btnUserAdd.Location = new System.Drawing.Point(109, 328);
            this.btnUserAdd.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUserAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Selectable = false;
            this.btnUserAdd.Size = new System.Drawing.Size(195, 28);
            this.btnUserAdd.TabIndex = 7;
            this.btnUserAdd.Text = "添加(F2)";
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // btnUserSave
            // 
            this.btnUserSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserSave.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnUserSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnUserSave.Appearance.Options.UseFont = true;
            this.btnUserSave.Appearance.Options.UseForeColor = true;
            this.btnUserSave.CustomText = "保存(F8)";
            this.btnUserSave.Image = ((System.Drawing.Image)(resources.GetObject("btnUserSave.Image")));
            this.btnUserSave.Location = new System.Drawing.Point(109, 288);
            this.btnUserSave.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnUserSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUserSave.Name = "btnUserSave";
            this.btnUserSave.Selectable = false;
            this.btnUserSave.Size = new System.Drawing.Size(195, 28);
            this.btnUserSave.TabIndex = 6;
            this.btnUserSave.Text = "保存(F8)";
            this.btnUserSave.Click += new System.EventHandler(this.btnUserSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(37, 128);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 30;
            this.labelControl5.Text = "权限：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "用户姓名：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(72, 68);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(192, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "用户工号：";
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(72, 37);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(192, 20);
            this.txtUserNo.TabIndex = 1;
            // 
            // chkRole
            // 
            this.chkRole.Location = new System.Drawing.Point(74, 153);
            this.chkRole.Name = "chkRole";
            this.chkRole.Size = new System.Drawing.Size(192, 117);
            this.chkRole.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.chkDefaultPwd);
            this.groupControl1.Controls.Add(this.chkAllRole);
            this.groupControl1.Controls.Add(this.btnUserDelete);
            this.groupControl1.Controls.Add(this.btnUserAdd);
            this.groupControl1.Controls.Add(this.btnUserSave);
            this.groupControl1.Controls.Add(this.txtUserNo);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.chkRole);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(889, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(307, 593);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "操作区";
            // 
            // chkDefaultPwd
            // 
            this.chkDefaultPwd.Location = new System.Drawing.Point(72, 100);
            this.chkDefaultPwd.Name = "chkDefaultPwd";
            this.chkDefaultPwd.Properties.Caption = "重置为默认密码";
            this.chkDefaultPwd.Size = new System.Drawing.Size(148, 19);
            this.chkDefaultPwd.TabIndex = 31;
            // 
            // chkAllRole
            // 
            this.chkAllRole.Location = new System.Drawing.Point(72, 125);
            this.chkAllRole.Name = "chkAllRole";
            this.chkAllRole.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.chkAllRole.Properties.Appearance.Options.UseFont = true;
            this.chkAllRole.Properties.Caption = "全部";
            this.chkAllRole.Size = new System.Drawing.Size(148, 22);
            this.chkAllRole.TabIndex = 4;
            this.chkAllRole.CheckedChanged += new System.EventHandler(this.chkAllRole_CheckedChanged);
            // 
            // UserManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pnlUser);
            this.Name = "UserManageView";
            this.Size = new System.Drawing.Size(1200, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUser)).EndInit();
            this.pnlUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefaultPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllRole.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlUser;
        private DevExpress.XtraGrid.GridControl gridUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Controls.BtnDelete btnUserDelete;
        private Controls.BtnAdd btnUserAdd;
        private Controls.BtnSave btnUserSave;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.CheckedListBoxControl chkRole;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkAllRole;
        private DevExpress.XtraEditors.CheckEdit chkDefaultPwd;

    }
}
