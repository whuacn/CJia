using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Tools.Views
{
    public interface ISystemConfigView : CJia.Editors.IView
    {
        string ModelSql
        {
            get;
        }

        string SystemNO
        {
            get;
        }

        string DBName
        {
            get;
        }

        void InitDBConfig(Dictionary<string, List<string>> dbConfig);

        event EventHandler CreateSystemTable;

        void InitSchedule(int max);

        void NextSchedule();
    }
}
