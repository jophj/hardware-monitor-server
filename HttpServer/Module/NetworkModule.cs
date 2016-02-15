using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HttpServer.Module
{
    public class NetworkModule : ApiModule
    {
        public NetworkModule(NetworkMonitor monitor) : base(monitor, Bootstrapper.Translator)
        {
            Get["/api/network"] = _ => GetResponse();
        }
    }
}