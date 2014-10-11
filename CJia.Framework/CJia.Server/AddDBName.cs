using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Net.Data;

namespace CJia.Server
{
    public partial class AddDBName : Form
    {
        public AddDBName()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            Dictionary<string,string> appStrings = ConfigHelper.GetAllAppStrings();
            Dictionary<string, Dictionary<string, DBConnection>> dbConfig = this.ConvertDBConfig(appStrings);
            foreach(string key in dbConfig.Keys)
            {
                this.cmbSystemNO.Items.Add(key);
            }
            if(this.cmbSystemNO.Items.Count > 0)
            {
                this.cmbSystemNO.SelectedIndex = 0;
            }
        }

        private Dictionary<string, Dictionary<string, DBConnection>> ConvertDBConfig(Dictionary<string, string> appStrings)
        {
            Dictionary<string, Dictionary<string, DBConnection>> dicDBConfig = new Dictionary<string, Dictionary<string, DBConnection>>();
            foreach(string key in appStrings.Keys)
            {
                string strSystemNO = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBName = key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                string strDBType = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string strDBConection = appStrings[key].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1];
                bool isExist = false;
                foreach(string DBConfigKey in dicDBConfig.Keys)
                {
                    if(DBConfigKey == strSystemNO)
                    {
                        isExist = true;
                    }
                }
                if(isExist)
                {
                    dicDBConfig[strSystemNO].Add(strDBName, new DBConnection(strDBType, strDBConection));
                }
                else
                {
                    Dictionary<string, DBConnection> dicDBConnection = new Dictionary<string, DBConnection>();
                    dicDBConnection.Add(strDBName, new DBConnection(strDBType, strDBConection));
                    dicDBConfig.Add(strSystemNO, dicDBConnection);
                }
            }
            return dicDBConfig;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtDBConection.Text)
               || string.IsNullOrWhiteSpace(this.txtDBName.Text)
               || string.IsNullOrWhiteSpace(this.txtDBType.Text)
               || string.IsNullOrWhiteSpace(this.cmbSystemNO.SelectedItem.ToString()))
            {
                MessageBox.Show("数据填写不够完整！");
            }
            Dictionary<string, string> appStrings = ConfigHelper.GetAllAppStrings();
            string newKey = this.cmbSystemNO.SelectedItem.ToString() + "^" + this.txtDBName.Text;
            string newValue = this.txtDBType.Text + "^" + this.txtDBConection.Text;
            if(!ConfigHelper.IsExist(newKey))
            {
                ConfigHelper.AddAppStrings(newKey, newValue);
            }
            else
            {
                MessageBox.Show("该系统编号下的该数据库名已经存在！");
                return;
            }
            MessageBox.Show("增加系统编号旗下的数据库成功！");
            this.Close();
        }
    }
}
