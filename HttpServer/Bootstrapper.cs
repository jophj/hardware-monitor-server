using System;
using System.Diagnostics;
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
        public static int WebServerPort = 6620;

        public Bootstrapper()
        {
            string webServerPortConfiguration = AppSettings["port"];
            if (!IsNullOrEmpty(webServerPortConfiguration))
                WebServerPort = int.Parse(webServerPortConfiguration);

            Process deleteRule = new Process();
            deleteRule.StartInfo.FileName = "netsh";
            deleteRule.StartInfo.Arguments =
                $"advfirewall firewall delete rule name=\"Allow hardware monitor\"";
            deleteRule.StartInfo.CreateNoWindow = true;
            deleteRule.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            deleteRule.Start();
            deleteRule.WaitForExit();

            Process addRule = new Process();
            addRule.StartInfo.FileName = "netsh";
            addRule.StartInfo.Arguments =
                $"advfirewall firewall add rule name=\"Allow hardware monitor\" protocol=TCP dir=in localport={WebServerPort} action=allow";
            addRule.StartInfo.CreateNoWindow = true;
            addRule.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            addRule.Start();
            addRule.WaitForExit();
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
