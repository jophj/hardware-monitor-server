using System;
using System.Threading.Tasks;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Controllers;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
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
                .CreateWithConsole(url)
                .EnableCors();

            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<CpuController>();

            Task task = server.RunAsync();


#if DEBUG
            var browser = new System.Diagnostics.Process()
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
            };
            browser.Start();
#endif

            Console.ReadKey(true);
            try
            {
                task.Wait();
            }
            catch (Exception e)
            {
                server.Dispose();
            }
        }
    }

}
