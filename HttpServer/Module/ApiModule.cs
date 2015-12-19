using System.Collections.Generic;
using System.Linq;
using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using Nancy;

namespace HttpServer.Module
{
    public abstract class ApiModule : NancyModule
    {
        private readonly IMonitor _monitor;
        private readonly IComponentTranslator<IComponentDto> _translator;

        protected ApiModule(IMonitor monitor, IComponentTranslator<IComponentDto> translator)
        {
            _monitor = monitor;
            _translator = translator;
        }

        public Response GetResponse()
        {
            return Response.AsJson(GetData());
        }

        private IEnumerable<IComponentDto> GetData()
        {
            return _monitor
                .GetComponents()
                .Select(
                    c => c.TranslateWith(_translator)
                );
        }

        private IComponentDto GetData(int id)
        {
            return _monitor
                .GetComponents()
                .ElementAt(id)
                .TranslateWith(_translator);
        }
    }
}