using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface ISelectUnit : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<SelectUnitArgs> OnQueryUnitByKew;
        event EventHandler<SelectUnitArgs> OnQueryUnitById;
        void ExeBindGrid(DataTable dt);
        void ExeGetUnitInfo(DataTable dt);
    }

    public class SelectUnitArgs : EventArgs
    {
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string KeyWord;

        /// <summary>
        /// 选择单位的ID
        /// </summary>
        public long UnitId;

        /// <summary>
        /// 组织Id
        /// </summary>
        public long Organ_id;
    }
}
