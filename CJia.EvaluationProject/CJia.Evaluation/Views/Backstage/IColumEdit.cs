using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IColumEdit : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<ColumEditArgs> OnQueryColumTree;
        event EventHandler<ColumEditArgs> OnQueryColumnLevel;
        event EventHandler<ColumEditArgs> OnDeleteColumnTree;
        void ExeBindColumTree(DataTable dtColumTree);
        void ExeReturnColumnLevel(int ColumnLevel);
        void ExeReturnDeleteMsg(bool IsDelete);
    }

    public class ColumEditArgs : EventArgs
    {
        /// <summary>
        /// 树状节点的ID
        /// </summary>
        public long ColumnID;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserID;
    }
}
