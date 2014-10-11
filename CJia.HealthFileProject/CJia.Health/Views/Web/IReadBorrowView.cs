using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IReadBorrowView:CJia.Health.Tools.IPage
    {
        event EventHandler<ReadBorrowArgs> OnLoadBorrow;
        void ExeBindBorrow(DataTable data);
    }
    public class ReadBorrowArgs : EventArgs
    {
        public DataTable UserData;
    }
}
