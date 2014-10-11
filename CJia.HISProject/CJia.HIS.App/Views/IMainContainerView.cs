using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HIS.App.Views
{
    public interface IMainContainerView : CJia.HIS.IView
    {

        string ModuleId
        {
            get;
        }

        void IntiMenu(DataTable result);

        void IntiTool(DataTable result);

        void initDefaultPage(DataTable result);

        DevExpress.XtraEditors.XtraUserControl OpenModule(DataTable module);

        /// <summary>
        /// Ò³Ãænew Ê±Ö´ÐÐ
        /// </summary>
        event EventHandler Init;

        event EventHandler MenuClickEven;


    }
}
