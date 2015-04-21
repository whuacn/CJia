namespace CJia.Health.Tools
{
    partial class PDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFViewer));
            this.axFoxitReader = new AxFoxitReaderSDKProLib.AxFoxitReaderSDK();
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitReader)).BeginInit();
            this.SuspendLayout();
            // 
            // axFoxitReader
            // 
            this.axFoxitReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFoxitReader.Enabled = true;
            this.axFoxitReader.Location = new System.Drawing.Point(0, 0);
            this.axFoxitReader.Name = "axFoxitReader";
            this.axFoxitReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFoxitReader.OcxState")));
            this.axFoxitReader.Size = new System.Drawing.Size(316, 387);
            this.axFoxitReader.TabIndex = 0;
            // 
            // PDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axFoxitReader);
            this.Name = "PDFViewer";
            this.Size = new System.Drawing.Size(316, 387);
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxFoxitReaderSDKProLib.AxFoxitReaderSDK axFoxitReader;

    }
}
