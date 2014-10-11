using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface ICompetence : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<CompetenceArgs> OnInitColumn;
        event EventHandler<CompetenceArgs> OninitMenu;
        event EventHandler<CompetenceArgs> OnDepeteInsertCompetence;
        void ExeBindColumn(DataTable dtColumn, DataTable dtFun);
        void ExeBindMenu(DataTable dtMenu, DataTable dtFun);
        void ExeReturnInsertMsg(bool isInsert);
    }

    public class CompetenceArgs : EventArgs
    {
        /// <summary>
        /// 权限用户ID
        /// </summary>
        public string UserID;

        /// <summary>
        /// 参数列表（添加权限）
        /// </summary>
        public List<object[]> obListInsert;

        /// <summary>
        /// 参数列表（删除权限）
        /// </summary>
        public List<object[]> obListDelete;
    }
}
