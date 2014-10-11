using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IAddData : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<AddDataArgs> OnInitDataType;
        event EventHandler<AddDataArgs> OnAddData;
        void ExeBindDataType(DataTable dtDataType);
        void ExeReturnMsg(bool bl);
    }
    public class AddDataArgs : EventArgs
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        public string ColumnTreeId;

        /// <summary>
        /// 资料标题
        /// </summary>
        public string DataTitle;

        /// <summary>
        /// 资料类别
        /// </summary>
        public string DataType;
        
        /// <summary>
        /// 资料内容
        /// </summary>
        public string DataContent;

        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserID;
    }
}
