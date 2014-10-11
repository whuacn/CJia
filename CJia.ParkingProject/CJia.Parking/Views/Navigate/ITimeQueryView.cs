using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views.Navigate
{
    public interface ITimeQueryView : CJia.Parking.Tools.IView
    {
        event EventHandler<TimeQueryArgs> OnTimeQury;

        void ExeShowPic(DataTable dt);
    }

    public class TimeQueryArgs : EventArgs
    {
        public List<int> floorList;

        public List<string> timeList;
    }
}
