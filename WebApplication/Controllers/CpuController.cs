using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using WebApplication.Translator;

namespace WebApplication.Controllers
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