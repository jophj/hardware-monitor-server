﻿namespace WebApplication.Controllers
{
    public class GpuController : AbstractApiController
    {
        public GpuController()
        {
            _monitor = DataConfiguration.GpuMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }
    }
}