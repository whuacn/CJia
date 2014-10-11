using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IDownloadFile : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 根据任务ID查询所属文件
        /// </summary>
        event EventHandler<Views.DownloadFileArgs> OnQueryTaskByTaskId;

        /// <summary>
        /// 绑定Grid文件
        /// </summary>
        /// <param name="dtFiles"></param>
        void ExeGridFile(DataTable dtFiles);
    }

    public class DownloadFileArgs : EventArgs
    {
        /// <summary>
        /// 当前所选任务ID
        /// </summary>
        public string TaskId;
    }
}
