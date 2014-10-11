using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewZYZDJBQK : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"SELECT { 
	                            [Measures].[期内出院例数],
	                            [Measures].[期内死亡例数], 
	                            [Measures].[期内死亡率], 
	                            [Measures].[15日再住院例数],
	                            [Measures].[15日再住院率],
                                [Measures].[31日再住院例数],
	                            [Measures].[31日再住院率], 
                                [Measures].[重点疾病平均住院天数],
	                            [Measures].[重点疾病平均住院费用]
	                            } ON COLUMNS, 
                             { (DESCENDANTS([MAIN DISEASES DIM].[PARENT DIS].[Level 02].ALLMEMBERS) ) }on rows 
                              FROM [JJFB]";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.MergeLevel(data, new List<int>() { 0, 1 });
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "住院重点疾病名称" }, { 1, "期内出院例数" }, { 2, "期内死亡例数" }, { 3, "期内死亡率" }, { 4, "15日在住院例数" }, { 5, "15日在住院率" }, { 6, "31日在住院例数" }, { 7, "31日在住院率" }, { 8, "平均住院天数" }, { 9, "平均住院费用" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            oldToNew.Add("急性心肌梗死", "住院重点疾病指标_1、急性心肌梗死");
            oldToNew.Add("充血性心力衰竭", "住院重点疾病指标_2、充血性心力衰竭");
            oldToNew.Add("脑出血和脑梗死", "住院重点疾病指标_3、脑出血和脑梗死");
            oldToNew.Add("创伤性颅脑损伤", "住院重点疾病指标_4、创伤性颅脑损伤");
            oldToNew.Add("消化道出血", "住院重点疾病指标_5、消化道出血");
            oldToNew.Add("累及身体多个部位损伤", "住院重点疾病指标_6、累及身体多个部位损伤");
            oldToNew.Add("细菌性肺炎", "住院重点疾病指标_7、细菌性肺炎");
            oldToNew.Add("慢性阻塞性肺疾病", "住院重点疾病指标_8、慢性阻塞性肺疾病");
            oldToNew.Add("糖尿病伴短期和长期并发症", "住院重点疾病指标_9、糖尿病伴短期和长期并发症");
            oldToNew.Add("糖尿病伴短期并发症", "住院重点疾病指标_      9.1、糖尿病伴短期并发症");
            oldToNew.Add("糖尿病伴长期并发症", "住院重点疾病指标_      9.2、糖尿病伴长期并发症");
            oldToNew.Add("下肢截肢手术糖尿病", "住院重点疾病指标_      9.3、下肢截肢手术糖尿病");
            oldToNew.Add("未控制血糖的糖尿病", "住院重点疾病指标_      9.4、未控制血糖的糖尿病");
            oldToNew.Add("结节性甲状腺肿", "住院重点疾病指标_10、结节性甲状腺肿");
            oldToNew.Add("急性阑尾炎伴弥漫性及脓肿", "住院重点疾病指标_11、急性阑尾炎伴弥漫性及脓肿");
            oldToNew.Add("前列腺增生", "住院重点疾病指标_12、前列腺增生");
            oldToNew.Add("肾衰竭", "住院重点疾病指标_13、肾衰竭");
            oldToNew.Add("败血症", "住院重点疾病指标_14、败血症");
            oldToNew.Add("高血压", "住院重点疾病指标_15、高血压");
            oldToNew.Add("急性胰腺炎", "住院重点疾病指标_16、急性胰腺炎");
            oldToNew.Add("恶性肿瘤术后化疗", "住院重点疾病指标_17、恶性肿瘤术后化疗");
            oldToNew.Add("恶性肿瘤维持性化疗", "住院重点疾病指标_18、恶性肿瘤维持性化疗");

            if(data != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i][5] = data.Rows[i][5] != null && data.Rows[i][5].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][5].ToString()), 4) * 100 + "%" : data.Rows[i][5];
                    data.Rows[i][3] = data.Rows[i][3] != null && data.Rows[i][3].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][3].ToString()), 4) * 100 + "%" : data.Rows[i][3];
                    data.Rows[i][7] = data.Rows[i][7] != null && data.Rows[i][7].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][7].ToString()), 4) * 100 + "%" : data.Rows[i][7];
                    data.Rows[i][8] = data.Rows[i][8] != null && data.Rows[i][7].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][8].ToString()), 2) : data.Rows[i][8];
                    data.Rows[i][9] = data.Rows[i][8] != null && data.Rows[i][9].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][9].ToString()), 2) : data.Rows[i][9];
                }
            }
            data = DataTableHelper.UpdateDataRow(data, "住院重点疾病名称", oldToNew);
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewZYZDJBQK()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "住院重点疾病情况";
            this.ReportType = Report.ReportType.Vertical;
        }

    }
}
