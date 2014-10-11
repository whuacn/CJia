using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Server
{
    public partial class AddSystemNO : Form
    {
        public AddSystemNO()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.txtDBConection.Text)
                || string.IsNullOrWhiteSpace(this.txtDBName.Text)
                || string.IsNullOrWhiteSpace(this.txtDBType.Text)
                || string.IsNullOrWhiteSpace(this.txtSystemNO.Text))
            {
                MessageBox.Show("数据填写不够完整！");
            }
            Dictionary<string,string> appStrings = ConfigHelper.GetAllAppStrings();
            foreach( string key in appStrings.Keys)
            {
                if(key.Split(new char[]{'^'})[0] == this.txtSystemNO.Text)
                {
                    MessageBox.Show("该系统编号已经存在！");
                    return;
                }
            }
            string newKey = this.txtSystemNO.Text + "^" + this.txtDBName.Text;
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
            MessageBox.Show("增加系统编号已经旗下的数据库成功！");
            this.Close();
        }
    }
}
