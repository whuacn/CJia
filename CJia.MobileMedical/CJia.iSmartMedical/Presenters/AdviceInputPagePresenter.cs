using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class AdviceInputPagePresenter : Presenter<Models.AdviceInputModel, Views.IAdviceInputPageView>
    {
        Models.iCodeModel CodeModel = new Models.iCodeModel();
        public AdviceInputPagePresenter(Views.IAdviceInputPageView view)
            : base(view)
        {
            View.OnQueryAdvice += View_OnQueryAdvice;
            View.OnQueryUsage += View_OnQueryUsage;
            View.OnQueryFrequence += View_OnQueryFrequence;
            View.OnSaveAdvice += View_OnSaveAdvice;
        }

        void View_OnSaveAdvice(object sender, Views.AdviceInputEventArgs e)
        {
            string exMsg = "";
            bool Result = Model.SaveAdvice(e.ListNewAdvice, ref exMsg);
            View.ExeEndSaveAdvice(Result, exMsg);
        }

        #region 频率
        void View_OnQueryFrequence(object sender, EventArgs e)
        {
            List<Data.iFrequency> listFrequence = Model.QueryLocalFrequence();
            View.ExeShowFrequence(listFrequence);
        }
        #endregion

        #region 用法
        void View_OnQueryUsage(object sender, EventArgs e)
        {
            List<Data.iUsage> listUsage = Model.QueryLocalUsage();
            View.ExeShowUsage(listUsage);
        }
        #endregion

        #region 查询医嘱
        void View_OnQueryAdvice(object sender, Views.AdviceInputEventArgs e)
        {
            List<Data.iAdvice> AdviceList = Model.QueryLocalAdvice(e.StandingFlag, e.AdviceTypeID, e.AdviceFilter);
            View.ExeShowAdviceList(AdviceList);
        }
        #endregion

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
