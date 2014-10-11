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
    public partial class FilterLabelView : CJia.PIVAS.Tools.View,CJia.PIVAS.Views.Label.IFilterLabelView
    {
        /// <summary>
        /// 赛选瓶贴用户控件
        /// </summary>
        public FilterLabelView()
        {
            InitializeComponent();
            this.OnInit(null,null);
        }

        protected override object CreatePresenter()
        {
            return new CJia.PIVAS.Presenters.Label.FilterLabelPresenter(this);
        }

        #region 界面事件

        //全部药品类型复选框选择事件
        private void ckeAllPharmType_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckeAllPharmType.CheckState == CheckState.Checked)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.clbPharmType.Items)
                {
                    item.CheckState = CheckState.Checked;
                }
            }
            else
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.clbPharmType.Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        //全部批次复选框选择事件
        private void ckeAllBacth_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckeAllBacth.CheckState == CheckState.Checked)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.clbLabelBatch.Items)
                {
                    item.CheckState = CheckState.Checked;
                }
            }
            else
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.clbLabelBatch.Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        //全部病房复选框选择事件
        private void ckeBen_CheckedChanged(object sender, EventArgs e)
        {
            if(this.ckeBen.CheckState == CheckState.Checked)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.clbBed.Items)
                {
                    item.CheckState = CheckState.Checked;
                }
            }
            else
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.clbBed.Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        //以选排序双击事件
        private void lbcUseOrderBy_DoubleClick(object sender, EventArgs e)
        {
            this.ToRitht();
        }

        //未选排序双击事件
        private void lbcNoUseOrderBy_DoubleClick(object sender, EventArgs e)
        {
            this.Tolift();
        }

        //排序向左按钮单机事件
        private void btnToLift_Click(object sender, EventArgs e)
        {
            this.Tolift();

        }

        //排序向右按钮单击事件
        private void butToRigth_Click(object sender, EventArgs e)
        {
            this.ToRitht();

        }

        //排序向上按钮单机事件
        private void btnToTop_Click(object sender, EventArgs e)
        {
            if(this.lbcUseOrderBy.SelectedItem != null)
            {
                string selectItem = this.lbcUseOrderBy.SelectedItem.ToString();
                int  index = this.lbcUseOrderBy.SelectedIndex;
                this.lbcUseOrderBy.Items.Remove(selectItem);
                this.lbcUseOrderBy.Items.Insert(index - 1 >= 0 ? index - 1 : 0,selectItem);
                this.lbcUseOrderBy.SelectedItem = selectItem;
            }
        }

        //排序向下按钮单机事件
        private void btnToBotton_Click(object sender, EventArgs e)
        {
            if(this.lbcUseOrderBy.SelectedItem != null)
            {
                string selectItem = this.lbcUseOrderBy.SelectedItem.ToString();
                int index = this.lbcUseOrderBy.SelectedIndex;
                this.lbcUseOrderBy.Items.Remove(selectItem);
                this.lbcUseOrderBy.Items.Insert(index + 1 >= this.lbcUseOrderBy.Items.Count  ? this.lbcUseOrderBy.Items.Count  : index + 1, selectItem);
                this.lbcUseOrderBy.SelectedItem = selectItem;
            }
        }

        //取消按钮单机事件
        private void btnCentel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        //确认保存按钮单机事件
        private void btnEnter_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.Views.Label.FilterLabelEventArgs eventArgs = new Views.Label.FilterLabelEventArgs()
            {
               PharmType = this.clbPharmType,
               LabelBatch = this.clbLabelBatch,
               Bed = this.clbBed,
               UserOrderBy = this.lbcUseOrderBy,
               NoUserOrderBy = this.lbcNoUseOrderBy
            };
            this.OnModifFilter(null,eventArgs);
            this.ParentForm.Close();
        }

        #endregion

        #region IView 成员

        // 初始化事件
        public event EventHandler<CJia.PIVAS.Views.Label.FilterLabelEventArgs> OnInit;

        // 修改赛选条件事件
        public event EventHandler<CJia.PIVAS.Views.Label.FilterLabelEventArgs> OnModifFilter;

        // 显示弹出框回调方法
        public void ShowMessage(string mes)
        {
            MessageBox.Show(mes);
        }

        //绑定药品类型回调函数
        public void ExeBindingPharmTypes(object pharmTypes)
        {
            this.cope(this.clbPharmType, (DevExpress.XtraEditors.CheckedListBoxControl)pharmTypes);
        }

        //绑定批次回调函数
        public void ExeBindingBacths(object bacths)
        {
            this.cope(this.clbLabelBatch, (DevExpress.XtraEditors.CheckedListBoxControl)bacths);
        }

        //绑定病区病床回调函数
        public void ExeBindingIffieldBens(object IffieldBens)
        {
            this.cope(this.clbBed, (DevExpress.XtraEditors.CheckedListBoxControl)IffieldBens);

        }

        //绑定使用的排序方式回调函数
        public void ExeBindingUseOrderBy(object UseOrderBy)
        {
            this.copeList(this.lbcUseOrderBy, (DevExpress.XtraEditors.ListBoxControl)UseOrderBy);
        }

        //绑定未使用的排序方式回调函数
        public void ExeBindingNoUseOrderBy(object NoUseOrderBy)
        {
            this.copeList(this.lbcNoUseOrderBy, (DevExpress.XtraEditors.ListBoxControl)NoUseOrderBy);
        }

        #endregion

        #region 补助方法

        // 将旧的控件复制到新的控件
        private void cope(DevExpress.XtraEditors.CheckedListBoxControl oldLBC, DevExpress.XtraEditors.CheckedListBoxControl newLBC)
        {
            oldLBC.Items.Clear();
            DevExpress.XtraEditors.CheckedListBoxControl newListBoxControl = newLBC as DevExpress.XtraEditors.CheckedListBoxControl;
            if(newListBoxControl != null)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem item in newListBoxControl.Items)
                {
                    oldLBC.Items.Add(item);
                }
            }
        }

        // 将旧的控件复制到新的控件
        private void copeList(DevExpress.XtraEditors.ListBoxControl oldLBC, DevExpress.XtraEditors.ListBoxControl newLBC)
        {
            oldLBC.Items.Clear();
            DevExpress.XtraEditors.ListBoxControl newListBoxControl = newLBC as DevExpress.XtraEditors.ListBoxControl;
            if(newListBoxControl != null)
            {
                foreach(string item in newListBoxControl.Items)
                {
                    oldLBC.Items.Add(item);
                }
            }
        }

        //将未选着的排序方式list中选着的一行转移到已选择的排序方式list中
        private void Tolift()
        {
            if(this.lbcNoUseOrderBy.SelectedItem != null)
            {
                string selectItem = this.lbcNoUseOrderBy.SelectedItem.ToString();
                this.lbcNoUseOrderBy.Items.Remove(selectItem);
                this.lbcUseOrderBy.Items.Add(selectItem);
            }
        }

        //将已选择的排序方式list中选着的一行转移到未选择的排序方式list中
        private void ToRitht()
        {
            if(this.lbcUseOrderBy.SelectedItem != null)
            {
                string selectItem = this.lbcUseOrderBy.SelectedItem.ToString();
                this.lbcUseOrderBy.Items.Remove(selectItem);
                this.lbcNoUseOrderBy.Items.Add(selectItem);
            }
            //将未选着的排序方式list中选着的一行转移到已选择的排序方式list中
        }

        #endregion
    }
}
