using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 进度条用户控件
    /// </summary>
    public class ProgressView : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraEditors.LabelControl txtSchedule;
        private DevExpress.XtraEditors.LabelControl txtName;
        private DevExpress.XtraEditors.ProgressBarControl pbcSchedule;

        private void InitializeComponent()
        {
            this.pbcSchedule = new DevExpress.XtraEditors.ProgressBarControl();
            this.txtSchedule = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbcSchedule.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pbcSchedule
            // 
            this.pbcSchedule.Location = new System.Drawing.Point(24, 55);
            this.pbcSchedule.Name = "pbcSchedule";
            this.pbcSchedule.Size = new System.Drawing.Size(553, 18);
            this.pbcSchedule.TabIndex = 0;
            // 
            // txtSchedule
            // 
            this.txtSchedule.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtSchedule.Location = new System.Drawing.Point(286, 79);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(29, 17);
            this.txtSchedule.TabIndex = 1;
            this.txtSchedule.Text = "5/10";
            // 
            // txtName
            // 
            this.txtName.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtName.Location = new System.Drawing.Point(239, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(122, 21);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "正在生成瓶贴……";
            // 
            // ProgressView
            // 
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.pbcSchedule);
            this.Name = "ProgressView";
            this.Size = new System.Drawing.Size(600, 125);
            ((System.ComponentModel.ISupportInitialize)(this.pbcSchedule.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="max">进度条的最大值</param>
        /// <param name="name">精度条的名称</param>
        public ProgressView(int max, string name)
        {
            InitializeComponent();
            this.pbcSchedule.Properties.Maximum = max;
            this.pbcSchedule.Properties.Minimum = 0;
            this.pbcSchedule.Properties.Step = 1;
            this.pbcSchedule.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.pbcSchedule.BackColor = Color.Blue;
            this.pbcSchedule.Position = 0;
            this.txtName.Text = name;
            this.Max = max;
            this.Now = 0;
            this.txtSchedule.Text = this.Now.ToString() + "/" + this.Max.ToString();
        }

        /// <summary>
        /// 初始化进度条
        /// </summary>
        /// <param name="max">进度条的最大值</param>
        /// <param name="step">进度条每次走动条数</param>
        /// <param name="name">精度条的名称</param>
        public ProgressView(int max, int step, string name)
        {
            InitializeComponent();
            this.pbcSchedule.Properties.Maximum = max;
            this.pbcSchedule.Properties.Minimum = 0;
            this.pbcSchedule.Properties.Step = step;
            this.pbcSchedule.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.pbcSchedule.BackColor = Color.Blue;
            this.pbcSchedule.Position = 0;
            this.txtName.Text = name;
            this.Max = max;
            this.Now = 0;
        }

        #region 字段属性

        //进度条总数
        private int Max;

        //进度条现在的数
        private int Now;

        #endregion

        #region 外部方法 事件

        //关闭事件
        public event EventHandler Close;

        /// <summary>
        /// 进度条走到下一步
        /// </summary>
        public void NextSchedule(object sender, EventArgs e)
        {
            this.pbcSchedule.PerformStep();
            this.Now = this.Now + 1;
            if(this.Max <= this.Now)
            {
                this.Close(null, null);
                this.ParentForm.Close();
            }
            else
            {
                this.txtSchedule.Text = this.Now.ToString() + "/" + this.Max.ToString();
                this.pbcSchedule.Refresh();
                this.txtSchedule.Refresh();
                this.txtName.Refresh();
            }
        }

        #endregion
    }
}
