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
    public partial class DeleteSystemNO : Form
    {
        public DeleteSystemNO()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            this.InitSystemNO();
        }

        private void InitSystemNO()
        {
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> appStrings = ConfigHelper.GetAllAppStrings();
            Dictionary<string, Dictionary<string, DBConnection>> dbConfig = this.ConvertDBConfig(appStrings);
            foreach( string key in dbConfig.Keys)
            {
                if(this.cmbSystemNO.SelectedItem.ToString() == key)
                {
                    if(MessageBox.Show("是否要删除系统编号\"" + this.cmbSystemNO.SelectedItem.ToString() + "\"?该系统编号下的所有数据库名都将被删除"
                        ,"警告", MessageBoxButtons.YesNo) 
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                         foreach(string key1 in appStrings.Keys)
                         {
                             if(key1.Split(new char[]{'^'}, StringSplitOptions.RemoveEmptyEntries)[0] == key )
                             {
                                 ConfigHelper.DeleteAppStrings(key1);
                             }
                         }
                         MessageBox.Show("删除系统编号\"" + this.cmbSystemNO.SelectedItem.ToString() + "\"成功！");
                         this.Close();
                    }
                }
            }
        }
    }
}
