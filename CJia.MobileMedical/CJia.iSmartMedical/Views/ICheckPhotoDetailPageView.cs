using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface ICheckPhotoDetailPageView : IView
    {
        event EventHandler<CheckPhotoDetailEventArgs> OnQueryCheckPhoto;

        void ExeShowCheckPhotoList(List<Data.DoctorCheckLog> PhotoList);

        event EventHandler<CheckPhotoDetailEventArgs> OnSaveCheckPhoto;

        void ExeShowCheckPhoto(Data.DoctorCheckLog CheckPhoto);

        event EventHandler<CheckPhotoDetailEventArgs> OnDeleteCheckPhoto;

        void ExeDeleteCheckPhoto(Data.DoctorCheckLog CheckPhoto);
    }

    public class CheckPhotoDetailEventArgs : EventArgs
    {
        public string InhosID;
        public Data.DoctorCheckLog CheckPhoto;
        public CheckPhotoDetailEventArgs()
        {

        }
    }
}
