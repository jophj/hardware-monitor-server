using System.Linq;
using System.Net;
using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;

namespace HttpServer.Controllers
{
    public class StorageController : WebApiController
    {
        private readonly IMonitor _monitor;
        private readonly IComponentTranslator<IComponentDto> _translator;

        public StorageController()
        {
            _monitor = Bootstrapper.GpuMonitor;
            _translator = Bootstrapper.ComponentTranslator;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/storage")]
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
