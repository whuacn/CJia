using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CJia.iSmartMedical.Win8
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SearchResultsPage : BasePage, Views.ISearchResultsPageView
    {
        SearchPane sPanel;
        string QueryTitle = "正在查询：{0}";
        public SearchResultsPage()
        {
            this.InitializeComponent();
            sPanel = SearchPane.GetForCurrentView();
            sPanel.QuerySubmitted += sPanel_QuerySubmitted;
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SearchResultsPagePresenter(this);
        }

        void sPanel_QuerySubmitted(SearchPane sender, SearchPaneQuerySubmittedEventArgs args)
        {
            this.txtQueryText.Text = String.Format(QueryTitle, args.QueryText);
            OnSearchData(null, new Views.SearchResultsEventArgs(args.QueryText));
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Frame.Name = "SearchResultsPage.Frame";
            string QueryText = e.Parameter.ToString();
            this.txtQueryText.Text = String.Format(QueryTitle, QueryText);
            OnSearchData(null, new Views.SearchResultsEventArgs(QueryText));
            SearchPane.GetForCurrentView().ShowOnKeyboardInput = true;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            sPanel.QuerySubmitted -= sPanel_QuerySubmitted;
            SearchPane.GetForCurrentView().ShowOnKeyboardInput = false;
        }

        public event EventHandler<Views.SearchResultsEventArgs> OnSearchData;
        List<Data.SearchResults> SearchResultsList = null;
        public void ExeShowSearchResults(List<Data.SearchResults> ResultList, List<Data.SearchTypes> TypeList)
        {
            this.gridResultType.ItemsSource = TypeList;
            this.gridResultType.SelectedItem = TypeList[0];
            this.gridResult.ItemsSource = ResultList;
            SearchResultsList = ResultList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void gridResultType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (gridResultType.SelectedItem == null) return;
            Data.SearchTypes st = gridResultType.SelectedItem as Data.SearchTypes;
            List<Data.SearchResults> filterResult = SearchResultsList.FindAll(sr => sr.DataType == st.DataType || st.DataType == "All");
            this.gridResult.ItemsSource = filterResult;
        }
    }
}
