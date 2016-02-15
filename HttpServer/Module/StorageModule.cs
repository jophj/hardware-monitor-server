using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HttpServer.Module
{
    public class StorageModule : ApiModule
    {
        public StorageModule(StorageMonitor monitor) : base(monitor, Bootstrapper.Translator)
        {
            Get["/api/storage"] = _ => GetResponse();
        }
    }
}