using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IDataInput : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<DataInputArgs> OnInitColumnTree;
        event EventHandler<DataInputArgs> OnQueryDataByColumnId;
        event EventHandler<DataInputArgs> OnDeleteData;
        void ExeBindColumnTree(DataTable dtColumnTree);
        void ExeBindData(DataTable dtData);
        void ExeReturnDeleteMsg(bool isDeleteData);
    }
    public class DataInputArgs : EventArgs
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        public string ColumnID;

        /// <summary>
        /// 资料ID
        /// </summary>
        public string DataID;

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId;
    }
}
