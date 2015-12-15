namespace HardwareMonitor.HttpServer.Controllers
{
    public class StorageController : AbstractApiController
    {
        public StorageController()
        {
            _monitor = DataConfiguration.StorageMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }

    }
}
