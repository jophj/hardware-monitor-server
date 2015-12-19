using System;
using System.Threading.Tasks;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using HttpServer.Controllers;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;
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

        private WebServer WebServer { get; set; }
        public int WebServerPort = 1337;

        public Bootstrapper()
        {
            string webServerPortConfiguration = AppSettings["port"];
            WebServerPort = Int32.Parse(webServerPortConfiguration);
            WebServer = ConfigureWebServer();
        }

        public Task StartWebServer()
        {
            Task task =  WebServer.RunAsync();

            try
            {
                task.Wait();
            }
            catch (AggregateException)
            {
                WebServer.Dispose();
            }

            return task;
        }

        private WebServer ConfigureWebServer()
        {
            WebServer server = WebServer
                .Create(WebServerPort)
                .EnableCors();

            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<CpuController>();
            server.Module<WebApiModule>().RegisterController<GpuController>();
            server.Module<WebApiModule>().RegisterController<MemoryController>();
            server.Module<WebApiModule>().RegisterController<StorageController>();

            return server;
        }
    }
}
