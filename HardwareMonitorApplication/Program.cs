using System;
using System.IO;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var hardwareMonitorServiceExe = new FileInfo("HardwareMonitorService.exe");
            ServiceManager serviceManager = new ServiceManager("HardwareMonitor", hardwareMonitorServiceExe.FullName);

            serviceManager.StopService();
            serviceManager.DeleteService();
            serviceManager.CreateService();
            serviceManager.StartService();
        }
    }
}
