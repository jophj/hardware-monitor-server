using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication.Translator;

namespace WebApplication.Controllers
{
    public class MemoryController: ApiController
    {
        private static readonly IMonitor _memoryMonitor = new MemoryMonitor();
        private static readonly IComponentTranslator<IComponentDto> _translator = new ComponentToDtoTranslator();

        // GET: api/Memory
        public IEnumerable<IComponentDto> Get()
        {
            return _memoryMonitor
                .GetComponents()
                .Select(
                    c => c.TranslateWith(_translator)
                );
        }

        // GET: api/Memory/5
        public IComponentDto Get(int id)
        {
            return _memoryMonitor.GetComponents().ElementAt(id).TranslateWith(_translator);
        }
    }
}
