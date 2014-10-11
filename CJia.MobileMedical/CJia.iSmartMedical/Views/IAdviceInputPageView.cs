using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Views
{
    public interface IAdviceInputPageView : IView
    {
        event EventHandler<AdviceInputEventArgs> OnQueryAdvice;
        void ExeShowAdviceList(List<Data.iAdvice> AdviceList);

        event EventHandler OnQueryUsage;
        void ExeShowUsage(List<Data.iUsage> listUsage);

        event EventHandler OnQueryFrequence;
        void ExeShowFrequence(List<Data.iFrequency> listFrequence);

        event EventHandler<AdviceInputEventArgs> OnSaveAdvice;
        void ExeEndSaveAdvice(bool Result,string SaveMsg);
    }

    public class AdviceInputEventArgs : EventArgs
    {
        public string StandingFlag;
        public string AdviceTypeID;
        public string SubTypeID;
        public string AdviceFilter;

        public ObservableCollection<Data.PadAdvice> ListNewAdvice;

        public AdviceInputEventArgs()
        {

        }
    }
}
