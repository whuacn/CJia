using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewInfactView : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql1 = @" SELECT { [Measures].[INFACT FACT 计数] } ON COLUMNS, 
 { ([SURGERY LEVEL DIM].[SURGERY LEVEL NAME].[SURGERY LEVEL NAME].ALLMEMBERS * [SURGERY LEVEL TYPE DIM].[SURGERY LEVEL TYPE NAME].[SURGERY LEVEL TYPE NAME].ALLMEMBERS ) }
   ON ROWS
  FROM [JJFB]";
            sql1 += e.filterDataDeptStr;
            DataTable data1 = CJia.DefaultOleDb.Query(sql1);

            data1 = DataTableHelper.MergeCol(data1, new List<int>() { 0, 1 });

            //DataTable newTable = new DataTable();
            //newTable.Columns.Add("name",typeof(string));
            //newTable.Columns.Add("value", typeof(string));

            //for (int i = 0; i < data1.Rows.Count; i++)
            //{
            //    DataRow dr = newTable.NewRow();
            //    dr["name"]= data1.Rows[i][0].ToString() + data1.Rows[i][1].ToString();
            //    dr["value"] = data1.Rows[i][2];
            //    newTable.Rows.Add(dr);
            //}

            string sql2 = @"SELECT { [Measures].[手术后感染例数] } ON COLUMNS, { ([SURGERY LEVEL DIM].[SURGERY LEVEL NAME].[SURGERY LEVEL NAME].ALLMEMBERS ) } 
               ON ROWS 
               FROM [JJFB]";
            sql2 += e.filterDataDeptStr;
            DataTable data2 = CJia.DefaultOleDb.Query(sql2);
            foreach(DataRow dr in data2.Rows)
            {
                dr[0] = dr[0] + "手术感染例数";
            }
            //            string sql3 = @" SELECT NON EMPTY { [Measures].[手术后感染例数], [Measures].[手术感染发病率],[Measures].[0  级手术总例数],[Measures].[I  级手术总例数], [Measures].[II 级手术总例数], 
            //	   [Measures].[III级手术总例数]
            //	    } ON ROWS,
            //	    {[DATE DIM].[DATE YEAR].[DATE YEAR].&[ALL] } on columns
            //	   FROM [JJFB]";
            string sql3 = @" SELECT { [Measures].[手术后感染例数], [Measures].[手术感染发病率],[Measures].[0  级手术总例数],[Measures].[I  级手术总例数], [Measures].[II 级手术总例数], 
	   [Measures].[III级手术总例数]
	    } ON ROWS,
	    {[DATE DIM].[DATE TIME].[ALL] } on columns
	   FROM [JJFB]";
            sql3 += e.filterDataDeptStr;
            DataTable data3 = CJia.DefaultOleDb.Query(sql3);
            DataTable newTable = DataTableHelper.MergeDataTabelColSame(data1, data2);

            string sql4 = @" SELECT 
         { 
	        [Measures].[呼吸机相关肺炎发病率（%）],
 [Measures].[留置导尿管相关泌尿系感染发病率（%）], 
[Measures].[血管导管相关血流感染率（%）]
         } ON rows,
         {[DATE DIM].[DATE TIME].[ALL]} ON COLUMNS
         from [JJFB]";
            sql4 += e.filterDataDeptStr;
            DataTable data4 = CJia.DefaultOleDb.Query(sql4);
            // 修改显示方式：如果显示为0%，则让其显示为空
            for(int i = 0; i < data4.Rows.Count; i++)
            {
                if(data4.Rows[i][1].ToString() == "0")
                {
                    data4.Rows[i][1] = "";
                }
            }

            newTable = DataTableHelper.MergeDataTabelColSame(newTable, data4);
            newTable = DataTableHelper.MergeDataTabelColSame(newTable, data3);

            List<string> orderRow = new List<string>();
            orderRow.Add("呼吸机相关肺炎发病率（%）");
            orderRow.Add("留置导尿管相关泌尿系感染发病率（%）");
            orderRow.Add("血管导管相关血流感染率（%）");
            orderRow.Add("手术后感染例数");
            orderRow.Add("手术感染发病率");
            orderRow.Add("0  级手术总例数");
            orderRow.Add("0  级手术感染例数");
            orderRow.Add("0  级浅层组织手术");
            orderRow.Add("0  级深部组织手术");
            orderRow.Add("0  级器官部位手术");
            orderRow.Add("0  级腔隙部位手术");
            orderRow.Add("I  级手术总例数");
            orderRow.Add("I  级手术感染例数");
            orderRow.Add("I  级浅层组织手术");
            orderRow.Add("I  级深部组织手术");
            orderRow.Add("I  级器官部位手术");
            orderRow.Add("I  级腔隙部位手术");
            orderRow.Add("II 级手术总例数");
            orderRow.Add("II 级手术感染例数");
            orderRow.Add("II 级浅层组织手术");
            orderRow.Add("II 级深部组织手术");
            orderRow.Add("II 级器官部位手术");
            orderRow.Add("II 级腔隙部位手术");
            orderRow.Add("III级手术总例数");
            orderRow.Add("III级手术感染例数");
            orderRow.Add("III级浅层组织手术");
            orderRow.Add("III级深部组织手术");
            orderRow.Add("III级器官部位手术");
            orderRow.Add("III级腔隙部位手术");
            newTable = DataTableHelper.RowOrder(newTable, newTable.Columns[0].ColumnName, orderRow);

            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            oldToNew.Add("呼吸机相关肺炎发病率（%）", "（一）重症监护感染_  1、呼吸机相关肺炎发病率（%）");
            oldToNew.Add("留置导尿管相关泌尿系感染发病率（%）", "（一）重症监护感染_  2、留置导尿管相关泌尿系感染发病率（%）");
            oldToNew.Add("血管导管相关血流感染率（%）", "（一）重症监护感染_  3、血管导管相关血流感染率（%）");
            oldToNew.Add("手术后感染例数", "（二）手术部位感染_  1、手术后感染例数");
            oldToNew.Add("手术感染发病率", "（二）手术部位感染_  2、手术感染发病率");
            oldToNew.Add("0  级手术总例数", "（二）手术部位感染_  3、0  级手术总例数");
            oldToNew.Add("0  级手术感染例数", "（二）手术部位感染_   （1）0  级手术感染例数");
            oldToNew.Add("0  级浅层组织手术", "（二）手术部位感染_   （2）0  级浅层组织手术");
            oldToNew.Add("0  级深部组织手术", "（二）手术部位感染_   （3）0  级深部组织手术");
            oldToNew.Add("0  级器官部位手术", "（二）手术部位感染_   （4）0  级器官部位手术");
            oldToNew.Add("0  级腔隙部位手术", "（二）手术部位感染_   （5）0  级腔隙部位手术");
            oldToNew.Add("I  级手术总例数", "（二）手术部位感染_  4、I  级手术总例数");
            oldToNew.Add("I  级手术感染例数", "（二）手术部位感染_   （1）I  级手术感染例数");
            oldToNew.Add("I  级浅层组织手术", "（二）手术部位感染_   （2）I  级浅层组织手术");
            oldToNew.Add("I  级深部组织手术", "（二）手术部位感染_   （3）I  级深部组织手术");
            oldToNew.Add("I  级器官部位手术", "（二）手术部位感染_   （4）I  级器官部位手术");
            oldToNew.Add("I  级腔隙部位手术", "（二）手术部位感染_   （5）I  级腔隙部位手术");
            oldToNew.Add("II 级手术总例数", "（二）手术部位感染_  5、II 级手术总例数");
            oldToNew.Add("II 级手术感染例数", "（二）手术部位感染_   （1）II 级手术感染例数");
            oldToNew.Add("II 级浅层组织手术", "（二）手术部位感染_   （2）II 级浅层组织手术");
            oldToNew.Add("II 级深部组织手术", "（二）手术部位感染_   （3）II 级深部组织手术");
            oldToNew.Add("II 级器官部位手术", "（二）手术部位感染_   （4）II 级器官部位手术");
            oldToNew.Add("II 级腔隙部位手术", "（二）手术部位感染_   （5）II 级腔隙部位手术");
            oldToNew.Add("III级手术总例数", "（二）手术部位感染_  6、III级手术总例数");
            oldToNew.Add("III级手术感染例数", "（二）手术部位感染_   （1）III级手术感染例数");
            oldToNew.Add("III级浅层组织手术", "（二）手术部位感染_   （2）III级浅层组织手术");
            oldToNew.Add("III级深部组织手术", "（二）手术部位感染_   （3）III级深部组织手术");
            oldToNew.Add("III级器官部位手术", "（二）手术部位感染_   （4）III级器官部位手术");
            oldToNew.Add("III级腔隙部位手术", "（二）手术部位感染_   （5）III级腔隙部位手术");

            newTable = DataTableHelper.UpdateDataRow(newTable, newTable.Columns[0].ColumnName, oldToNew);
            newTable.Columns[0].ColumnName = "项目名称";
            newTable.Columns[1].ColumnName = "本期数量";
            newTable.Rows[0][1] = newTable.Rows[0][1] != null && newTable.Rows[0][1].ToString() != "" ? Math.Round(double.Parse(newTable.Rows[0][1].ToString()), 4) * 100 + "%" : newTable.Rows[0][1];
            newTable.Rows[1][1] = newTable.Rows[1][1] != null && newTable.Rows[1][1].ToString() != "" ? Math.Round(double.Parse(newTable.Rows[1][1].ToString()), 4) * 100 + "%" : newTable.Rows[1][1];
            newTable.Rows[2][1] = newTable.Rows[2][1] != null && newTable.Rows[2][1].ToString() != "" ? Math.Round(double.Parse(newTable.Rows[2][1].ToString()), 4) * 100 + "%" : newTable.Rows[2][1];
            newTable.Rows[4][1] = newTable.Rows[4][1] != null && newTable.Rows[4][1].ToString() != "" ? Math.Round(double.Parse(newTable.Rows[4][1].ToString()), 4) * 100 + "%" : newTable.Rows[4][1];
            return newTable;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewInfactView()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "医院感染质量情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}
