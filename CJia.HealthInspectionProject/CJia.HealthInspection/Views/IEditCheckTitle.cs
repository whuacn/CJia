using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditCheckTitle : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<EditCheckTitleArgs> OnInit;
        event EventHandler<EditCheckTitleArgs> OnBigChanged;
        event EventHandler<EditCheckTitleArgs> OnMidChanged;
        event EventHandler<EditCheckTitleArgs> OnGetTitleBySmallType;
        void ExeBindBigTempType(DataTable dtBigTemp);
        void ExeBindMidTempType(DataTable dtMidTemp);
        void ExeBindSmallTemptype(DataTable dtSmallTemp);
        void ExeBindTitle(DataTable dtTitle);
    }

    public class EditCheckTitleArgs : EventArgs
    {
        /// <summary>
        /// 大分类ID
        /// </summary>
        public string BigTempID;

        /// <summary>
        /// 中分类ID
        /// </summary>
        public string MidTempID;

        /// <summary>
        /// 小分类ID
        /// </summary>
        public string SmallTempID;

        /// <summary>
        /// 当前登录人得组织机构
        /// </summary>
        public long organ;
    }
}
