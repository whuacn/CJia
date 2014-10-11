namespace CJia.Tools.UI
{
    partial class CreatMvpView
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
            if(disposing && (components != null))
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txbUIName = new System.Windows.Forms.TextBox();
            this.txbProjectPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fbdSelectDire = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOpenDire = new System.Windows.Forms.Button();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtUI = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtViews = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.txtPresenters = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.txtModels = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUI.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtViews.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresenters.Properties)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(372, 71);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(99, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "增加";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txbUIName
            // 
            this.txbUIName.Location = new System.Drawing.Point(152, 32);
            this.txbUIName.Name = "txbUIName";
            this.txbUIName.Size = new System.Drawing.Size(150, 22);
            this.txbUIName.TabIndex = 1;
            // 
            // txbProjectPath
            // 
            this.txbProjectPath.Location = new System.Drawing.Point(454, 32);
            this.txbProjectPath.Name = "txbProjectPath";
            this.txbProjectPath.Size = new System.Drawing.Size(129, 22);
            this.txbProjectPath.TabIndex = 2;
            this.txbProjectPath.TextChanged += new System.EventHandler(this.txbProjectPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "UI名（不带View）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "项目路径：";
            // 
            // btnOpenDire
            // 
            this.btnOpenDire.Location = new System.Drawing.Point(584, 31);
            this.btnOpenDire.Name = "btnOpenDire";
            this.btnOpenDire.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDire.TabIndex = 7;
            this.btnOpenDire.Text = "浏览……";
            this.btnOpenDire.UseVisualStyleBackColor = true;
            this.btnOpenDire.Click += new System.EventHandler(this.btnOpenDire_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.groupBox1);
            this.panelControl2.Location = new System.Drawing.Point(3, 125);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(689, 298);
            this.panelControl2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xtraTabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "创建模板";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 18);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(679, 273);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtUI);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(673, 244);
            this.xtraTabPage1.Text = "UI层模板";
            // 
            // txtUI
            // 
            this.txtUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUI.EditValue = "";
            this.txtUI.Location = new System.Drawing.Point(0, 0);
            this.txtUI.Name = "txtUI";
            this.txtUI.Size = new System.Drawing.Size(673, 244);
            this.txtUI.TabIndex = 3;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtViews);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(673, 245);
            this.xtraTabPage2.Text = "Views层模板";
            // 
            // txtViews
            // 
            this.txtViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtViews.EditValue = "";
            this.txtViews.Location = new System.Drawing.Point(0, 0);
            this.txtViews.Name = "txtViews";
            this.txtViews.Size = new System.Drawing.Size(673, 245);
            this.txtViews.TabIndex = 3;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.txtPresenters);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(673, 245);
            this.xtraTabPage3.Text = "Presenters模板";
            // 
            // txtPresenters
            // 
            this.txtPresenters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPresenters.EditValue = "";
            this.txtPresenters.Location = new System.Drawing.Point(0, 0);
            this.txtPresenters.Name = "txtPresenters";
            this.txtPresenters.Size = new System.Drawing.Size(673, 245);
            this.txtPresenters.TabIndex = 3;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.txtModels);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(673, 245);
            this.xtraTabPage4.Text = "Models模板";
            // 
            // txtModels
            // 
            this.txtModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModels.EditValue = "";
            this.txtModels.Location = new System.Drawing.Point(0, 0);
            this.txtModels.Name = "txtModels";
            this.txtModels.Size = new System.Drawing.Size(673, 245);
            this.txtModels.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(689, 116);
            this.panelControl1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtProjectName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txbUIName);
            this.groupBox2.Controls.Add(this.btnCreate);
            this.groupBox2.Controls.Add(this.btnOpenDire);
            this.groupBox2.Controls.Add(this.txbProjectPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 112);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "创建mvp用户控件以及各层文件";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(560, 72);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存模板修改";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(152, 72);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(150, 22);
            this.txtProjectName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "项目名称：";
            // 
            // CreatMvpView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "CreatMvpView";
            this.Size = new System.Drawing.Size(695, 426);
            this.Load += new System.EventHandler(this.CreatMvpView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUI.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtViews.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPresenters.Properties)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtModels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txbUIName;
        private System.Windows.Forms.TextBox txbProjectPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectDire;
        private System.Windows.Forms.Button btnOpenDire;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.MemoEdit txtViews;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.MemoEdit txtPresenters;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.MemoEdit txtModels;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraEditors.MemoEdit txtUI;
    }
}
