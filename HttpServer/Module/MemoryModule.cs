using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HttpServer.Module
{
    public class MemoryModule : ApiModule
    {
        public MemoryModule(MemoryMonitor monitor) : base(monitor, Bootstrapper.Translator)
        {
            Get["/api/memory"] = _ => GetResponse();

        }
    }
}