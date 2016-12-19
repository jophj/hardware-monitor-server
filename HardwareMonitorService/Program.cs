using HardwareMonitorApplication;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            
            if (!IsSentientInstalled())
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

        private static bool IsSentientInstalled()
        {
            try {
                IEnumerable<RegistryKey> usersKeys = Registry.Users.GetSubKeyNames().Select(n => Registry.Users.OpenSubKey(n));
                foreach (RegistryKey userKey in usersKeys)
                {
                    RegistryKey uninstallKey = userKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                    if (uninstallKey != null)
                    {
                        IEnumerable<RegistryKey> appKeys = uninstallKey.GetSubKeyNames().Select(n => uninstallKey.OpenSubKey(n));
                        foreach (RegistryKey appKey in appKeys)
                        {
                            if (
                                appKey.GetValue("DisplayName") != null &&
                                appKey.GetValueKind("DisplayName") == RegistryValueKind.String &&
                                appKey.GetValue("DisplayName").ToString().Equals("Sentient")
                            )
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception e) {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return true;
            }
        }
    }
}
