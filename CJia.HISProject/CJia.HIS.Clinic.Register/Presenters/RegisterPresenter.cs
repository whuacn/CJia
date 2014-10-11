using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.Clinic.Register.Presenters
{
    public class RegisterPresenter : CJia.HIS.Presenter<Models.RegisterModel,Views.IRegisterView>
    {

        public RegisterPresenter(Views.IRegisterView view)
            : base(view)
        {
            this.View.GetTxtCardTypeEvent += View_GetTxtCardTypeEvent;
        }

        void View_GetTxtCardTypeEvent(object CardTypeFilter)
        {
            DataTable result = Model.GetCartType(CardTypeFilter.ToString());

        }


        protected override void OnInitView()
        {
 	         base.OnInitView();
        }

    }
}