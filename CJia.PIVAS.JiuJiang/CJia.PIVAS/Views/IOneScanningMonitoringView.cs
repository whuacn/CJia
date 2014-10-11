using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views
{
    /// <summary>
    /// 发药统计View层
    /// </summary>
    public interface IOneScanningMonitoringView : Tools.IView
    {
        /// <summary>
        /// 登录
        /// </summary>
        event EventHandler<OneScanningMonitoringEventArgs> OnOutLogin;

        /// <summary>
        /// 扫描
        /// </summary>
        event EventHandler<OneScanningMonitoringEventArgs> OnScanning;

        /// <summary>
        /// 初始化用户登录信息
        /// </summary>
        event EventHandler<OneScanningMonitoringEventArgs> OnInit;

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="lightMes">灯信息</param>
        /// <param name="mes">信息</param>
        void ExeResurtMes(bool lightMes, string mes);


        void ExeInit(DataTable userData);
    }
    /// <summary>
    /// 发药统计参数类
    /// </summary>
    public class OneScanningMonitoringEventArgs : EventArgs
    {
        public string userId;

        public string no;

        public string labelBarId;
    }
}
