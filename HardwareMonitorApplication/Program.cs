﻿using System;
using System.IO;
using System.Threading;
using HardwareMonitorService;
using Nancy.Hosting.Self;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var hardwareMonitorServiceExe = new FileInfo("HardwareMonitorService.exe");
            ServiceManager serviceManager = new ServiceManager("HardwareMonitor", hardwareMonitorServiceExe.FullName);

            SettingsManager settingsManager = new SettingsManager();
            settingsManager.SetSettings(new ServiceSettings() {WebServerPort = 6620});
            serviceManager.StopService();
            serviceManager.DeleteService();
            serviceManager.CreateService();
            serviceManager.StartService();

            /*string uri = $"http://localhost:{6200}/";
            var _host = new NancyHost(new Uri(uri));
            _host.Start();
            while (true)
            {
                Thread.Sleep(123);
            }*/
        }
    }
}
