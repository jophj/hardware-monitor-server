using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public abstract class AbstractApiController : ApiController
    {
        protected static IMonitor _monitor;
        protected static IComponentTranslator<IComponentDto> _translator;

        // GET: api/{controller}
        public IEnumerable<IComponentDto> Get()
        {
            return _monitor
                .GetComponents()
                .Select(
                    c => c.TranslateWith(_translator)
                );
        }

        // GET: api/{controller}/5
        public IComponentDto Get(int id)
        {
            return _monitor.GetComponents().ElementAt(id).TranslateWith(_translator);
        }
    }
}