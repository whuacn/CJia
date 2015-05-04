using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface ILogoSet : CJia.Health.Tools.IView
    {
        event EventHandler<LogoSetArgs> OnSave;
        void ExeBindSuccess(bool bol);
    }
    public class LogoSetArgs : EventArgs
    {
        /// <summary>
        /// 水印内容
        /// </summary>
        public string LogoContent;
        /// <summary>
        /// 倾斜度
        /// </summary>
        public string Inclination;
    }
}
