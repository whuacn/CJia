using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IUpLoadLowFile : CJia.HealthInspection.Tools.IPage
    {
        event EventHandler<UpLoadLowFileArgs> OnInit;
        event EventHandler<UpLoadLowFileArgs> OnLowTempChange;
        event EventHandler<UpLoadLowFileArgs> OnInsertLowFile;
        void ExeBindLowTemp(DataTable data);
        void ExeShowLowIsInsert(bool Isinsert);
    }

    public class UpLoadLowFileArgs : EventArgs
    {
        /// <summary>
        /// 法律名称
        /// </summary>
        public string LowName;
        /// <summary>
        /// 法律类型ID
        /// </summary>
        public long LowTypeId;
        /// <summary>
        /// 法律内容
        /// </summary>
        public string LowContent;
        /// <summary>
        /// 法律在服务器上的路径
        /// </summary>
        public string WordFilepath;
        /// <summary>
        /// word文件名称
        /// </summary>
        public string WordFileName;
        /// <summary>
        /// html文件名称
        /// </summary>
        public string HtmlFileName;
        /// <summary>
        /// html文件路径
        /// </summary>
        public string HtmlFilepath;
        
    }
}
