using CJia.HISOLAP.App.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HISOLAP.App.UI
{
    public class MyUserControl : BZUserControl
    {
        /// <summary>
        /// 不许实现的获取数据方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetData(RefreshEventArgs e)
        {
            return null;
        }

        /// <summary>
        /// 设置好标题
        /// </summary>
        public MyUserControl()
        {
            this.ZBT = "三级综合医院医疗质量评审指标";
            this.FBT = "医院运行管理情况";
            this.ReportType = Report.ReportType.Horizontal;
        }

    }
}
