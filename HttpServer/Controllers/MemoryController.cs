namespace HardwareMonitor.HttpServer.Controllers
{
    public class MemoryController: AbstractApiController
    {
        public MemoryController()
        {
            _monitor = DataConfiguration.MemoryMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }
    }
}
