namespace HardwareMonitor.HttpServer.Controllers
{
    public class CpuController : AbstractApiController
    {
        public CpuController()
        {
            _monitor = DataConfiguration.CpuMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }
    }
}