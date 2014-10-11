using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class SearchResults : DataObject
    {
        public SearchResults()
        {
            this.InitFields("DataType", "Title", "DataText1", "DataText2", "DataText3", "DataCode1", "DataCode2", "DataCode3");
        }

        [PrimaryKey]
        public string DataType { get { return Get(); } set { Set(value); } }
        public string Title { get { return Get(); } set { Set(value); } }
        public string DataText1 { get { return Get(); } set { Set(value); } }
        public string DataText2 { get { return Get(); } set { Set(value); } }
        public string DataText3 { get { return Get(); } set { Set(value); } }
        public string DataCode1 { get { return Get(); } set { Set(value); } }
        public string DataCode2 { get { return Get(); } set { Set(value); } }
        public string DataCode3 { get { return Get(); } set { Set(value); } }
    }
}
