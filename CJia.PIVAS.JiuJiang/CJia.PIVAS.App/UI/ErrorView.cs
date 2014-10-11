using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class ErrorView :  Tools.View, Views.IError
    {
        public ErrorView()
        {
            InitializeComponent();
            OnInitPage(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.ErrorPresenter(this);
        }
        public event EventHandler OnInitPage;
        public void ExeBindData(DataTable data)
        {
            gcAdvice.DataSource = data;
            gvAdvice.ExpandAllGroups();
        }
    }
}
