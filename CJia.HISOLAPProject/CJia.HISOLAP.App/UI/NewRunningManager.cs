using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewRunningManager : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            string sql = @" SELECT { 
 [Measures].[实际开放床位], 
 [Measures].[重症医学实际开放床位], 
 [Measures].[急诊留观实际开放床位], 
 [Measures].[全院员工总数], 
 [Measures].[卫生技术人数], 
 [Measures].[医师人数], 
 [Measures].[护理人数], 
 [Measures].[医技人数], 
 [Measures].[助产人数],
 [Measures].[医院医用建筑面结], 
 [Measures].[门诊人次], 
 [Measures].[健康体检人次], 
 [Measures].[急诊人次], 
 [Measures].[留观人次], 
 [Measures].[住院患者入院例数], 
 [Measures].[住院患者出院例数], 
 [Measures].[出院占用总床日数], 
 [Measures].[住院手术例数], 
 [Measures].[门诊手术例数], 
 [Measures].[分娩例数], 
 [Measures].[新生儿数], 
 [Measures].[手术冰冻与石蜡诊断符合例数], 
 [Measures].[恶性肿瘤手术前诊断与术后病理诊断符合例数], 
 [Measures].[住院患者死亡例数], 
 [Measures].[患者自动出院例数], 
 [Measures].[住院患者手术例数], 
 [Measures].[患者手术死亡例数], 
 [Measures].[住院危重抢救例数], 
 [Measures].[住院危重死亡例数], 
 [Measures].[急诊科危重抢救例数], 
 [Measures].[急诊科危重死亡例数], 
 [Measures].[新生儿患者死亡例数]
 } ON ROWS, 
 { ([DATE DIM].[DATE TIME].[ALL]) } on COLUMNS 
 FROM [JJFB]
";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" }, { 1, "本期数量" } }, new Dictionary<int, string>() { { 0, "70%" }, { 1, "30%" } });
            Dictionary<string, string> oldToNew = new Dictionary<string, string>();
            //（一）资源配置
            oldToNew.Add("实际开放床位", "（一）资源配置_      1、实际开放床位");
            oldToNew.Add("重症医学实际开放床位", "（一）资源配置_      2、重症医学实际开放床位");
            oldToNew.Add("急诊留观实际开放床位", "（一）资源配置_      3、急诊留观实际开放床位");
            oldToNew.Add("全院员工总数", "（一）资源配置_      4、全院员工总数");
            oldToNew.Add("卫生技术人数", "（一）资源配置_      5、卫生技术人数");
            oldToNew.Add("医师人数", "（一）资源配置_       （1）医师人数");
            oldToNew.Add("护理人数", "（一）资源配置_       （2）护理人数");
            oldToNew.Add("医技人数", "（一）资源配置_       （3）医技人数");
            oldToNew.Add("助产人数", "（一）资源配置_       （4）助产人数");
            oldToNew.Add("医院医用建筑面结", "（一）资源配置_      6、医院医用建筑面结");
            //（二）工作负荷
            oldToNew.Add("门诊人次", "（二）工作负荷_      1、门诊人次");
            oldToNew.Add("健康体检人次", "（二）工作负荷_      2、健康体检人次");
            oldToNew.Add("急诊人次", "（二）工作负荷_      3、急诊人次");
            oldToNew.Add("留观人次", "（二）工作负荷_      4、留观人次");
            oldToNew.Add("住院患者入院例数", "（二）工作负荷_      5、住院患者入院例数");
            oldToNew.Add("住院患者出院例数", "（二）工作负荷_      6、住院患者出院例数");
            oldToNew.Add("出院占用总床日数", "（二）工作负荷_      7、出院占用总床日数");
            oldToNew.Add("住院手术例数", "（二）工作负荷_      8、住院手术例数");
            oldToNew.Add("门诊手术例数", "（二）工作负荷_      9、门诊手术例数");
            oldToNew.Add("分娩例数", "（二）工作负荷_      10、分娩例数");
            oldToNew.Add("新生儿数", "（二）工作负荷_      11、新生儿数");
            //（三）治疗质量
            oldToNew.Add("手术冰冻与石蜡诊断符合例数", "（三）治疗质量_      1、手术冰冻与石蜡诊断符合例数");
            oldToNew.Add("恶性肿瘤手术前诊断与术后病理诊断符合例数", "（三）治疗质量_      2、恶性肿瘤手术前诊断与术后病理诊断符合例数");
            oldToNew.Add("住院患者死亡例数", "（三）治疗质量_      3、住院患者死亡例数");
            oldToNew.Add("患者自动出院例数", "（三）治疗质量_      4、患者自动出院例数");
            oldToNew.Add("住院患者手术例数", "（三）治疗质量_      5、住院患者手术例数");
            oldToNew.Add("患者手术死亡例数", "（三）治疗质量_      6、患者手术死亡例数");
            oldToNew.Add("住院危重抢救例数", "（三）治疗质量_      7、住院危重抢救例数");
            oldToNew.Add("住院危重死亡例数", "（三）治疗质量_      8、住院危重死亡例数");
            oldToNew.Add("急诊科危重抢救例数", "（三）治疗质量_      9、急诊科危重抢救例数");
            oldToNew.Add("急诊科危重死亡例数", "（三）治疗质量_      10、急诊科危重死亡例数");
            oldToNew.Add("新生儿患者死亡例数", "（三）治疗质量_      11、新生儿患者死亡例数");

            data = DataTableHelper.UpdateDataRow(data, "项目名称$70%", oldToNew);
            //if (data != null && data.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in data.Rows)
            //    {
            //        if (dr[1].ToString().Length > 0)
            //        {
            //            dr[0] = dr[1];
            //        }
            //        dr[6] = Math.Round(double.Parse(dr[6].ToString()), 4)*100;
            //        dr[3] = Math.Round(double.Parse(dr[3].ToString()), 4) * 100;
            //        dr[4] = Math.Round(double.Parse(dr[4].ToString()), 2);
            //        dr[5] = Math.Round(double.Parse(dr[5].ToString()), 2);
            //    }
            //}
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewRunningManager()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "医院运行管理情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}

