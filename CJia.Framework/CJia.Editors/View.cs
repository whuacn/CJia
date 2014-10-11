using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace CJia.Editors
{
    public class View : DevExpress.XtraEditors.XtraUserControl
    {
        private object _presenter;
        public View()
        {
            _presenter = this.CreatePresenter();
        }

        protected virtual object CreatePresenter()
        {
            if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime)
            {
                return null;
            }
            else
            {
                throw new NotImplementedException(string.Format("{0} 必须重载 CreatePresenter 方法.", this.GetType().FullName));
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
