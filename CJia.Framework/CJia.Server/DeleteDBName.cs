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
    public partial class DeleteDBName : Form
    {
        public DeleteDBName()
        {
            InitializeComponent();
            this.Init();

        }

        private void Init()
        {
            this.cmbSystemNO.Items.Clear();
            Dictionary<string, string> appStrings = ConfigHelper.GetAllAppStrings();
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

        private void cmbSystemNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitDBName();
        }

        private void InitDBName()
        {
            this.cmbDBName.Items.Clear();
            Dictionary<string, string> appStrings = ConfigHelper.GetAllAppStrings();
            foreach(string key in appStrings.Keys)
            {
                if(key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[0] == this.cmbSystemNO.SelectedItem.ToString())
                {
                    this.cmbDBName.Items.Add(key.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }
            }
            if(this.cmbDBName.Items.Count > 0)
            {
                this.cmbDBName.SelectedIndex = 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(ConfigHelper.IsExist(this.cmbSystemNO.SelectedItem.ToString() + "^" + this.cmbDBName.SelectedItem.ToString()))
            {
                ConfigHelper.DeleteAppStrings(this.cmbSystemNO.SelectedItem.ToString() + "^" + this.cmbDBName.SelectedItem.ToString());
                MessageBox.Show("\"" + this.cmbSystemNO.SelectedItem.ToString() + "系统下的\"" + this.cmbDBName.SelectedItem.ToString() + "\"数据库删除成功");
                Dictionary<string, string> appStrings = ConfigHelper.GetAllAppStrings();
                this.Close();
            }
            else
            {
                MessageBox.Show("\"" + this.cmbSystemNO.SelectedItem.ToString() + "系统下的\"" + this.cmbDBName.SelectedItem.ToString() + "\"数据库不存在");
            }
        }
    }
}
