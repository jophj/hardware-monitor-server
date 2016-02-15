using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HttpServer.Module
{
    public class GpuModule : ApiModule
    {
        public GpuModule(GpuMonitor monitor) : base(monitor, Bootstrapper.Translator)
        {
            Get["/api/gpu"] = _ => GetResponse();
        }
    }
}