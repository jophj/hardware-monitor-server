using System;
using System.Threading;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using HardwareMonitor.NetworkUtils;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using static System.Configuration.ConfigurationSettings;
using static System.String;

namespace HttpServer
{
    public class Bootstrapper: DefaultNancyBootstrapper
    {
        public static IComponentTranslator<IComponentDto> Translator = new ComponentToDtoTranslator();
        public int WebServerPort = 6620;

        public Bootstrapper()
        {
            string webServerPortConfiguration = AppSettings["port"];
            if (!IsNullOrEmpty(webServerPortConfiguration))
                WebServerPort = int.Parse(webServerPortConfiguration);
        }

        public void StartWebServer()
        {
            string uri = "http://localhost:" + WebServerPort+"/";
            using (var host = new NancyHost(new Uri(uri)))
            {
                host.Start();
                while (true)
                {
                    Thread.Sleep(1024);
                }
            }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

                container.Register<CpuMonitor, CpuMonitor>();
                container.Register<GpuMonitor, GpuMonitor>();
                container.Register<MemoryMonitor, MemoryMonitor>();
                container.Register<NetworkMonitor, NetworkMonitor>();
                container.Register<StorageMonitor, StorageMonitor>();

                container.Register<IComponentTranslator<IComponentDto>, ComponentToDtoTranslator>().AsSingleton();

                container.Register<NetworkInterfaceConverter, NetworkInterfaceConverter>();
            });
        }
    }
}
