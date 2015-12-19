using System;
using System.Diagnostics;
using System.Threading;
using HttpServer;
using Nancy.Hosting.Self;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new Bootstrapper().StartWebServer();
        }
    }
}
