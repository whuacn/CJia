using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Tools.Views
{
    public interface INewEntityView : CJia.Editors.IView
    {
        string UserAccound
        {
            get;
        }

        string DataSource
        {
            get;
        }

        string NameSpaceName
        {
            get;
        }

        string ClassName
        {
            get;
            set;
        }

        string TableName
        {
            get;
            set;
        }

        string EntityExplain
        {
            get;
            set;
        }

        string SavaPath
        {
            get;
        }

        string FormWork
        {
            get;
        }

        string SelectionTableName
        {
            get;
        }

        event EventHandler Refresh;

        event EventHandler Save;

        event EventHandler Create;

        event EventHandler FillMessage;

        void ListDataSource(Dictionary<string, List<string>> dbConfig);

        void FillGcvTables(DataTable tables);

        void FillCod(string code);

        void ShowMessage(string Message);
    }
}
