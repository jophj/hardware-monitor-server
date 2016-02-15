using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HttpServer.Module
{
    public class CpuModule : ApiModule
    {
        public CpuModule(CpuMonitor monitor) : base(monitor, Bootstrapper.Translator)
        {
            Get["/api/cpu"] = _ => GetResponse();
        }
    }
}