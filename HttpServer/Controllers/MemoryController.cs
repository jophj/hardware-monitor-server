using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HardwareMonitor.HttpServer.Controllers
{
    public class MemoryController: ApiController
    {
        public MemoryController(IMonitor monitor, IComponentTranslator<IComponentDto> translator) : base(monitor, translator)
        {
        }
    }
}
