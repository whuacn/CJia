using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 等待加载用户控件
    /// </summary>
    public class UCForWaitingForm:DevExpress.XtraEditors.XtraUserControl
    {
        private CJia.Controls.CJiaLoadingBar cJiaLoadingBar1;
        private CJia.Controls.CJiaPanel cJiaPanel1;
        private AnimatorNS.Animator animator1;
        private IContainer components;
        private CJiaLabel cJiaLabel2;
        private CJia.Controls.CJiaLabel cJiaLabel1;
        /// <summary>
        /// CJiaWaitingUC构造函数
        /// </summary>
        public UCForWaitingForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 等待窗体
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="minProcess">最小值</param>
        /// <param name="maxProcess">最大值</param>
        public UCForWaitingForm(string msg, int minProcess, int maxProcess)
        {
            InitializeComponent();
            cJiaLoadingBar1.Properties.Minimum = minProcess;
            cJiaLoadingBar1.Properties.Maximum = maxProcess;
            cJiaLoadingBar1.Properties.Step = 1;
            //cJiaLoadingBar1.PerformStep();
            cJiaLabel1.Text = msg;

            Form frm = new Form();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = this.Size;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            DevExpress.XtraEditors.PanelControl panel = new DevExpress.XtraEditors.PanelControl();
            panel.Appearance.BackColor = System.Drawing.Color.Transparent;
            panel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            panel.Appearance.Options.UseBackColor = true;
            panel.Appearance.Options.UseBorderColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            panel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            panel.LookAndFeel.UseDefaultLookAndFeel = false;
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            frm.Controls.Add(panel);
            frm.ShowInTaskbar = false;
            frm.TopMost = true;
            frm.Show();
            frm.Refresh();
        }
        /// <summary>
        /// 执行进度条
        /// </summary>
        public void Do(string msg)
        {
            cJiaLabel2.Text = msg;
            cJiaLoadingBar1.PerformStep();
            this.Refresh();
        }
        /// <summary>
        /// 执行进度条
        /// </summary>
        public void Do()
        {
            cJiaLabel2.Text = "";
            cJiaLoadingBar1.PerformStep();
            this.Refresh();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            AnimatorNS.Animation animation1 = new AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCForWaitingForm));
            this.cJiaLoadingBar1 = new CJia.Controls.CJiaLoadingBar();
            this.cJiaPanel1 = new CJia.Controls.CJiaPanel();
            this.cJiaLabel1 = new CJia.Controls.CJiaLabel();
            this.animator1 = new AnimatorNS.Animator(this.components);
            this.cJiaLabel2 = new CJia.Controls.CJiaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaLoadingBar1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).BeginInit();
            this.cJiaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cJiaLoadingBar1
            // 
            this.animator1.SetDecoration(this.cJiaLoadingBar1, AnimatorNS.DecorationType.BottomMirror);
            this.cJiaLoadingBar1.Location = new System.Drawing.Point(27, 87);
            this.cJiaLoadingBar1.Name = "cJiaLoadingBar1";
            this.cJiaLoadingBar1.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cJiaLoadingBar1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaLoadingBar1.Properties.ShowTitle = true;
            this.cJiaLoadingBar1.Size = new System.Drawing.Size(483, 29);
            this.cJiaLoadingBar1.TabIndex = 0;
            // 
            // cJiaPanel1
            // 
            this.cJiaPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(180)))), ((int)(((byte)(228)))));
            this.cJiaPanel1.Appearance.Options.UseBackColor = true;
            this.cJiaPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cJiaPanel1.Controls.Add(this.cJiaLabel1);
            this.animator1.SetDecoration(this.cJiaPanel1, AnimatorNS.DecorationType.None);
            this.cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            this.cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cJiaPanel1.Name = "cJiaPanel1";
            this.cJiaPanel1.Size = new System.Drawing.Size(537, 41);
            this.cJiaPanel1.TabIndex = 1;
            // 
            // cJiaLabel1
            // 
            this.cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cJiaLabel1.Appearance.ForeColor = System.Drawing.Color.White;
            this.animator1.SetDecoration(this.cJiaLabel1, AnimatorNS.DecorationType.None);
            this.cJiaLabel1.Location = new System.Drawing.Point(6, 13);
            this.cJiaLabel1.Name = "cJiaLabel1";
            this.cJiaLabel1.Size = new System.Drawing.Size(92, 16);
            this.cJiaLabel1.TabIndex = 2;
            this.cJiaLabel1.Text = "正在加载中...";
            // 
            // animator1
            // 
            this.animator1.AnimationType = AnimatorNS.AnimationType.Custom;
            this.animator1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.animator1.DefaultAnimation = animation1;
            // 
            // cJiaLabel2
            // 
            this.cJiaLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.animator1.SetDecoration(this.cJiaLabel2, AnimatorNS.DecorationType.None);
            this.cJiaLabel2.Location = new System.Drawing.Point(27, 63);
            this.cJiaLabel2.Name = "cJiaLabel2";
            this.cJiaLabel2.Size = new System.Drawing.Size(20, 16);
            this.cJiaLabel2.TabIndex = 3;
            this.cJiaLabel2.Text = "     ";
            // 
            // UCForWaitingForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cJiaLabel2);
            this.Controls.Add(this.cJiaPanel1);
            this.Controls.Add(this.cJiaLoadingBar1);
            this.animator1.SetDecoration(this, AnimatorNS.DecorationType.None);
            this.Name = "UCForWaitingForm";
            this.Size = new System.Drawing.Size(537, 175);
            ((System.ComponentModel.ISupportInitialize)(this.cJiaLoadingBar1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJiaPanel1)).EndInit();
            this.cJiaPanel1.ResumeLayout(false);
            this.cJiaPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private string lableName;
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Category("CJia属性"), Description("自定义文本")]
        public string CustomText
        {
            get { return lableName; }
            set
            {
                lableName = value;
                this.cJiaLabel1.Text = value;
            }
        }
    }
}
