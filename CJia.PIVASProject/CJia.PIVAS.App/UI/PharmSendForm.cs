using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class PharmSendForm : Form
    {
        public PharmSendForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新构造函数
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="type">窗体类别</param>
        public PharmSendForm(DataTable data)
        {
            InitializeComponent();
            UI.PharmSendDetailView psduc = new UI.PharmSendDetailView(data);
            this.Controls.Add(psduc);
            psduc.Dock = DockStyle.Fill;
            psduc.CloseForm += psduc_CloseForm;
        }
        public PharmSendForm(DataTable data, int timeID)
        {
            InitializeComponent();
            this.Text = "库存提示";
            UI.PharmStoreMessageView psmuc = new UI.PharmStoreMessageView(data, timeID);
            this.Controls.Add(psmuc);
            psmuc.Dock = DockStyle.Fill;
            psmuc.CloseForm += psduc_CloseForm;
        }
        //关闭窗体
        void psduc_CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
