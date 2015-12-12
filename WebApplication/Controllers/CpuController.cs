using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using WebApplication.Translator;

namespace WebApplication.Controllers
{
    public class CpuController : ApiController
    {
        private static readonly IMonitor _cpuMonitor = new CpuMonitor();
        private static readonly IComponentTranslator<IComponentDto> _translator = new ComponentToDtoTranslator();

        // GET: api/Cpu
        public IEnumerable<IComponentDto> Get()
        {
            return _cpuMonitor
                .GetComponents()
                .Select(
                    c => c.TranslateWith(_translator)
                );
        }

        // GET: api/Cpu/5
        public IComponentDto Get(int id)
        {
            return _cpuMonitor.GetComponents().ElementAt(id).TranslateWith(_translator);
        }
    }
}
