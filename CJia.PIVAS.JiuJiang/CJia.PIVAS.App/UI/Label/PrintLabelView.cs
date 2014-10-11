using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 打印瓶贴用户控件
    /// </summary>
    public partial class PrintLabelView : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 打印瓶贴
        /// </summary>
        /// <param name="LabelDetail">待打印的瓶贴</param>
        public PrintLabelView(DataTable LabelDetail)
        {
            InitializeComponent();
            this.LabelDetail = LabelDetail;
            this.Initi();
        }

        #region 字段 属性

        //待打印的瓶贴
        private DataTable LabelDetail = null;       

        //是否打印  
        public bool IsPrint = false;     

        //开始打印的瓶贴号
        public int StartNum;   

        //结束打印的瓶贴号
        public int EndNum;         

        #endregion

        #region 补助方法

        // 初始化方法
        private void Initi()
        {
            if(this.LabelDetail == null || this.LabelDetail.Rows == null || this.LabelDetail.Rows.Count == 0)
            {
                Message.Show("没有要打印的瓶贴！");
            }
            else
            {
                this.rbnAll.Text = "显示的所有(" + LabelDetail.Rows.Count + ")张瓶贴";
                this.rbnAll.Checked = true;
                this.rbnNoAll.Checked = false;
                this.txtStart.Text = "1";
                this.txtStart.Enabled = false;
                this.txtEnd.Text = LabelDetail.Rows.Count.ToString();
                this.txtEnd.Enabled = false;
            }
        }

        #endregion

        #region 界面事件

        //选择全部单选框改变事件绑定方法
        private void rbnAll_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbnAll.Checked)
            {
                this.rbnNoAll.Checked = false;
            }
        }

        //选择一部分单选框改变事件绑定方法
        private void rbnNoAll_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbnNoAll.Checked)
            {
                this.txtEnd.Enabled = true;
                this.txtStart.Enabled = true;
            }
            else
            {
                this.txtEnd.Enabled = false;
                this.txtStart.Enabled = false;
            }
        }

        //确认按钮单击事件绑定方法
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsSucceed = true;
                if(this.rbnAll.Checked)
                {
                    if(Message.ShowQuery("现在开始打印显示的所有的(" + this.LabelDetail.Rows.Count.ToString() + ")张瓶贴！确认开始打印瓶贴", Message.Button.OkCancel) == Message.Result.Ok)
                    {
                        this.IsPrint = true;
                        this.StartNum = 1;
                        this.EndNum = this.LabelDetail.Rows.Count;
                        this.ParentForm.Close();
                    }
                }
                else if(this.rbnNoAll.Checked)
                {
                    int start = Convert.ToInt32(this.txtStart.Text);
                    int end = Convert.ToInt32(this.txtEnd.Text);
                    if(start > end)
                    {
                        Message.Show("开始瓶贴号不能大于结束瓶贴号！");
                        IsSucceed = false;
                    }
                    if(end > this.LabelDetail.Rows.Count)
                    {
                        Message.Show("结束瓶贴号不能大于总瓶贴数！");
                        IsSucceed = false;
                    }
                    if(IsSucceed)
                    {
                        if(Message.ShowQuery("现在开始打印 " + start.ToString() + "号到" + end.ToString() + "号瓶贴, 确认开始打印瓶贴", Message.Button.OkCancel) == Message.Result.Ok)
                        {
                            this.IsPrint = true;
                            this.StartNum = start;
                            this.EndNum = end;
                            this.ParentForm.Close();
                        }
                    }
                }
            }
            catch
            {
                Message.Show("您填写的非正常数字！");
            }
        }
        
        //取消按钮单击事件绑定方法
        private void btnCentel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        //开始打印瓶贴号输入框修改事件绑定方法
        private void txtStart_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int start = Convert.ToInt32(this.txtStart.Text);
                int end = Convert.ToInt32(this.txtEnd.Text);
                if(start > end)
                {
                    start = end;
                }
                this.txtStart.Text = start.ToString();
            }
            catch
            {
            }
        }

        //结束打印瓶贴号输入框修改事件绑定方法
        private void txtEnd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int start = Convert.ToInt32(this.txtStart.Text);
                int end = Convert.ToInt32(this.txtEnd.Text);
                if(start > end)
                {
                    end = start;
                }
                if(end > this.LabelDetail.Rows.Count)
                {
                    end = this.LabelDetail.Rows.Count;
                }
                this.txtEnd.Text = end.ToString();
            }
            catch
            {
            }
        }

        #endregion

    }
}
