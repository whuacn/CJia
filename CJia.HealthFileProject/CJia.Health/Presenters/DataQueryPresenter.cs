using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class DataQueryPresenter : CJia.Health.Tools.Presenter<Models.DataQueryModel, Views.IDataQueryView>
    {
        public DataQueryPresenter(Views.IDataQueryView view)
            : base(view)
        {
            this.View.OnSreach += View_OnSreach;
            this.View.OnSelectPic += View_OnSelectPic;
        }

        void View_OnSelectPic(object sender, Views.DataQueryArgs e)
        {
            this.View.ExePic(this.Model.SelectPic(e.healthId));
        }

        void View_OnSreach(object sender, Views.DataQueryArgs e)
        {
            this.View.ExePatient(this.Model.Sreach(e.start, e.end, e.patientId,e.patientName,e.card,e.recordNo));
        }
    }
}
