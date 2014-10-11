using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views.Navigate
{
    public interface ILicenceQueryView : CJia.Parking.Tools.IView
    {
        event EventHandler<LicenceQueryArgs> OnLicenceQuery;

        void ExeShowPic(DataTable dt); 
    }

    public class LicenceQueryArgs : EventArgs
    {
        public string Lice1;

        public string Lice2;

        public string Lice3;

        public string Lice4;

        public string Lice5;
    }
}
