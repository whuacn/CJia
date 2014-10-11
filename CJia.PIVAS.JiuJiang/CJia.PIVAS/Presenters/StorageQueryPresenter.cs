using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Presenters
{
    public class StorageQueryPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.StotageQueryModel, CJia.PIVAS.Views.IStorageQueryView>
    {
        public StorageQueryPresenter(Views.IStorageQueryView view)
            : base(view)
        {
            this.View.OnStorageQuery += View_OnStorageQuery;
        }

        void View_OnStorageQuery(object sender, Views.StorageQueryArgs e)
        {
            DataTable dt = this.Model.QueryStorage(e.DrugName,e.DrugSpec, e.DrugNo, e.DrugFirm,e.FilterZero);
            View.ExeDataBind(dt);
        }
    }
}
