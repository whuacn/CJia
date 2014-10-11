using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Parking.Presenters.Navigate
{
    public class PicShowPresenter : CJia.Parking.Tools.Presenter<Models.Navigate.PicShowModel, Views.Navigate.IPicShowView>
    {
        public PicShowPresenter(Views.Navigate.IPicShowView view)
            : base(view)
        {
            
        }
    }
}
