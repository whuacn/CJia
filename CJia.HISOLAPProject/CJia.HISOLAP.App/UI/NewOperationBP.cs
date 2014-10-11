using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewOperationBP : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @" SELECT NON EMPTY { [Measures].[一、二代头孢菌素使用比率],
[Measures].[万古霉素喹若酮等比率],
[Measures].[术前一小时内使用比率],
[Measures].[术前二小时内使用比率],
[Measures].[血量大于1500ml比率],
[Measures].[手术超三小时使用比率],
 [Measures].[术后24小时停止使用比率],
[Measures].[术后48小时停止使用比率],
 [Measures].[术后72小时停止使用比率],
 [Measures].[术后72小时继续使用比率]
  } ON COLUMNS, 
 { ([PERIOPERATIVE DIM].[SHOW NAME].[SHOW NAME].ALLMEMBERS ) }  ON ROWS
 FROM  [JJFB]";
            sql += e.filterDataDeptStr;
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "手术名称" } });
            if(data != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    //oldToNew.Add(data.Rows[i][0].ToString(), i + 1 + ")" + data.Rows[i][0].ToString());
                    data.Rows[i][1] = data.Rows[i][1].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][1].ToString()), 4) * 100 : data.Rows[i][1];
                    data.Rows[i][2] = data.Rows[i][2].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][2].ToString()), 4) * 100 : data.Rows[i][2];
                    data.Rows[i][3] = data.Rows[i][3].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][3].ToString()), 4) * 100 : data.Rows[i][3];
                    data.Rows[i][4] = data.Rows[i][4].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][4].ToString()), 4) * 100 : data.Rows[i][4];
                    data.Rows[i][5] = data.Rows[i][5].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][5].ToString()), 4) * 100 : data.Rows[i][5];
                    data.Rows[i][6] = data.Rows[i][6].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][6].ToString()), 4) * 100 : data.Rows[i][6];
                    data.Rows[i][7] = data.Rows[i][7].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][7].ToString()), 4) * 100 : data.Rows[i][7];
                    data.Rows[i][8] = data.Rows[i][8].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][8].ToString()), 4) * 100 : data.Rows[i][8];
                    data.Rows[i][9] = data.Rows[i][9].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][9].ToString()), 4) * 100 : data.Rows[i][9];
                    data.Rows[i][10] = data.Rows[i][10].ToString().Length > 0 ? Math.Round(double.Parse(data.Rows[i][10].ToString()), 4) * 100 : data.Rows[i][10];
                }
            }
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewOperationBP()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "围手术期预防情况";
            this.ReportType = Report.ReportType.Vertical;
        }

    }
}

