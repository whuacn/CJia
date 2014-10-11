using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HISOLAP.Web.UI
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAll();
            }
        }
        private void BindAll()
        {
            Bind(WebChartControl1, ASPxGridView1, "YY", "MM", "TOTAL", SqlText.SqlMCRS3, SqlText.SqlMCRS2);
        }
        public string Conn = ConfigHelper.GetAppStrings("conn");
        private void Bind(DevExpress.XtraCharts.Web.WebChartControl chart, DevExpress.Web.ASPxGridView.ASPxGridView grid, string str1, string str2, string str3, string sql1, string sql2)
        {
            using (Adapter ad = new Adapter(Conn))
            {
                DataTable data = ad.Query(sql1, null);
                chart.Series.Clear();
                chart.SeriesDataMember = str1;
                chart.SeriesSorting = DevExpress.XtraCharts.SortingMode.Ascending;
                chart.SeriesTemplate.ArgumentDataMember = str2;
                chart.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                chart.SeriesTemplate.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Ascending;
                chart.SeriesTemplate.ValueDataMembersSerializable = str3;
                chart.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                chart.SeriesTemplate.ValueScaleType = ScaleType.Numerical;
                chart.PaletteName = "Metro";
                chart.DataSource = data;
                chart.DataBind();
                DataTable data2 = ad.Query(sql2, null);
                grid.DataSource = data2;
                grid.DataBind();
            }
        }

    }
}