using HardwareMonitor.Monitor;

namespace HttpServer.Module
{
    public class DriveModule : ApiModule
    {
        public DriveModule(DriveMonitor monitor) : base(monitor, Bootstrapper.Translator)
        {
            Get["/api/drives"] = _ => GetResponse();
        }
    }
}