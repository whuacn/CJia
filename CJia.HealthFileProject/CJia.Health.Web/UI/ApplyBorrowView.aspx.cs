using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class ApplyBorrowView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PATIENT_NAME");
            dt.Columns.Add("GENDER");
            dt.Columns.Add("BIRTHDAY");
            dt.Columns.Add("IS_MARRY");
            dt.Columns.Add("ICD_OUTDIA1");
            dt.Rows.Add("胡杨", "男", "22", "未婚", "脑残");
            gvPatient.DataSource = dt;
            gvPatient.DataBind();
        }
    }
}