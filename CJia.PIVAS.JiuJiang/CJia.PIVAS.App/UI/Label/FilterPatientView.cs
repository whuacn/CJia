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
    public partial class FilterPatientView : XtraUserControl
    {
        /// <summary>
        /// 赛选瓶贴用户控件
        /// </summary>
        public FilterPatientView()
        {
            InitializeComponent();
        }

        public List<string> selectPatient
        {
            get
            {
                List<string> nselectPatient = new List<string>();
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbBed.Items)
                {
                    if(CheckedListBoxItem.CheckState == CheckState.Checked)
                    {
                        nselectPatient.Add(CheckedListBoxItem.Value.ToString());
                    }
                }
                return nselectPatient;
            }
        }

        /// <summary>
        /// 绑定所有病人
        /// </summary>
        /// <param name="patient"></param>
        public void BindData(Dictionary<string, string> patient)
        {
            this.clbBed.Items.Clear();
            List<string> keys = patient.Keys.ToList<string>();
            foreach(string key in keys)
            {
                DevExpress.XtraEditors.Controls.CheckedListBoxItem checkedListBoxItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(patient[key],key , CheckState.Checked);
                this.clbBed.Items.Add(checkedListBoxItem);
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

        private void ckeBen_CheckedChanged(object sender, EventArgs e)
        {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbBed.Items)
                {
                    if(this.ckeBen.Checked == true)
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
