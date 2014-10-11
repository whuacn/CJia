using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Tools.Views
{
    public interface ICreateMvpView : CJia.Editors.IView
    {

        string UIName
        {
            get;
        }

        string ProjectPath
        {
            get;
        }

        string ProjectName
        {
            get;
        }

        string UIFormWork
        {
            get;
        }

        string ViewsFormWork
        {
            get;
        }

        string PresentersFormWork
        {
            get;
        }

        string ModelsFormWork
        {
            get;
        }

        event EventHandler Create;

        void ShowMessage(string mess);

        bool ShowAwrn(string mess);
    }
}
