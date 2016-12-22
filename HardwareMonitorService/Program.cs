using System;
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

            bool isSentientInstalled = true;
            try
            {
                isSentientInstalled = InstallChecker.IsSentientInstalled();
            }
            catch (Exception e)
            {
                EventLogger.LogError(e.StackTrace);
            }

            if (!isSentientInstalled)
            {
                EventLogger.LogDebug("Sentient not installed; removing service");

                var hardwareMonitorServiceExe = new FileInfo("HardwareMonitorService.exe");
                ServiceManager serviceManager = new ServiceManager("HardwareMonitor", hardwareMonitorServiceExe.FullName);
                serviceManager.StopService();
                serviceManager.DeleteService();
                return;
            }
            EventLogger.LogDebug("Sentient installed");

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
