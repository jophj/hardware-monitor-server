using System;
using System.IO;
using Nancy.Hosting.Self;
using System.Threading;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var hardwareMonitorServiceExe = new FileInfo("HardwareMonitorService.exe");

            // use this code to run service code inside application
            string uri = $"http://localhost:{6620}/";
            var _host = new NancyHost(new Uri(uri));
            _host.Start();
            while (true)
            {
                Thread.Sleep(128);
            }
        }
    }
}
