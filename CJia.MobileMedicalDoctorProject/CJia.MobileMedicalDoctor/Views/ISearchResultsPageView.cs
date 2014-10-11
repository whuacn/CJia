using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface ISearchResultsPageView : IView
    {
        event EventHandler<SearchResultsEventArgs> OnSearchData;

        void ExeShowSearchResults(List<Data.SearchResults> ResultList,List<Data.SearchTypes> TypeList);
    }

    public class SearchResultsEventArgs : EventArgs
    {
        public SearchResultsEventArgs(string strQueryText)
        {
            QueryText = strQueryText;
        }
        public string QueryText;
    }
}
