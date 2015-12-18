using System.Linq;
using System.Net;
using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;

namespace HttpServer.Controllers
{
    public class MemoryController: WebApiController
    {
        private readonly IMonitor _monitor;
        private readonly IComponentTranslator<IComponentDto> _translator;

        public MemoryController()
        {
            _monitor = DataConfiguration.GpuMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/memory")]
        public bool Get(WebServer server, HttpListenerContext context)
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
