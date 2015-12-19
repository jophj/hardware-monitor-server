using System;
using System.Threading;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using static System.Configuration.ConfigurationSettings;

namespace HttpServer
{
    public class Bootstrapper: DefaultNancyBootstrapper
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

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            });
        }
    }
}
