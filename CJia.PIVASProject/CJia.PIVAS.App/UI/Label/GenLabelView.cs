using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 生成瓶贴用户控件
    /// </summary>
    public partial class GenLabelView : CJia.PIVAS.Tools.View,CJia.PIVAS.Views.Label.IGenLabelView
    {
        /// <summary>
        /// 生成瓶贴用户控件构造函数
        /// </summary>
        public GenLabelView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new CJia.PIVAS.Presenters.Label.GenLabelPresenter(this);
        }

        #region 字段 属性

        /// <summary>
        /// 是否预览
        /// </summary>
        private bool IsPreview = false;

        #endregion

        #region 界面事件

        //初始化事件绑定方法
        private void GenLabelView_Load(object sender, EventArgs e)
        {
            this.OnQueryListCountEven(null,null);
            this.OnQueryIffield(null,null);
        }

        //刷新按钮单击事件绑定方法
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.OnQueryListCountEven(null,null);
            this.OnQueryIffield(null,null);
        }

        //选着全部病区按钮单机事件绑定方法
        private void btnSeleteAll_Click(object sender, EventArgs e)
        {
            this.gdvIffield.SelectAll();
        }

        //生成瓶贴按钮单击事件绑定方法
        private void genButton_Click(object sender, EventArgs e)
        {
            if(this.IsPreview)
            {
                DevExpress.XtraEditors.SimpleButton genButton = sender as DevExpress.XtraEditors.SimpleButton;
                string timeId = genButton.Tag.ToString();
                CJia.PIVAS.Views.Label.GenLabelEventArgs genLabelEventArgs = new Views.Label.GenLabelEventArgs()
                {
                    TimeId = timeId,
                    Illfieldids = this.GetSelectIffield()
                };
                this.OnGenLabelEven(null, genLabelEventArgs);
                this.IsPreview = false;
            }
            else
            {
                MessageBox.Show("请先预览！");
            }
        }

        //预览瓶贴按钮单击事件绑定方法
        private void previewButton_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton previewButton = sender as DevExpress.XtraEditors.SimpleButton;
            string timeId = previewButton.Tag.ToString();
            CJia.PIVAS.Views.Label.GenLabelEventArgs genLabelEventArgs = new Views.Label.GenLabelEventArgs()
            {
                TimeId = timeId,
                Illfieldids = this.GetSelectIffield()
            };
            this.OnPreviewLabelEven(null, genLabelEventArgs);
            this.IsPreview = true;
        }

        #endregion

        #region IGenLabelView 成员

        //查询摆药次数事件
        public event EventHandler< CJia.PIVAS.Views.Label.GenLabelEventArgs> OnQueryListCountEven;

        //查询所有病区事件
        public event EventHandler<CJia.PIVAS.Views.Label.GenLabelEventArgs> OnQueryIffield;

        //预览瓶贴事件
        public event EventHandler<CJia.PIVAS.Views.Label.GenLabelEventArgs> OnPreviewLabelEven;

        //生成瓶贴事件
        public event EventHandler<CJia.PIVAS.Views.Label.GenLabelEventArgs> OnGenLabelEven;

        //初始化预览生成按钮回调方法
        public void ExeInitButton(DataTable result)
        {
            object[] previewimage = new object[]
            { 
                CJia.PIVAS.App.Properties.Resources.preview1,
                CJia.PIVAS.App.Properties.Resources.preview2,
                CJia.PIVAS.App.Properties.Resources.preview3,
                CJia.PIVAS.App.Properties.Resources.preview4,
                CJia.PIVAS.App.Properties.Resources.preview5
            };
            object[] genimage = new object[]
            { 
                CJia.PIVAS.App.Properties.Resources.label1,
                CJia.PIVAS.App.Properties.Resources.label2,
                CJia.PIVAS.App.Properties.Resources.label3,
                CJia.PIVAS.App.Properties.Resources.label4,
                CJia.PIVAS.App.Properties.Resources.label5
            };
            int tabIndex = 0;
            int heith = 5;
            int i = 1;
            foreach(DataRow row in result.Rows)
            {
                DevExpress.XtraEditors.SimpleButton previewButton = new SimpleButton();
                //previewButton.Image = global::CJia.PIVAS.App.Properties.Resources.page_white_text;
                previewButton.Location = new System.Drawing.Point(10, heith);
                previewButton.Size = new System.Drawing.Size(150, 27);
                previewButton.TabIndex = tabIndex++;
                previewButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
                previewButton.Image = (System.Drawing.Image)(previewimage[i - 1]);
                previewButton.TabStop = true;
                previewButton.Text = "第" + CJia.PIVAS.Tools.Helper.Convert(i) + "次预览";
                previewButton.Tag = row["TIME_ID"];
                previewButton.Click += previewButton_Click;
                this.panel1.Controls.Add(previewButton);

                DevExpress.XtraEditors.SimpleButton genButton = new SimpleButton();
                genButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
                //genButton.Image = global::CJia.PIVAS.App.Properties.Resources.page_white_stack;
                genButton.Location = new System.Drawing.Point(166, heith);
                genButton.Size = new System.Drawing.Size(this.splitContainerControl3.Size.Width - 177, 27);
                genButton.TabIndex = tabIndex++;
                genButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
                genButton.Image = (System.Drawing.Image)(genimage[i - 1]);
                genButton.TabStop = true;
                genButton.Text = "第" + CJia.PIVAS.Tools.Helper.Convert(i) + "次生成";
                genButton.Tag = row["TIME_ID"];
                genButton.Click += genButton_Click;
                this.panel1.Controls.Add(genButton);

                DevExpress.XtraEditors.LabelControl timeLabel = new LabelControl();
                timeLabel.Location = new System.Drawing.Point(11, heith + 29);
                timeLabel.Size = new System.Drawing.Size(124, 14);
                timeLabel.TabIndex = 18;
                timeLabel.Text = "有效时间(" + row["START_TIME"] + "~" + row["OVER_TIME"].ToString() + ")";
                this.panel1.Controls.Add(timeLabel);

                i++;
                heith += 53;
            }
        }

        //初始化病区gridcontrol回调方法
        public void ExeInitIffieldGrid(DataTable result)
        {
            this.gdvIffield.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn Illfield = new GridColumn();
            Illfield.Caption = "病区";
            Illfield.FieldName = "OFFICE_NAME";
            Illfield.Visible = true;
            Illfield.VisibleIndex = 0;
            this.gdvIffield.Columns.Add(Illfield);
            for( int i = 1; i <= result.Rows.Count; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn gridColumn = new GridColumn();
                gridColumn.Caption = CJia.PIVAS.Tools.Helper.Convert(i) + "次";
                gridColumn.FieldName = "CREATE_ARRANGE_" + i.ToString();
                gridColumn.Visible = true;
                gridColumn.VisibleIndex = i;
                this.gdvIffield.Columns.Add(gridColumn);
            }
        }

        //显示提示信息弹出框的回调方法
        public void ShowMessage(string mes)
        {
            MessageBox.Show(mes);
        }

        //预览瓶贴的汇总信息的回调方法
        public void ExeBindingCollect(DataTable result)
        {
            this.grcCollect.DataSource = result;
            this.gridView1.ExpandAllGroups();
        }

        //预览瓶贴详情信息的回调方法
        public void ExeBindingInfo(DataTable result)
        {
            this.grcInfo.DataSource = result;
            if(result == null || result.Rows == null || result.Rows.Count == 0)
            {
                MessageBox.Show("没有可预览的瓶贴！");
            }
        }

        //病区选择病区的回调方法
        public void ExeBindingIffield(DataTable result)
        {
            this.gdcIffield.DataSource = result;
        }

        //生成瓶贴结束后的回调方法
        public void ExeGenLabel(DataTable result, List<DataRow> iffieldnames)
        {
            Form form = new Form();
            form.AutoSize = true;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "生成瓶贴结果";
            CJia.PIVAS.App.UI.Label.GenLabelResultView genLabelResultView = new CJia.PIVAS.App.UI.Label.GenLabelResultView();
            genLabelResultView.BindData(result,iffieldnames);
            form.Controls.Add(genLabelResultView);
            genLabelResultView.Dock = DockStyle.Fill;
            form.ShowDialog();
            this.OnQueryListCountEven(null,null);
            this.OnQueryIffield(null,null);
            this.grcCollect.DataSource = null;
            this.grcInfo.DataSource = null;
        }

        //初始化生成瓶贴进度条回调方法
        public void ExeInitSchedule(int max)
        {
            Form form = new Form();
            form.AutoSize = true;
            form.Size = new Size(600, 100);
            form.FormBorderStyle = FormBorderStyle.None;
            form.MaximizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            CJia.PIVAS.App.UI.Label.ProgressView progress = new CJia.PIVAS.App.UI.Label.ProgressView(max,"生成瓶贴中……");
            this.OnNextSchedule += progress.NextSchedule;
            progress.Close += progress_Close;
            form.Controls.Add(progress);
            progress.Dock = DockStyle.Fill;
            form.Show();
        }

        //进度条走到下一步回调方法
        public void ExeNextSchedule()
        {
           this.OnNextSchedule(null,null);
        }

        #endregion

        #region 对外事件 方法

        //进度条走到下一步事件
        event EventHandler OnNextSchedule;

        //进度条关闭绑定方法
        private void progress_Close(object sender, EventArgs e)
        {
            this.OnNextSchedule = null;
        }

        #endregion

        #region 补助方法

        //获取选着的病区
        private List<DataRow> GetSelectIffield()
        {
            int[] ints = this.gdvIffield.GetSelectedRows();
            List<DataRow> dataRows = new List<DataRow>();
            foreach(int i in ints)
            {
                dataRows.Add(this.gdvIffield.GetDataRow(i));
            }
            return dataRows;
        }

        #endregion

    }
}