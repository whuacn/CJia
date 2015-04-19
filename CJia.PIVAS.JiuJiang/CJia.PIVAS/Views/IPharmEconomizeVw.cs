using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Views
{
    public interface IPharmEconomizeVw : CJia.PIVAS.Tools.IView
    {
        DateTime BeginDate { get; }
        DateTime EndDate { get; }
        /// <summary>
        /// 过滤条件科室数据
        /// </summary>
        DataTable DtDept { set; }
        DataTable DtPharm { set; }
        DataTable DtWaitingImport { set; }
        DataTable DtImportRecord { set; }
        DataTable FilterPharm { get; }
        string FilterDept { get; }
    }
}
