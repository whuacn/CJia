using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class ReviewChart : System.Web.UI.Page
    {
        public string Data = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        /// <summary>
        /// 将DataTable转换为JSon数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string CreateJsonData(DataTable dt)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ name: ");
                    JsonString.Append("'" + dt.Rows[i][0].ToString() + "',");
                    JsonString.Append("data: [");
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append(dt.Rows[i][j].ToString() + ",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append(dt.Rows[i][j].ToString() + "]");
                        }
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }
        
        private void GetData()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable data = ad.Query(@"select * from vw_grade", null);
                Data = CreateJsonData(data);
            }
        }
    }
}