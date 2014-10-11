namespace CJia.PEIS.App.UI
{
    partial class AssTemView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssTemView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.cJiaPanel3 = new CJia.Controls.CJiaPanel();
            this.btnAddAssTem = new CJia.Controls.BtnAdd();
            this.btnSearchAssTem = new CJia.Controls.CJiaTextSearch();
            this.gridAssTem = new CJia.Controls.CJiaGrid();
            this.cJiaPanel2 = new CJia.Controls.CJiaPanel();
            this.btnCloseAssTem = new CJia.Controls.BtnClose();
            this.btnCancelAssTem = new CJia.Controls.BtnCancel();
            this.btnSaveAssTem = new CJia.Controls.BtnSave();
            this.mlAssTem = new CJia.Controls.TxtMultiLine();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.pnlAssTem = new CJia.Controls.CJiaPagingPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel3)).BeginInit();
            this.cJiaPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAssTem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAssTem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).BeginInit();
            this.cJiaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mlAssTem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAssTem)).BeginInit();
            this.SuspendLayout();
            // 
            // cJiaPanel3
            // 
            this.cJiaPanel3.Controls.Add(this.pnlAssTem);
            this.cJiaPanel3.Controls.Add(this.btnAddAssTem);
            this.cJiaPanel3.Controls.Add(this.btnSearchAssTem);
            this.cJiaPanel3.Controls.Add(this.gridAssTem);
            this.cJiaPanel3.Location = new System.Drawing.Point(3, 179);
            this.cJiaPanel3.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel3.Name = "cJiaPanel3";
            this.cJiaPanel3.Size = new System.Drawing.Size(679, 389);
            this.cJiaPanel3.TabIndex = 4;
            // 
            // btnAddAssTem
            // 
            this.btnAddAssTem.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAddAssTem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnAddAssTem.Appearance.Options.UseFont = true;
            this.btnAddAssTem.Appearance.Options.UseForeColor = true;
            this.btnAddAssTem.CustomText = "添加(F2)";
            this.btnAddAssTem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAssTem.Image")));
            this.btnAddAssTem.Location = new System.Drawing.Point(582, 7);
            this.btnAddAssTem.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnAddAssTem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddAssTem.Name = "btnAddAssTem";
            this.btnAddAssTem.Selectable = false;
            this.btnAddAssTem.Size = new System.Drawing.Size(80, 28);
            this.btnAddAssTem.TabIndex = 7;
            this.btnAddAssTem.Text = "添加(F2)";
            // 
            // btnSearchAssTem
            // 
            this.btnSearchAssTem.EditValue = "";
            this.btnSearchAssTem.Location = new System.Drawing.Point(3, 5);
            this.btnSearchAssTem.Name = "btnSearchAssTem";
            this.btnSearchAssTem.PointText = "";
            this.btnSearchAssTem.Properties.Appearance.BorderColor = System.Drawing.Color.Salmon;
            this.btnSearchAssTem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSearchAssTem.Properties.Appearance.ForeColor = System.Drawing.Color.LightGray;
            this.btnSearchAssTem.Properties.Appearance.Options.UseBorderColor = true;
            this.btnSearchAssTem.Properties.Appearance.Options.UseFont = true;
            this.btnSearchAssTem.Properties.Appearance.Options.UseForeColor = true;
            toolTipItem1.Text = "查询";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnSearchAssTem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnSearchAssTem.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true)});
            this.btnSearchAssTem.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSearchAssTem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearchAssTem.Size = new System.Drawing.Size(300, 32);
            this.btnSearchAssTem.TabIndex = 6;
            // 
            // gridAssTem
            // 
            this.gridAssTem.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridAssTem.IndicatorWidth = 30;
            this.gridAssTem.Location = new System.Drawing.Point(2, 43);
            this.gridAssTem.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridAssTem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridAssTem.Name = "gridAssTem";
            this.gridAssTem.ShowRowNumber = true;
            this.gridAssTem.Size = new System.Drawing.Size(674, 307);
            this.gridAssTem.TabIndex = 0;
            // 
            // cJiaPanel2
            // 
            this.cJiaPanel2.Controls.Add(this.btnCloseAssTem);
            this.cJiaPanel2.Controls.Add(this.btnCancelAssTem);
            this.cJiaPanel2.Controls.Add(this.btnSaveAssTem);
            this.cJiaPanel2.Controls.Add(this.mlAssTem);
            this.cJiaPanel2.Controls.Add(this.cJiaLabel1);
            this.cJiaPanel2.Location = new System.Drawing.Point(2, 4);
            this.cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel2.Name = "cJiaPanel2";
            this.cJiaPanel2.Size = new System.Drawing.Size(680, 174);
            this.cJiaPanel2.TabIndex = 3;
            // 
            // btnCloseAssTem
            // 
            this.btnCloseAssTem.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCloseAssTem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnCloseAssTem.Appearance.Options.UseFont = true;
            this.btnCloseAssTem.Appearance.Options.UseForeColor = true;
            this.btnCloseAssTem.CustomText = "关闭(F4)";
            this.btnCloseAssTem.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAssTem.Image")));
            this.btnCloseAssTem.Location = new System.Drawing.Point(583, 7);
            this.btnCloseAssTem.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnCloseAssTem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCloseAssTem.Name = "btnCloseAssTem";
            this.btnCloseAssTem.Selectable = false;
            this.btnCloseAssTem.Size = new System.Drawing.Size(80, 28);
            this.btnCloseAssTem.TabIndex = 4;
            this.btnCloseAssTem.Text = "关闭(F4)";
            // 
            // btnCancelAssTem
            // 
            this.btnCancelAssTem.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancelAssTem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnCancelAssTem.Appearance.Options.UseFont = true;
            this.btnCancelAssTem.Appearance.Options.UseForeColor = true;
            this.btnCancelAssTem.CustomText = "取消(F4)";
            this.btnCancelAssTem.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelAssTem.Image")));
            this.btnCancelAssTem.Location = new System.Drawing.Point(583, 65);
            this.btnCancelAssTem.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnCancelAssTem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancelAssTem.Name = "btnCancelAssTem";
            this.btnCancelAssTem.Selectable = false;
            this.btnCancelAssTem.Size = new System.Drawing.Size(80, 28);
            this.btnCancelAssTem.TabIndex = 3;
            this.btnCancelAssTem.Text = "取消(F4)";
            // 
            // btnSaveAssTem
            // 
            this.btnSaveAssTem.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSaveAssTem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSaveAssTem.Appearance.Options.UseFont = true;
            this.btnSaveAssTem.Appearance.Options.UseForeColor = true;
            this.btnSaveAssTem.CustomText = "保存(F8)";
            this.btnSaveAssTem.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAssTem.Image")));
            this.btnSaveAssTem.Location = new System.Drawing.Point(583, 123);
            this.btnSaveAssTem.LookAndFeel.SkinName = "Office 2010 Blue";
            this.btnSaveAssTem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSaveAssTem.Name = "btnSaveAssTem";
            this.btnSaveAssTem.Selectable = false;
            this.btnSaveAssTem.Size = new System.Drawing.Size(80, 28);
            this.btnSaveAssTem.TabIndex = 2;
            this.btnSaveAssTem.Text = "保存(F8)";
            // 
            // mlAssTem
            // 
            this.mlAssTem.Location = new System.Drawing.Point(73, 5);
            this.mlAssTem.Name = "mlAssTem";
            this.mlAssTem.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.mlAssTem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.mlAssTem.Properties.Appearance.Options.UseBackColor = true;
            this.mlAssTem.Properties.Appearance.Options.UseFont = true;
            this.mlAssTem.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.mlAssTem.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.mlAssTem.Size = new System.Drawing.Size(485, 164);
            this.mlAssTem.TabIndex = 1;
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cJiaLabel1.Location = new System.Drawing.Point(3, 6);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(65, 16);
            this.cJiaLabel1.TabIndex = 0;
            this.cJiaLabel1.Text = "评估内容:";
            // 
            // pnlAssTem
            // 
            this.pnlAssTem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.pnlAssTem.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.pnlAssTem.Appearance.Options.UseBackColor = true;
            this.pnlAssTem.Appearance.Options.UseBorderColor = true;
            this.pnlAssTem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlAssTem.Location = new System.Drawing.Point(2, 351);
            this.pnlAssTem.LookAndFeel.SkinName = "Office 2010 Silver";
            this.pnlAssTem.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlAssTem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlAssTem.Name = "pnlAssTem";
            this.pnlAssTem.Size = new System.Drawing.Size(674, 35);
            this.pnlAssTem.TabIndex = 11;
            // 
            // AssTemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaPanel3);
            this.Controls.Add(this.cJiaPanel2);
            this.Name = "AssTemView";
            this.Size = new System.Drawing.Size(685, 572);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel3)).EndInit();
            this.cJiaPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAssTem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAssTem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel2)).EndInit();
            this.cJiaPanel2.ResumeLayout(false);
            this.cJiaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mlAssTem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAssTem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CJiaPanel cJiaPanel3;
        private Controls.BtnAdd btnAddAssTem;
        private Controls.CJiaTextSearch btnSearchAssTem;
        private Controls.CJiaGrid gridAssTem;
        private Controls.CJiaPanel cJiaPanel2;
        private Controls.BtnClose btnCloseAssTem;
        private Controls.BtnCancel btnCancelAssTem;
        private Controls.BtnSave btnSaveAssTem;
        private Controls.TxtMultiLine mlAssTem;
        private Controls.CJiaLabel cJiaLabel1;
        private Controls.CJiaPagingPanel pnlAssTem;


    }
}
