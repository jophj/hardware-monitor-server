using System;
using System.Threading;
using HttpServer;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new Bootstrapper().StartWebServer();

            while (true)
            {
                Thread.Sleep(1024);
            }
        }
    }
}
