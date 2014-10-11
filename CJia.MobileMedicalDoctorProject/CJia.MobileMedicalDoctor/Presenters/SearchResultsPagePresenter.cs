using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class SearchResultsPagePresenter : Presenter<Models.SearchModel, Views.ISearchResultsPageView>
    {
        public SearchResultsPagePresenter(Views.ISearchResultsPageView view)
            : base(view)
        {
            View.OnSearchData += View_OnSearchData;
        }

        void View_OnSearchData(object sender, Views.SearchResultsEventArgs e)
        {
            List<Data.SearchTypes> TypeList;
            List<Data.SearchResults> ResultList = Model.QueryLocalData(e.QueryText, out TypeList);
            View.ExeShowSearchResults(ResultList, TypeList);
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}
