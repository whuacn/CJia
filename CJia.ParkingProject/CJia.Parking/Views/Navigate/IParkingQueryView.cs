using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views.Navigate
{
    public interface IParkingQueryView : CJia.Parking.Tools.IView
    {
        event EventHandler<ParkingQueryArgs> OnParkQuery;

        void ExeShowPic(DataTable dt); 
    }

    public class ParkingQueryArgs : EventArgs
    {
        public string park1;

        public string park2;

        public string park3;

        public string park4;

    }
}
