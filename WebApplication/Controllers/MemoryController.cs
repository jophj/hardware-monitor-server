using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication.Translator;

namespace WebApplication.Controllers
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
