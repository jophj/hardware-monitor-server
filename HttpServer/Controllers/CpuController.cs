﻿using System.Linq;
using System.Net;
using HardwareMonitor.HttpServer;
using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;

namespace HttpServer.Controllers
{
    public class CpuController : WebApiController
    {
        private readonly IMonitor _monitor;
        private readonly IComponentTranslator<IComponentDto> _translator;

        public CpuController()
        {
            _monitor = Bootstrapper.CpuMonitor;
            _translator = Bootstrapper.ComponentTranslator;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/cpu")]
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