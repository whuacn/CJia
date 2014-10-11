using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CJia.HISOLAP.App.Tools;

namespace CJia.HISOLAP.App.UI
{
    class NewSSBFZQK : BZUserControl
    {

        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @"SELECT  
                             { 
		                        [Measures].[手术患者并发症发生例数],
		                        [Measures].[手术患者手术后肺塞栓发生例数], 
		                        [Measures].[手术患者手术后深静脉血栓发生例数],
		                        [Measures].[手术后败血症例数],
		                        [Measures].[手术后出血或血肿例数], 
		                        [Measures].[手术后伤口裂开例数], 
		                        [Measures].[手术患者手术后猝死例数],
		                        [Measures].[手术并发症导致的死亡例数], 
		                        [Measures].[手术后呼吸衰竭例数], 
		                        [Measures].[手术后生理与代谢紊乱例数], 
		                        [Measures].[手术患者麻醉并发症发生例数], 
		                        [Measures].[SURGERY COMPLICATION FACT 计数] } ON rows,
		                        {[DATE DIM].[DATE TIME].[ALL]} ON COLUMNS  
		                        FROM [JJFB]";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data.Columns.Add("fsl");
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" }, { 1, "本期数量" }, { 2, "发生率" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            oldToNew.Add("手术患者并发症发生例数", "手术并发症类指标(Operation Complication Indicators)_      1、手术患者并发症发生情况");
            oldToNew.Add("手术患者手术后肺塞栓发生例数", "手术并发症类指标(Operation Complication Indicators)_      2、手术患者手术后肺栓塞发生情况");
            oldToNew.Add("手术患者手术后深静脉血栓发生例数", "手术并发症类指标(Operation Complication Indicators)_      3、手术患者手术后深静脉血栓发生情况");
            oldToNew.Add("手术后败血症例数", "手术并发症类指标(Operation Complication Indicators)_      4、手术患者手术后败血症发生情况");
            oldToNew.Add("手术后出血或血肿例数", "手术并发症类指标(Operation Complication Indicators)_      5、手术患者手术后出血或血肿发生情况");
            oldToNew.Add("手术后伤口裂开例数", "手术并发症类指标(Operation Complication Indicators)_      6、手术患者手术伤口裂开发生情况");
            oldToNew.Add("手术患者手术后猝死例数", "手术并发症类指标(Operation Complication Indicators)_      7、手术患者手术后猝死发生情况");
            oldToNew.Add("手术并发症导致的死亡例数", "手术并发症类指标(Operation Complication Indicators)_      8、手术死亡患者手术并发症发生情况");
            oldToNew.Add("手术后呼吸衰竭例数", "手术并发症类指标(Operation Complication Indicators)_      9、手术患者手术后呼吸衰竭发生情况");
            oldToNew.Add("手术后生理与代谢紊乱例数", "手术并发症类指标(Operation Complication Indicators)_      10、手术患者手术后生理/代谢紊乱发生情况");
            oldToNew.Add("手术患者麻醉并发症发生例数", "手术并发症类指标(Operation Complication Indicators)_      11、手术患者麻醉并发症发生情况");
            if (data != null && data.Rows.Count > 0)
            {
                data.Rows[7][2] = Convert.ToDouble(data.Rows[7][1]) / Convert.ToDouble(data.Rows[0][1]);
                for (int i = 0; i < data.Rows.Count-1; i++)
                {
                    data.Rows[i][2] = data.Rows[i][1] != null && data.Rows[i][1].ToString() != "" ? Math.Round(double.Parse(data.Rows[i][1].ToString()) / double.Parse(data.Rows[11][1].ToString()), 4) * 100 + "%" : "0";
                    //data.Rows[i][2] = Convert.ToDouble(data.Rows[i][1]) / Convert.ToDouble(data.Rows[11][1]);
                }
            }
            data = DataTableHelper.UpdateDataRow(data, "项目名称", oldToNew);
            data.Rows.RemoveAt(11);
            return data;
        }

        public NewSSBFZQK()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "手术并发症情况";
            this.ReportType = Report.ReportType.Horizontal;
        }
    }
}
