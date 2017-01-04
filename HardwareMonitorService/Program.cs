using System;
using System.IO;
using System.ServiceProcess;

namespace HardwareMonitorService
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HardwareMonitorService(),
            };

            EventLogger.LogDebug("Starting service");
            ServiceBase.Run(ServicesToRun);
        }
    }
}
