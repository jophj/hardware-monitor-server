using System;
using HttpServer;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new DataConfiguration().ConfigureWebServer();
        }
    }
}
