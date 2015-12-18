using System;
using System.Threading.Tasks;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using HttpServer.Controllers;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;

namespace HttpServer
{
    public class DataConfiguration
    {
        public static IMonitor MemoryMonitor = new MemoryMonitor();
        public static IMonitor CpuMonitor = new CpuMonitor();
        public static IMonitor GpuMonitor = new GpuMonitor();
        public static IMonitor StorageMonitor = new StorageMonitor();

        public static IComponentTranslator<IComponentDto> ComponentTranslator = new ComponentToDtoTranslator();

        public void ConfigureWebServer()
        {
            string url = "http://localhost:9696/";

            var server = WebServer
                .Create(url)
                .EnableCors();

            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<CpuController>();
            server.Module<WebApiModule>().RegisterController<GpuController>();
            server.Module<WebApiModule>().RegisterController<MemoryController>();
            server.Module<WebApiModule>().RegisterController<StorageController>();

            Task task = server.RunAsync();
            Console.ReadKey(true);
            try
            {
                task.Wait();
            }
            catch (Exception)
            {
                server.Dispose();
            }
        }
    }

}
