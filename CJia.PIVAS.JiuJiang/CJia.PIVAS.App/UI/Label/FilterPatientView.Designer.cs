namespace CJia.PIVAS.App.UI.Label
{
    partial class FilterPatientView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterPatientView));
            this.ckeBen = new DevExpress.XtraEditors.CheckEdit();
            this.clbBed = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ckeBen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbBed)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckeBen
            // 
            this.ckeBen.EditValue = true;
            this.ckeBen.Location = new System.Drawing.Point(3, 10);
            this.ckeBen.Name = "ckeBen";
            this.ckeBen.Properties.Caption = "全部床位";
            this.ckeBen.Size = new System.Drawing.Size(75, 19);
            this.ckeBen.TabIndex = 3;
            this.ckeBen.CheckedChanged += new System.EventHandler(this.ckeBen_CheckedChanged);
            // 
            // clbBed
            // 
            this.clbBed.HotTrackItems = true;
            this.clbBed.Location = new System.Drawing.Point(3, 37);
            this.clbBed.Name = "clbBed";
            this.clbBed.Size = new System.Drawing.Size(196, 330);
            this.clbBed.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.ckeBen);
            this.panel1.Controls.Add(this.clbBed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 418);
            this.panel1.TabIndex = 4;
            // 
            // btnEnter
            // 
            this.btnEnter.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnEnter.Appearance.Options.UseFont = true;
            this.btnEnter.Image = ((System.Drawing.Image)(resources.GetObject("btnEnter.Image")));
            this.btnEnter.Location = new System.Drawing.Point(89, 379);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 27);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "确认";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // FilterPatientView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FilterPatientView";
            this.Size = new System.Drawing.Size(204, 418);
            ((System.ComponentModel.ISupportInitialize)(this.ckeBen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbBed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ckeBen;
        private DevExpress.XtraEditors.CheckedListBoxControl clbBed;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
    }
}
