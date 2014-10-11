using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views.Navigate
{
    public interface IFastQueryView : CJia.Parking.Tools.IView
    {
        event EventHandler<FastQueryArgs> OnFastQuery;

        void ExeShowPic(DataTable dt); 
    }

    public class FastQueryArgs : EventArgs
    {
        public string Fast1;

        public string Fast2;

        public string Fast3;

        public string Fast4;

        public string Fast5;
    }
}
