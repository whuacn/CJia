namespace CJia.PIVAS.App.UI
{
    partial class ScanningMonitoringForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // scanningMonitoringView1
            // 
            this.scanningMonitoringView1.BackColor = System.Drawing.Color.White;
            this.scanningMonitoringView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scanningMonitoringView1.Location = new System.Drawing.Point(0, 0);
            this.scanningMonitoringView1.Name = "scanningMonitoringView1";
            this.scanningMonitoringView1.Size = new System.Drawing.Size(1370, 749);
            this.scanningMonitoringView1.TabIndex = 0;
            // 
            // ScanningMonitoringForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.scanningMonitoringView1);
            this.KeyPreview = true;
            this.Name = "ScanningMonitoringForm";
            this.Text = "ScanningMonitoringForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScanningMonitoringForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ScanningMonitoringView scanningMonitoringView1 = new CJia.PIVAS.App.UI.ScanningMonitoringView();



    }
}