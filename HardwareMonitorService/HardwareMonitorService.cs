using System;
using System.Configuration.Install;
using System.ServiceProcess;
using HttpServer;
using Nancy.Hosting.Self;

namespace HardwareMonitorService
{
    partial class HardwareMonitorService : ServiceBase
    {
        private NancyHost _host;

        public HardwareMonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string uri = "http://localhost:" + Bootstrapper.WebServerPort + "/";
            _host = new NancyHost(new Uri(uri));
            _host.Start();
        }

        protected override void OnStop()
        {
            _host.Stop();
        }
    }
}
