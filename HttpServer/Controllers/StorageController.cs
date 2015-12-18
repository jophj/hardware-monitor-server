using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HardwareMonitor.HttpServer.Controllers
{
    public class StorageController : ApiController
    {
        public StorageController(IMonitor monitor, IComponentTranslator<IComponentDto> translator) : base(monitor, translator)
        {
        }
    }
}
