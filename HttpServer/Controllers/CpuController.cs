using System.Linq;
using System.Net;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using HttpServer;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;

namespace HardwareMonitor.HttpServer.Controllers
{
    public class CpuController : WebApiController
    {
        private readonly IMonitor _monitor;
        private readonly IComponentTranslator<IComponentDto> _translator;

        public CpuController()
        {
            _monitor = DataConfiguration.CpuMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/cpu")]
        public bool GetPeople(WebServer server, HttpListenerContext context)
        {
            var responseData = _monitor
                .GetComponents()
                .Select(
                    c => c.TranslateWith(_translator)
                );
            return context.JsonResponse(responseData);
        }
    }
}