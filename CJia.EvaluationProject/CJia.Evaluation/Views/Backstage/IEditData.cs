using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IEditData : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<EditArgs> OnInitDataType;
        event EventHandler<EditArgs> OnQueryDataById;
        event EventHandler<EditArgs> OnUpdateData;
        void ExeBindDataType(DataTable dtDataType);
        void ExeBindData(DataTable dtData);
        void ExeReturnMsg(bool bl);
    }

    public class EditArgs : EventArgs
    {
        /// <summary>
        /// 资料ID
        /// </summary>
        public string DataID;

        /// <summary>
        /// 资料ID
        /// </summary>
        public string DataTitle;

        /// <summary>
        /// 资料内容
        /// </summary>
        public string DataContent;

        /// <summary>
        /// 资料类别
        /// </summary>
        public string DataType;

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId;
    }
}
