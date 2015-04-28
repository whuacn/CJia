using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJia.Health.App
{
	public class NlogMonitor
	{
        //public static NLog.Logger LogMonitor = NLog.LogManager.GetLogger("WSLPrinter");
        public static NLog.Logger LogMonitor = NLog.LogManager.GetLogger("HealthError");
	}
}