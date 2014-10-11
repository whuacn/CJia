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
    public partial class FilterIllfieldView : XtraUserControl
    {
        /// <summary>
        /// 赛选瓶贴用户控件
        /// </summary>
        public FilterIllfieldView()
        {
            InitializeComponent();
        }

        public bool isALL
        {
            get
            {
                return this.ckeBen.Checked;
            }
        }

        public List<string> selectIllfield
        {
            get
            {
                List<string> nselectIllfield = new List<string>();
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbIllfield.Items)
                {
                    if(CheckedListBoxItem.CheckState == CheckState.Checked)
                    {
                        nselectIllfield.Add(CheckedListBoxItem.Value.ToString());
                    }
                }
                return nselectIllfield;
            }
        }


        public List<string> selectIllfieldName
        {
            get
            {
                List<string> nselectIllfieldName = new List<string>();
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbIllfield.Items)
                {
                    if(CheckedListBoxItem.CheckState == CheckState.Checked)
                    {
                        nselectIllfieldName.Add(CheckedListBoxItem.Description.ToString());
                    }
                }
                return nselectIllfieldName;
            }
        }

        /// <summary>
        /// 绑定所有病区
        /// </summary>
        /// <param name="Illfield"></param>
        public void BindData(Dictionary<string, string> Illfield)
        {
            this.clbIllfield.Items.Clear();
            List<string> keys = Illfield.Keys.ToList<string>();
            keys.Sort();
            foreach(string key in keys)
            {
                DevExpress.XtraEditors.Controls.CheckedListBoxItem checkedListBoxItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Illfield[key],key , CheckState.Checked);
                this.clbIllfield.Items.Add(checkedListBoxItem);
            }
        }

        public void BindOneIllfield(Dictionary<string, string> Illfields, string Illfield)
        {
            this.ckeBen.Checked = false;
            this.clbIllfield.Items.Clear();
            List<string> keys = Illfields.Keys.ToList<string>();
            keys.Sort();
            foreach(string key in keys)
            {
                if(Illfields[key] == Illfield)
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem checkedListBoxItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Illfields[key], key, CheckState.Checked);
                    this.clbIllfield.Items.Add(checkedListBoxItem);
                }
                else
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem checkedListBoxItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Illfields[key], key, CheckState.Unchecked);
                    this.clbIllfield.Items.Add(checkedListBoxItem);
                }
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
            if(this.clbIllfield.Items != null && this.clbIllfield.Items.Count > 0)
            {
                foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem CheckedListBoxItem in this.clbIllfield.Items)
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
}
