using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace CJia.PIVAS.App.UI.Label
{
    public partial class FilterBatchView : XtraUserControl
    {
        /// <summary>
        /// 赛选瓶贴用户控件
        /// </summary>
        public FilterBatchView()
        {
            InitializeComponent();
        }

        public bool isAll
        {
            get
            {
                return this.ckeBatch.Checked;
            }
        }


        public List<string> selectBatch
        {
            get
            {
                List<string> nselectBatch = new List<string>();
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbBatch.Items)
                {
                    if(CheckedListBoxItem.CheckState == CheckState.Checked)
                    {
                        nselectBatch.Add(CheckedListBoxItem.Value.ToString());
                    }
                }
                return nselectBatch;
            }
        }

        public List<string> selectBatchName
        {
            get
            {
                List<string> nselectBatchName = new List<string>();
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbBatch.Items)
                {
                    if(CheckedListBoxItem.CheckState == CheckState.Checked)
                    {
                        nselectBatchName.Add(CheckedListBoxItem.Description.ToString());
                    }
                }
                return nselectBatchName;
            }
        }

        /// <summary>
        /// 绑定所有病区
        /// </summary>
        /// <param name="Batch"></param>
        public void BindData(Dictionary<string, string> Batch)
        {
            this.clbBatch.Items.Clear();
            foreach(string key in Batch.Keys)
            {
                DevExpress.XtraEditors.Controls.CheckedListBoxItem checkedListBoxItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Batch[key],key , CheckState.Checked);
                this.clbBatch.Items.Add(checkedListBoxItem);
            }
        }

        /// <summary>
        /// 获取选着的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void ckeBatch_CheckedChanged(object sender, EventArgs e)
        {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbBatch.Items)
                {
                    if(this.ckeBatch.Checked == true)
                    {
                        CheckedListBoxItem.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        CheckedListBoxItem.CheckState = CheckState.Unchecked;
                    }
                }
        }
    }
}
