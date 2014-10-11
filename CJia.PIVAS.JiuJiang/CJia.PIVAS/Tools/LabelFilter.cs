using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Tools
{
    public static class LabelFilter
    {

        public static bool IsInit = false;

        public static List<object> ArrangeIds = null;

        public static DateTime SelectDate;

        /// <summary>
        /// 药品类型多选框
        /// </summary>
        public static DevExpress.XtraEditors.CheckedListBoxControl PharmType = null;

        /// <summary>
        /// 瓶贴批次多选框
        /// </summary>
        public static DevExpress.XtraEditors.CheckedListBoxControl LabelBacth = null;

        /// <summary>
        /// 病房床位
        /// </summary>
        public static DevExpress.XtraEditors.CheckedListBoxControl IllfileBens = null;
        
        /// <summary>
        /// 使用的排序方式
        /// </summary>
        public static DevExpress.XtraEditors.ListBoxControl UseOrderBy = null;

        /// <summary>
        /// 未使用的瓶贴方式
        /// </summary>
        public static DevExpress.XtraEditors.ListBoxControl NoUseOrderBy = null;

    }
}
