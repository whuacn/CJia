using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class CheckPhotoDetailPagePresenter : Presenter<Models.DoctorCheckModel, Views.ICheckPhotoDetailPageView>
    {
        public CheckPhotoDetailPagePresenter(Views.ICheckPhotoDetailPageView view)
            : base(view)
        {
            View.OnQueryCheckPhoto += View_OnQueryCheckPhoto;
            View.OnSaveCheckPhoto += View_OnSaveCheckPhoto;
            View.OnDeleteCheckPhoto += View_OnDeleteCheckPhoto;
        }

        void View_OnDeleteCheckPhoto(object sender, Views.CheckPhotoDetailEventArgs e)
        {
            Model.DeleteCheckLog(e.CheckPhoto);
            View.ExeDeleteCheckPhoto(e.CheckPhoto);
        }

        void View_OnSaveCheckPhoto(object sender, Views.CheckPhotoDetailEventArgs e)
        {
            Model.SaveCheckLogToLocal(e.CheckPhoto);
            View.ExeShowCheckPhoto(e.CheckPhoto);
        }

        void View_OnQueryCheckPhoto(object sender, Views.CheckPhotoDetailEventArgs e)
        {
            QueryCheckPhoto(e.InhosID);
        }

        void QueryCheckPhoto(string InhosID)
        {
            List<Data.DoctorCheckLog> PhotoList = Model.QueryLocalPatientCheckPhoto(InhosID);

            View.ExeShowCheckPhotoList(PhotoList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
