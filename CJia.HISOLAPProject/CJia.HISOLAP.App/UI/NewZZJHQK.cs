using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewZZJHQK : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"SELECT NON EMPTY { 
                             [Measures].[非预期的24/48小时重返重症医学科率（%）],
                             [Measures].[呼吸机相关肺炎预防率（%）], 
                             [Measures].[呼吸机相关肺炎发病率（%）],
                             [Measures].[中心静脉置留相关血流感染发生率（%）],
                             [Measures].[留置导尿管相关泌尿系感染发病率（%）],
                             [Measures].[重症患者死亡率（%）],
                             [Measures].[重症患者压疮发生率（%）], 
                             [Measures].[人工气道脱出总数],
                             [Measures].[气道脱出再次插入总数] 
                              } ON rows,
                            {[DATE DIM].[DATE TIME].[All]} ON COLUMNS
                             FROM [JJFB]";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string> { { 0, "项目名称" }, { 1, "本期数量" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            //（一）资源配置
            oldToNew.Add("非预期的24/48小时重返重症医学科率（%）", "（一）重症医学（ICU）质量_      1、非预期的24/48小时重返重症医学科率（%）");
            oldToNew.Add("呼吸机相关肺炎预防率（%）", "（一）重症医学（ICU）质量_      2、呼吸机相关肺炎预防率（%）");
            oldToNew.Add("呼吸机相关肺炎发病率（%）", "（一）重症医学（ICU）质量_      3、呼吸机相关肺炎发病率（%）");
            oldToNew.Add("中心静脉置留相关血流感染发生率（%）", "（一）重症医学（ICU）质量_      4、中心静脉置留相关血流感染发生率（%）");
            oldToNew.Add("留置导尿管相关泌尿系感染发病率（%）", "（一）重症医学（ICU）质量_      5、留置导尿管相关泌尿系感染发病率（%）");
            oldToNew.Add("重症患者死亡率（%）", "（一）重症医学（ICU）质量_      6、重症患者死亡率（%）");
            oldToNew.Add("重症患者压疮发生率（%）", "（一）重症医学（ICU）质量_      7、重症患者压疮发生率（%）");
            oldToNew.Add("人工气道脱出总数", "（一）重症医学（ICU）质量_      8、人工气道脱出总数");
            oldToNew.Add("气道脱出再次插入总数", "（一）重症医学（ICU）质量_      9、气道脱出再次插入总数");
            data = DataTableHelper.UpdateDataRow(data, "项目名称", oldToNew);
            for(int i = 0; i < data.Rows.Count - 2; i++)
            {
                data.Rows[i][1] = Math.Round(Convert.ToDouble(data.Rows[i][1]), 4) * 100 + "%";
            }
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewZZJHQK()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "住院重症监护情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}
