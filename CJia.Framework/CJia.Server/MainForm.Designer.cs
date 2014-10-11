namespace CJia.Server
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStartCustomServer = new System.Windows.Forms.Button();
            this.boxLog = new System.Windows.Forms.RichTextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAddSystemNO = new System.Windows.Forms.Button();
            this.btnAddDBName = new System.Windows.Forms.Button();
            this.grdListenTable = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteDBName = new System.Windows.Forms.Button();
            this.btnDeleteSystemNO = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步病人到中间库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步医嘱到中间库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步EMR病人IDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步LIS结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步费用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步检查结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdListenTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(12, 25);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(99, 29);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "启动Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStartCustomServer
            // 
            this.btnStartCustomServer.Location = new System.Drawing.Point(134, 25);
            this.btnStartCustomServer.Name = "btnStartCustomServer";
            this.btnStartCustomServer.Size = new System.Drawing.Size(137, 29);
            this.btnStartCustomServer.TabIndex = 1;
            this.btnStartCustomServer.Text = "启动自定义Server";
            this.btnStartCustomServer.UseVisualStyleBackColor = true;
            this.btnStartCustomServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // boxLog
            // 
            this.boxLog.Location = new System.Drawing.Point(12, 73);
            this.boxLog.Name = "boxLog";
            this.boxLog.Size = new System.Drawing.Size(143, 309);
            this.boxLog.TabIndex = 2;
            this.boxLog.Text = "";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(538, 25);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(94, 29);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(289, 25);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(93, 29);
            this.btnStartListen.TabIndex = 4;
            this.btnStartListen.Text = "开始监听";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // btnStopListen
            // 
            this.btnStopListen.Location = new System.Drawing.Point(424, 25);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(93, 29);
            this.btnStopListen.TabIndex = 5;
            this.btnStopListen.Text = "停止监听";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAddSystemNO
            // 
            this.btnAddSystemNO.Location = new System.Drawing.Point(178, 73);
            this.btnAddSystemNO.Name = "btnAddSystemNO";
            this.btnAddSystemNO.Size = new System.Drawing.Size(93, 29);
            this.btnAddSystemNO.TabIndex = 6;
            this.btnAddSystemNO.Text = "增加系统";
            this.btnAddSystemNO.UseVisualStyleBackColor = true;
            this.btnAddSystemNO.Click += new System.EventHandler(this.btnAddSystemNO_Click);
            // 
            // btnAddDBName
            // 
            this.btnAddDBName.Location = new System.Drawing.Point(289, 73);
            this.btnAddDBName.Name = "btnAddDBName";
            this.btnAddDBName.Size = new System.Drawing.Size(93, 29);
            this.btnAddDBName.TabIndex = 7;
            this.btnAddDBName.Text = "增加数据库";
            this.btnAddDBName.UseVisualStyleBackColor = true;
            this.btnAddDBName.Click += new System.EventHandler(this.btnAddDBName_Click);
            // 
            // grdListenTable
            // 
            this.grdListenTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdListenTable.Location = new System.Drawing.Point(3, 17);
            this.grdListenTable.MainView = this.gridView1;
            this.grdListenTable.Name = "grdListenTable";
            this.grdListenTable.Size = new System.Drawing.Size(465, 257);
            this.grdListenTable.TabIndex = 8;
            this.grdListenTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.grdListenTable;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "系统编号";
            this.gridColumn1.FieldName = "SystemNO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "数据库名";
            this.gridColumn2.FieldName = "DBName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 105;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "数据库类型";
            this.gridColumn3.FieldName = "DBType";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 67;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "连接字符串";
            this.gridColumn4.FieldName = "DBConection";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 275;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdListenTable);
            this.groupBox1.Location = new System.Drawing.Point(161, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 277);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已开启的监听";
            // 
            // btnDeleteDBName
            // 
            this.btnDeleteDBName.Location = new System.Drawing.Point(536, 73);
            this.btnDeleteDBName.Name = "btnDeleteDBName";
            this.btnDeleteDBName.Size = new System.Drawing.Size(93, 29);
            this.btnDeleteDBName.TabIndex = 11;
            this.btnDeleteDBName.Text = "删除数据库";
            this.btnDeleteDBName.UseVisualStyleBackColor = true;
            this.btnDeleteDBName.Click += new System.EventHandler(this.btnDeleteDBName_Click);
            // 
            // btnDeleteSystemNO
            // 
            this.btnDeleteSystemNO.Location = new System.Drawing.Point(425, 73);
            this.btnDeleteSystemNO.Name = "btnDeleteSystemNO";
            this.btnDeleteSystemNO.Size = new System.Drawing.Size(93, 29);
            this.btnDeleteSystemNO.TabIndex = 10;
            this.btnDeleteSystemNO.Text = "删除系统";
            this.btnDeleteSystemNO.UseVisualStyleBackColor = true;
            this.btnDeleteSystemNO.Click += new System.EventHandler(this.btnDeleteSystemNO_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同步ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(643, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 同步ToolStripMenuItem
            // 
            this.同步ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同步病人到中间库ToolStripMenuItem,
            this.同步医嘱到中间库ToolStripMenuItem,
            this.同步EMR病人IDToolStripMenuItem,
            this.同步LIS结果ToolStripMenuItem,
            this.同步费用ToolStripMenuItem,
            this.同步检查结果ToolStripMenuItem});
            this.同步ToolStripMenuItem.Name = "同步ToolStripMenuItem";
            this.同步ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.同步ToolStripMenuItem.Text = "同步";
            // 
            // 同步病人到中间库ToolStripMenuItem
            // 
            this.同步病人到中间库ToolStripMenuItem.Name = "同步病人到中间库ToolStripMenuItem";
            this.同步病人到中间库ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.同步病人到中间库ToolStripMenuItem.Text = "同步病人到中间库";
            this.同步病人到中间库ToolStripMenuItem.Click += new System.EventHandler(this.同步病人到中间库ToolStripMenuItem_Click);
            // 
            // 同步医嘱到中间库ToolStripMenuItem
            // 
            this.同步医嘱到中间库ToolStripMenuItem.Name = "同步医嘱到中间库ToolStripMenuItem";
            this.同步医嘱到中间库ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.同步医嘱到中间库ToolStripMenuItem.Text = "同步医嘱到中间库";
            this.同步医嘱到中间库ToolStripMenuItem.Click += new System.EventHandler(this.同步医嘱到中间库ToolStripMenuItem_Click);
            // 
            // 同步EMR病人IDToolStripMenuItem
            // 
            this.同步EMR病人IDToolStripMenuItem.Name = "同步EMR病人IDToolStripMenuItem";
            this.同步EMR病人IDToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.同步EMR病人IDToolStripMenuItem.Text = "同步EMR病人ID";
            this.同步EMR病人IDToolStripMenuItem.Click += new System.EventHandler(this.同步EMR病人IDToolStripMenuItem_Click);
            // 
            // 同步LIS结果ToolStripMenuItem
            // 
            this.同步LIS结果ToolStripMenuItem.Name = "同步LIS结果ToolStripMenuItem";
            this.同步LIS结果ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.同步LIS结果ToolStripMenuItem.Text = "同步LIS结果";
            this.同步LIS结果ToolStripMenuItem.Click += new System.EventHandler(this.同步LIS结果ToolStripMenuItem_Click);
            // 
            // 同步费用ToolStripMenuItem
            // 
            this.同步费用ToolStripMenuItem.Name = "同步费用ToolStripMenuItem";
            this.同步费用ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.同步费用ToolStripMenuItem.Text = "同步费用";
            this.同步费用ToolStripMenuItem.Click += new System.EventHandler(this.同步费用ToolStripMenuItem_Click);
            // 
            // 同步检查结果ToolStripMenuItem
            // 
            this.同步检查结果ToolStripMenuItem.Name = "同步检查结果ToolStripMenuItem";
            this.同步检查结果ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.同步检查结果ToolStripMenuItem.Text = "同步检查结果";
            this.同步检查结果ToolStripMenuItem.Click += new System.EventHandler(this.同步检查结果ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 394);
            this.Controls.Add(this.btnDeleteDBName);
            this.Controls.Add(this.btnDeleteSystemNO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddDBName);
            this.Controls.Add(this.btnAddSystemNO);
            this.Controls.Add(this.btnStopListen);
            this.Controls.Add(this.btnStartListen);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.boxLog);
            this.Controls.Add(this.btnStartCustomServer);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "创佳网络服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListenTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStartCustomServer;
        private System.Windows.Forms.RichTextBox boxLog;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAddSystemNO;
        private System.Windows.Forms.Button btnAddDBName;
        private DevExpress.XtraGrid.GridControl grdListenTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Button btnDeleteDBName;
        private System.Windows.Forms.Button btnDeleteSystemNO;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步病人到中间库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步医嘱到中间库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步EMR病人IDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步LIS结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步费用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步检查结果ToolStripMenuItem;
    }
}

