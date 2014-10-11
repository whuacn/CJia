using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewSurguryComplication : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql1 = @"
                     SELECT {  
                     [Measures].[手术并发症导致的死亡率],
                     [Measures].[肺炎死亡率], 
                     [Measures].[深静脉血栓/肺血栓死亡率],
                     [Measures].[败血症死亡率], 
                     [Measures].[休克/心脏骤停死亡率], 
                     [Measures].[消化道出血/急性溃疡死亡率], 
                     [Measures].[手术后伤口裂开发生率],
                     [Measures].[手术后肺栓塞或深静脉血栓发生率], 
                     [Measures].[手术后出血或血肿发生率],
                     [Measures].[手术后髋关节骨折发生率],
                     [Measures].[手术后生理与代谢紊乱发生率],
                     [Measures].[手术后呼吸衰竭发生率], 
                     [Measures].[手术后败血症发生率], 
                     [Measures].[产伤-新生儿发生率], 
                     [Measures].[产伤-器械辅助阴道分娩发生率], 
                     [Measures].[产伤-非器械辅助阴道分娩发生率], 
                     [Measures].[因用药错误导致患者死亡例数], 
                     [Measures].[因用药错误导致患者死亡发生率%],
                     [Measures].[输血反应发生例数], 
                     [Measures].[输血反应发生率%],
                     [Measures].[输液反应发生例数],
                     [Measures].[输液反应发生率%], 
                     [Measures].[手术过程中异物遗留发生例数], 
                     [Measures].[手术过程中异物遗留发生率%], 
                     [Measures].[医源性气胸发生例数], 
                     [Measures].[医源性气胸发生率%], 
                     [Measures].[医源性意外穿刺伤或撕裂伤发生例数],
                     [Measures].[医源性意外穿刺伤或撕裂伤发生率%]
	                     } ON ROWS,
	                        {[DATE DIM].[DATE TIME].[ALL] } on columns
	                     FROM [JJFB] ";
            sql1 += e.filterDataDeptStr;
            DataTable data1 = CJia.DefaultOleDb.Query(sql1);

            //data1 = DataTableHelper.GetRealColName(data1);

            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            oldToNew.Add("手术并发症导致的死亡率", "（一）择期手术后并发症情况_          1、手术并发症导致的死亡率");
            oldToNew.Add("肺炎死亡率", "（一）择期手术后并发症情况_                其中：肺炎死亡率");
            oldToNew.Add("深静脉血栓/肺血栓死亡率", "（一）择期手术后并发症情况_                          深静脉血栓/肺血栓死亡率");
            oldToNew.Add("败血症死亡率", "（一）择期手术后并发症情况_                          败血症死亡率");
            oldToNew.Add("休克/心脏骤停死亡率", "（一）择期手术后并发症情况_                          休克/心脏骤停死亡率");
            oldToNew.Add("消化道出血/急性溃疡死亡率", "（一）择期手术后并发症情况_                          消化道出血/急性溃疡死亡率");
            oldToNew.Add("手术后伤口裂开发生率", "（一）择期手术后并发症情况_          2、手术后伤口裂开发生率");
            oldToNew.Add("手术后肺栓塞或深静脉血栓发生率", "（一）择期手术后并发症情况_          3、手术后肺栓塞或深静脉血栓发生率");
            oldToNew.Add("手术后出血或血肿发生率", "（一）择期手术后并发症情况_          4、手术后出血或血肿发生率");
            oldToNew.Add("手术后髋关节骨折发生率", "（一）择期手术后并发症情况_          5、手术后髋关节骨折发生率");
            oldToNew.Add("手术后生理与代谢紊乱发生率", "（一）择期手术后并发症情况_          6、手术后生理与代谢紊乱发生率");
            oldToNew.Add("手术后呼吸衰竭发生率", "（一）择期手术后并发症情况_          7、手术后呼吸衰竭发生率");
            oldToNew.Add("手术后败血症发生率", "（一）择期手术后并发症情况_          8、手术后败血症发生率");
            oldToNew.Add("产伤-新生儿发生率", "（二）产伤发生情况_          1、产伤-新生儿发生率");
            oldToNew.Add("产伤-器械辅助阴道分娩发生率", "（二）产伤发生情况_          2、产伤-器械辅助阴道分娩发生率");
            oldToNew.Add("产伤-非器械辅助阴道分娩发生率", "（二）产伤发生情况_          3、产伤-非器械辅助阴道分娩发生率");
            oldToNew.Add("因用药错误导致患者死亡例数", "（三）因用药错误导致患者死亡发生情况_          1、因用药错误导致患者死亡例数");
            oldToNew.Add("因用药错误导致患者死亡发生率%", "（三）因用药错误导致患者死亡发生情况_          2、因用药错误导致患者死亡发生率%");
            oldToNew.Add("输血反应发生例数", "（四）输血/输液反应发生情况_          1、输血反应发生例数");
            oldToNew.Add("输血反应发生率%", "（四）输血/输液反应发生情况_          2、输血反应发生率%");
            oldToNew.Add("输液反应发生例数", "（四）输血/输液反应发生情况_          3、输液反应发生例数");
            oldToNew.Add("输液反应发生率%", "（四）输血/输液反应发生情况_          4、输液反应发生率%");
            oldToNew.Add("手术过程中异物遗留发生例数", "（五）手术过程中异物遗留发生情况_          1、手术过程中异物遗留发生例数");
            oldToNew.Add("手术过程中异物遗留发生率%", "（五）手术过程中异物遗留发生情况_          2、手术过程中异物遗留发生率%");
            oldToNew.Add("医源性气胸发生例数", "（六）医源性气胸发生率_          1、医源性气胸发生例数");
            oldToNew.Add("医源性气胸发生率%", "（六）医源性气胸发生率_          2、医源性气胸发生率%");
            oldToNew.Add("医源性意外穿刺伤或撕裂伤发生例数", "（七）医源性意外穿刺伤或撕裂伤发生情况_          1、医源性意外穿刺伤或撕裂伤发生例数");
            oldToNew.Add("医源性意外穿刺伤或撕裂伤发生率%", "（七）医源性意外穿刺伤或撕裂伤发生情况_          2、医源性意外穿刺伤或撕裂伤发生率%");

            data1 = DataTableHelper.UpdateDataRow(data1, data1.Columns[0].ColumnName, oldToNew);
            for(int i = 0; i < data1.Rows.Count; i++)
            {
                if(data1.Rows[i][1].ToString() == "0")
                {
                    data1.Rows[i][1] = "";
                }
                if(i != 16 && i != 18 && i != 20 && i != 22 && i != 24 && i != 26)
                {
                    data1.Rows[i][1] = data1.Rows[i][1] != null && data1.Rows[i][1].ToString() != "" ? Math.Round(double.Parse(data1.Rows[i][1].ToString()), 4) * 100 + "%" : data1.Rows[i][1];
                }

            }
            data1.Columns[0].ColumnName = "项目类型";
            data1.Columns[1].ColumnName = "本期数量";

            return data1;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewSurguryComplication()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "手术并发症情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}
