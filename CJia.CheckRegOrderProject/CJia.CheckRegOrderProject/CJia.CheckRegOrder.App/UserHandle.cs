using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.CheckRegOrder.App
{
    public partial class UserHandle : Form
    {
        public UserHandle()
        {
            InitializeComponent();
            UI.UserHandleView uhView = new UI.UserHandleView();
            this.Controls.Add(uhView);
            uhView.Dock = DockStyle.Fill;
            uhView.OnCancel += uhView_OnCancel;
        }
        public UserHandle(DataTable data)
        {
            InitializeComponent();
            UI.UserHandleView uhView = new UI.UserHandleView(data);
            this.Controls.Add(uhView);
            uhView.Dock = DockStyle.Fill;
            uhView.OnCancel += uhView_OnCancel;
        }

        void uhView_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
