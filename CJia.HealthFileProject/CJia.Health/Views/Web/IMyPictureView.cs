using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IMyPictureView : CJia.Health.Tools.IPage
    {
        event EventHandler<MyPictureArgs> OnLoadPicture;
        event EventHandler<MyPictureArgs> OnProjectChanged;
        void ExeBindPicture(DataTable data, DataTable patInfo);
        void ExeBindProject(DataTable data);
        void ExeBindPictureByProjectID(DataTable data);
    }
    public class MyPictureArgs : EventArgs
    {
        /// <summary>
        /// 病人表id
        /// </summary>
        public string HealthID;
        /// <summary>
        /// 项目id
        /// </summary>
        public string ProjectID;
    }

}
