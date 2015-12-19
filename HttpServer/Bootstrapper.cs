using System;
using System.Threading;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using Nancy.Hosting.Self;
using static System.Configuration.ConfigurationSettings;

namespace HttpServer
{
    public class Bootstrapper
    {
        public static IMonitor MemoryMonitor = new MemoryMonitor();
        public static IMonitor CpuMonitor = new CpuMonitor();
        public static IMonitor GpuMonitor = new GpuMonitor();
        public static IMonitor StorageMonitor = new StorageMonitor();
        public static IComponentTranslator<IComponentDto> ComponentTranslator = new ComponentToDtoTranslator();

        public int WebServerPort = 6620;

        public Bootstrapper()
        {
            string webServerPortConfiguration = AppSettings["port"];
            if (!String.IsNullOrEmpty(webServerPortConfiguration))
                WebServerPort = Int32.Parse(webServerPortConfiguration);
        }

        public void StartWebServer()
        {
            string uri = "http://localhost:" + WebServerPort+"/";
            using (var host = new NancyHost(new Uri(uri)))
            {
                host.Start();
                while(true)
                    Thread.Sleep(1024);
            }
        }
    }
}
