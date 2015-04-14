using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CJia.Server.Service
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Service s = new Service();
                string[] args = { "a", "b" };
                s.Start(args);
                Console.ReadLine();
                s.Stop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new Service() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
