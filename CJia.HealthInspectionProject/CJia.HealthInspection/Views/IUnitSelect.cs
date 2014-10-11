using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface IUnitSelect : CJia.HealthInspection.Tools.IPage
    {
        //event EventHandler<UnitSelectEventArgs> OnGetAllUnit;

        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<Views.UnitSelectEventArgs> OnSearch;

        /// <summary>
        /// 删除单个单位事件
        /// </summary>
        event EventHandler<Views.UnitSelectEventArgs> OnDeleteUnitId;

        /// <summary>
        /// 删除所选单位组
        /// </summary>
        event EventHandler<Views.UnitSelectEventArgs> OnDeletedUnitArr;

        void ExeBindAllUnit(DataTable data);
    }
    public class UnitSelectEventArgs : EventArgs
    {
        /// <summary>
        /// 查询内容
        /// </summary>
        public string SearchKeyWords;

        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName;

        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson;

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public DataTable User;

        /// <summary>
        /// 所要删除单位ID
        /// </summary>
        public string DeletedUnitId;

        /// <summary>
        /// 删除所选单位组
        /// </summary>
        public List<object> DeletedUnitArr = new List<object>();
    }
}
