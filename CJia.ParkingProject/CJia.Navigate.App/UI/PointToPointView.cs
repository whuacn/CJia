using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Navigate.App.UI
{
    public partial class PointToPointView : UserControl
    {
        public PointToPointView()
        {
            InitializeComponent();
            DataTable dtPoint = CJia.DefaultPostgre.Query(CJia.Parking.Models.SqlTools.SqlQueryAllPoint);
            cmbStart.Properties.DataSource = dtPoint;
            cmbStart.Properties.DisplayMember = "point_no";
            cmbStart.Properties.ValueMember = "point_id";
            cmbEnd.Properties.DataSource = dtPoint;
            cmbEnd.Properties.DisplayMember = "point_no";
            cmbEnd.Properties.ValueMember = "point_id";
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string start = cmbStart.EditValue.ToString();
            string ob = cmbEnd.EditValue.ToString();
            string[] end = ob.Split(new char[] { ',' });
            string sql = @"insert into gm_to_point(point_id,to_point_id,status,create_date)
                        values(:1,:2,'1',now())";
            for(int i=0;i<end.Length;i++)
            {
                CJia.DefaultPostgre.Execute(sql, new object[] { start, end[i] });
            }
            MessageBox.Show("插入成功");
        }
    }
}
