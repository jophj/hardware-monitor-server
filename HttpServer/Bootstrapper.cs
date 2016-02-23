using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using HardwareMonitor.NetworkUtils;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace HttpServer
{
    public class Bootstrapper: DefaultNancyBootstrapper
    {
        public static IComponentTranslator<IComponentDto> Translator = new ComponentToDtoTranslator();
        public static int IfIDontAccessThisPropertyServiceDoesntStarts = 6620;

        public Bootstrapper()
        {
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
                container.Register<DriveMonitor, DriveMonitor>();

                container.Register<IComponentTranslator<IComponentDto>, ComponentToDtoTranslator>().AsSingleton();

                container.Register<NetworkInterfaceConverter, NetworkInterfaceConverter>();
            });
        }
    }
}
