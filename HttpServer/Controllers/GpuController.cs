using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;

namespace HardwareMonitor.HttpServer.Controllers
{
    public class GpuController : ApiController
    {
        public GpuController(IMonitor monitor, IComponentTranslator<IComponentDto> translator) : base(monitor, translator)
        {
        }
    }
}
