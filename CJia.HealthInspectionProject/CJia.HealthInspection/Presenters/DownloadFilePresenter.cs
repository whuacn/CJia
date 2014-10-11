using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class DownloadFilePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.DownloadFileModel,Views.IDownloadFile>
    {
        public DownloadFilePresenter(Views.IDownloadFile view)
            : base(view)
        {
            view.OnQueryTaskByTaskId +=view_OnQueryTaskByTaskId;
        }

        /// <summary>
        /// 根据当前所选任务ID查询所属文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnQueryTaskByTaskId(object sender, Views.DownloadFileArgs e)
        {
            View.ExeGridFile(Model.QueryFilesByTaskId(e.TaskId));
        }
    }
}
