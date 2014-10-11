using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI.Antibacterials
{
    public class KJYWSYJE : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.PIVAS);
            string sql = @"SELECT T.*,rownum rn
                                        FROM (SELECT DD.DRUG_NAME,
                                                   DD.TOXI_PROPERTY,
                                                   DD.DRUG_FORM,
                                                   DD.DRUG_SPEC,
                                                   SUM(IBD.Costs) AMOUNT
                                              FROM INP_BILL_DETAIL IBD, DRUG_DICT DD
                                             WHERE IBD.ITEM_CODE = DD.DRUG_CODE
                                                  AND IBD.BILLING_DATE_TIME BETWEEN  ? AND ?";
            if (!e.IsSelectAllDept)
            {
                sql += " and ibd.ordered_by in (" + CJia.HISOLAP.App.Tools.Help.GetDeptString(e.SelectDepts) + ")";
            }
            sql += @" GROUP BY DD.DRUG_NAME, DD.TOXI_PROPERTY, DD.DRUG_FORM, DD.DRUG_SPEC ORDER BY AMOUNT DESC) T
                            where rownum<21";
            object[] ob = new object[] { e.SelectStartDateTime, e.SelectEndDateTime };
            DataTable data = CJia.DefaultOleDb.Query(sql, ob);
            CJia.HISOLAP.App.Tools.DBHelper.DBSwitchover(DBType.BI);
            data = DataTableHelper.GetRealColName(data);
            data = DataTableHelper.UpdateColName(data, new Dictionary<int, string>() { { 1, "药品名称" }, { 2, "    药品类型    " }, { 3, "    药品剂型    " }, { 4, "  药品规格  " }, { 5, "   金额     " }, { 6, "   序号  " } });
            return data;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public KJYWSYJE()
        {
            this.ZBT = "抗菌药物药品使用统计报表";
            this.IsDeptName = true;
            this.FBT = "抗菌药物使用金额（前20位）";
            this.ReportType = Report.ReportType.Horizontal;
        }
    }
}
