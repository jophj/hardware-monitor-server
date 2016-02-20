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
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HardwareMonitorService(),
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
