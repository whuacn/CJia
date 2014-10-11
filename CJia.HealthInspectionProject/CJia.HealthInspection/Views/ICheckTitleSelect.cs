using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface ICheckTitleSelect:Tools.IPage
    {
        event EventHandler OnInitTree;
        event EventHandler<CheckTitleSelectArgs> OnTreeClick;
        event EventHandler<CheckTitleSelectArgs> OnDelete;
        void ExeBindTree(DataTable data);
        void ExeBindCheckTitle(DataTable data);
        void ExeIsDelete(bool bol);
    }
    public class CheckTitleSelectArgs : EventArgs
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public string TemplateID;
        /// <summary>
        /// 检查题目id
        /// </summary>
        public string CheckTitleID;

        /// <summary>
        /// 所属组织
        /// </summary>
        public string OrganId;
    }
}
