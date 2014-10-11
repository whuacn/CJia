using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters.Web
{
    public class MyPicturePresenter:CJia.Health.Tools.PresenterPage<Models.Web.MyPictureModel,Views.Web.IMyPictureView>
    {
        public MyPicturePresenter(Views.Web.IMyPictureView view)
            : base(view)
        {
            view.OnLoadPicture += view_OnLoadPicture;
            view.OnProjectChanged += view_OnProjectChanged;
        }

        void view_OnProjectChanged(object sender, Views.Web.MyPictureArgs e)
        {
            DataTable data = Model.GetMyPictureByProID(e.HealthID, e.ProjectID);
            View.ExeBindPictureByProjectID(data);
        }

        void view_OnLoadPicture(object sender, Views.Web.MyPictureArgs e)
        {
            DataTable project = Model.GetMyPictureProject(e.HealthID);
            DataTable picture = Model.GetMyPicture(e.HealthID);
            View.ExeBindPicture(picture);
            View.ExeBindProject(project);
        }
    }
}
