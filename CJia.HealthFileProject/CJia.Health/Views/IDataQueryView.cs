using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IDataQueryView : CJia.Health.Tools.IView
    {
        event EventHandler<DataQueryArgs> OnSreach;

        event EventHandler<DataQueryArgs> OnSelectPic;


        void ExePic(DataTable result);

        void ExePatient(DataTable result);
       
    }
    public class DataQueryArgs : EventArgs
    {
        public DateTime start;

        public DateTime end;

        public string patientId;

        public string patientName;

        public string card;

        public string recordNo;

        public string healthId;

    }
}
