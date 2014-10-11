using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;

namespace CJia.Tools.UI
{
    public partial class SyetemConfigView : DevExpress.XtraEditors.XtraUserControl , Views.ISystemConfigView
    {
        public SyetemConfigView()
        {
            InitializeComponent();
            this.CreatePresenter();
        }

        // 服务器数据库配置
        private Dictionary<string, List<string>> DBConfig
        {
            get;
            set;
        }

        protected object CreatePresenter()
        {
            return new Presenters.SyetemConfigPresenter(this);
        }

        // 系统编号发生改变时发生
        private void cmbSystemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> dbNames = new List<string>();
            foreach(string str in this.DBConfig[this.cmbSystemNo.SelectedItem.ToString()])
            {
                dbNames.Add(str.Split(new char[]{'_'}, StringSplitOptions.RemoveEmptyEntries)[0]);
            }
            this.cmbDBName.Properties.Items.Clear();
            this.cmbDBName.Properties.Items.AddRange(dbNames);
            this.cmbDBName.SelectedIndex = 0;
            this.InitDBTypeAndDBString();
        }

        // 数据连接发生改变时发生
        private void cmbDBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitDBTypeAndDBString();
        }

        // 绑定数据库类型以及数据库连接字符串
        private void InitDBTypeAndDBString()
        {
            foreach(string str in this.DBConfig[this.cmbSystemNo.SelectedItem.ToString()])
            {
                if(str.IndexOf(this.cmbDBName.SelectedItem.ToString() + "_") == 0)
                {
                    this.txtDBType.Text = str.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    this.txtDBString.Text = str.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[2];
                }
            }
        }


        // 创建系统数据库按钮单击事件
        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.CreateSystemTable(sender, e);
        }

        #region ISystemConfigView 成员

        /// <summary>
        /// 系统表常见sql语句模板
        /// </summary>
        public string ModelSql
        {
            get
            {
                return this.txtModel.Text;
            }
            set
            {
                this.txtModel.Text = value;
            }
        }

        public string SystemNO
        {
            get
            {
                return this.cmbSystemNo.SelectedItem.ToString();
            }
        }

        public string DBName
        {
            get
            {
                return this.cmbDBName.SelectedItem.ToString();
            }
        }

        public event EventHandler CreateSystemTable;

        public void InitDBConfig(Dictionary<string, List<string>> dbConfig)
        {
            this.DBConfig = dbConfig;
            this.cmbSystemNo.Properties.Items.AddRange(this.DBConfig.Keys);
            this.cmbSystemNo.SelectedIndex = 0;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void InitSchedule(int max)
        {
            this.pbcSchedule.Properties.Maximum = max;
            this.pbcSchedule.Properties.Minimum = 0;
            this.pbcSchedule.Properties.Step = 1;
            this.pbcSchedule.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.pbcSchedule.BackColor = Color.Blue;
            this.pbcSchedule.Position = 0;
        }

        public void NextSchedule()
        {
            this.pbcSchedule.PerformStep();
            this.pbcSchedule.Refresh();
        }

        #endregion


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
