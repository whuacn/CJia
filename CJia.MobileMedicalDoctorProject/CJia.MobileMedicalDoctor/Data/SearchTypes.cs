using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class SearchTypes : DataObject
    {
        public SearchTypes()
        {
            this.InitFields("DataType", "Title", "ResultsCount");
        }
        public SearchTypes(string dataType, string title, int dataCount)
        {
            this.InitFields("DataType", "Title", "ResultsCount");
            this.DataType = dataType;
            this.Title = title;
            this.ResultsCount = dataCount;
        }
        [PrimaryKey]
        public string DataType { get { return Get(); } set { Set(value); } }
        public string Title { get { return Get(); } set { Set(value); } }
        public string Count { get { return "（ " + ResultsCount + " ）"; } }
        public int ResultsCount { get { return GetInt(); } set { Set(value); } }
    }
}
