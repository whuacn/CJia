using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Views
{
    public interface IMainPageView : IView
    {

        event EventHandler OnLoadData;

        //void ExeShowSyncProgress(int now, int max, string Hint);

        //void ExeLoadDataComplet();

        void ExeShowPatientCount(List<int> CountData);

        event EventHandler OnQueryTileData;
    }
}
