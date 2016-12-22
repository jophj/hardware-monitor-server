using System.IO;
using System.ServiceProcess;

namespace HardwareMonitorService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            
            if (!InstallChecker.IsSentientInstalled())
            {
                var hardwareMonitorServiceExe = new FileInfo("HardwareMonitorService.exe");
                ServiceManager serviceManager = new ServiceManager("HardwareMonitor", hardwareMonitorServiceExe.FullName);
                serviceManager.StopService();
                serviceManager.DeleteService();
                return;
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HardwareMonitorService(),
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
