using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class NewYCQK1 : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            //data = CJia.HISOLAP.App.Tools.Help.DeptData;
            string sql = @"SELECT { 
		                         [Measures].[（一）住院患者入院前压疮情况（%）_    1、患者入院前已有压疮发生率], 
		                         [Measures].[（一）住院患者入院前压疮情况（%）_    2、患者入院前已有一级压疮发生率], 
		                         [Measures].[（一）住院患者入院前压疮情况（%）_    3、患者入院前已有二级压疮发生率],
		                         [Measures].[（一）住院患者入院前压疮情况（%）_    4、患者入院前已有三级压疮发生率], 
		                         [Measures].[（一）住院患者入院前压疮情况（%）_    5、患者入院前已有四级压疮发生率],
		                         [Measures].[（二）住院患者压疮来源情况（%）_    1、自家庭入住时有压疮的患者发生率],
		                         [Measures].[（二）住院患者压疮来源情况（%）_    2、自养老院入住时有压疮的患者发生率], 
		                         [Measures].[（二）住院患者压疮来源情况（%）_    3、自其他医院转入时有压疮患者发生率], 
		                         [Measures].[（二）住院患者压疮来源情况（%）_    4、自其他来源入住时有压疮患者发生率], 
		                         [Measures].[（三）住院患者住院期间压疮情况（%）_    1、住院期间发生压疮发生率], 
		                         [Measures].[（三）住院患者住院期间压疮情况（%）_    2、住院期间发生一级压疮发生率], 
		                         [Measures].[（三）住院患者住院期间压疮情况（%）_    3、住院期间发生二级压疮发生率], 
		                         [Measures].[（三）住院患者住院期间压疮情况（%）_    4、住院期间发生三级压疮发生率], 
		                         [Measures].[（三）住院患者住院期间压疮情况（%）_    5、住院期间发生四级压疮发生率],
		                         [Measures].[（四）住院患者压疮部位情况（%）_    0、住院期间压疮发生率],
		                         [Measures].[（四）住院患者压疮部位情况（%）_    1、住院患者骶骨推尾处压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    2、住院患者坐骨处压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    3、住院患者股骨粗隆处压疮发生率],  
		                         [Measures].[（四）住院患者压疮部位情况（%）_    4、住院患者根骨处压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    5、住院患者足踝处压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    6、住院患者肩胛骨处压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    7、住院患者枕骨处压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    8、住院患者其他部位压疮发生率], 
		                         [Measures].[（四）住院患者压疮部位情况（%）_    9、住院患者多处压疮发生率]
		                         } ON rows,
	                        { [GFXBRQK DIM].[GFXBRQK ID].[All],[GFXBRQK DIM].[GFXBRQK ID].[GFXBRQK ID].&[1000000002] }  ON COLUMNS
	                       FROM [JJFB]";
            sql += CJia.HISOLAP.App.Tools.Help.FilterDataDept(e);
            DataTable data = CJia.DefaultOleDb.Query(sql);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 0, "项目名称" }, { 1, "本期数量（住院患者）" }, { 2, "本期数量（高风险患者）" } }, new Dictionary<int, string>() { { 0, "40%" }, { 1, "30%" }, { 2, "30%" } });
            if(data != null && data.Rows.Count > 0)
            {
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    for(int j = 1; j < data.Columns.Count; j++)
                    {
                        if(data.Rows[i][j] != DBNull.Value)
                        {
                            data.Rows[i][j] = Math.Round(Convert.ToDouble(data.Rows[i][j]), 4) * 100 + "%";
                        }
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public NewYCQK1()
        {
            //Data = CJia.HISOLAP.App.Tools.Help.DeptData;
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "住院压疮情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}
