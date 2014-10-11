namespace CJia.PIVAS.App.UI.Label
{
    partial class FilterBatchView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterBatchView));
            this.ckeBatch = new DevExpress.XtraEditors.CheckEdit();
            this.clbBatch = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ckeBatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbBatch)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckeBatch
            // 
            this.ckeBatch.EditValue = true;
            this.ckeBatch.Location = new System.Drawing.Point(3, 10);
            this.ckeBatch.Name = "ckeBatch";
            this.ckeBatch.Properties.Caption = "全部批次";
            this.ckeBatch.Size = new System.Drawing.Size(75, 19);
            this.ckeBatch.TabIndex = 3;
            this.ckeBatch.CheckedChanged += new System.EventHandler(this.ckeBatch_CheckedChanged);
            // 
            // clbBatch
            // 
            this.clbBatch.HotTrackItems = true;
            this.clbBatch.Location = new System.Drawing.Point(3, 37);
            this.clbBatch.Name = "clbBatch";
            this.clbBatch.Size = new System.Drawing.Size(196, 174);
            this.clbBatch.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.ckeBatch);
            this.panel1.Controls.Add(this.clbBatch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 260);
            this.panel1.TabIndex = 4;
            // 
            // btnEnter
            // 
            this.btnEnter.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnEnter.Appearance.Options.UseFont = true;
            this.btnEnter.Image = ((System.Drawing.Image)(resources.GetObject("btnEnter.Image")));
            this.btnEnter.Location = new System.Drawing.Point(90, 219);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 27);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "确认";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // FilterBatchView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FilterBatchView";
            this.Size = new System.Drawing.Size(204, 260);
            ((System.ComponentModel.ISupportInitialize)(this.ckeBatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbBatch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ckeBatch;
        private DevExpress.XtraEditors.CheckedListBoxControl clbBatch;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
    }
}
