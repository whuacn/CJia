using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Views;

namespace CJia.Health.App.UI
{
    public partial class UserWorkStat : CJia.Health.Tools.View, CJia.Health.Views.IUserWorkStat
    {
        public UserWorkStat()
        {
            InitializeComponent();
            InitPage();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.UserWorkStatPresenter(this);
        }

        public void InitPage()
        {
            dtStart.DateTime = DateTime.Parse(Sysdate.ToShortDateString()).AddMonths(-1);
            dtEnd.DateTime = DateTime.Parse(Sysdate.ToShortDateString()).AddDays(1).AddSeconds(-1);
        }
        public event EventHandler<UserWorkStatArgs> OnQuery;
        public void ExeBindTatalData(DataTable data)
        {
            DataColumn col = new DataColumn("PRICE", typeof(float));
            data.Columns.Add(col);
            DataColumn col2 = new DataColumn("TOTALPRICE", typeof(float));
            data.Columns.Add(col2);
            float price;
            try
            {
                price = float.Parse(txtPrice.Text);
            }
            catch
            {
                price = 0;
            }
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    dr["PRICE"] = price;
                    dr["TOTALPRICE"] = price * int.Parse(dr["TOTAL"].ToString());
                }
            }
            gcTatal.Visible = true;
            gcAll.Visible = false;
            gcTatal.DataSource = data;
        }
        public void ExeBindAllData(DataTable data)
        {
            gcTatal.Visible = false;
            gcAll.Visible = true;
            gcAll.DataSource = data;
        }
        Views.UserWorkStatArgs userWorkArgs = new Views.UserWorkStatArgs();

        private void btnSearch1_Click_1(object sender, EventArgs e)
        {
            if (OnQuery != null)
            {
                userWorkArgs.StartDate = dtStart.DateTime;
                userWorkArgs.EndDate = dtEnd.DateTime;
                userWorkArgs.UserNO = txtKey.Text.Trim();
                userWorkArgs.isAll = ckAll.Checked;
                OnQuery(null, userWorkArgs);
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnSearch1.Focus();
                    btnSearch1_Click_1(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
