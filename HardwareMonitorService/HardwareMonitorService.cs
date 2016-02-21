using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using Nancy.Hosting.Self;

namespace HardwareMonitorService
{
    partial class HardwareMonitorService : ServiceBase
    {
        private NancyHost _host;
        private StreamWriter _logStream { get; set; }

        public HardwareMonitorService()
        {
            _logStream = new StreamWriter("service.log");
            _logStream.WriteLine("InitializeComponent()");
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            int webServerPort = 6620;
            //SettingsManager settingsManager = new SettingsManager();
            //int webServerPort = settingsManager.GetSettings().WebServerPort;

            //CreateFirewallRule(webServerPort);
            _logStream.WriteLine("Starting service...");
            _logStream.Flush();

            string uri = "http://localhost:" + webServerPort + "/";
            _host = new NancyHost(new Uri(uri));
            _logStream.WriteLine("Starting Nancy...");
            _logStream.Flush();
            _host.Start();
            _logStream.WriteLine("service started...");
            _logStream.Flush();
        }

        private void CreateFirewallRule(int webServerPort)
        {
            Process deleteRule = new Process();
            deleteRule.StartInfo.FileName = "netsh";
            deleteRule.StartInfo.Arguments =
                $"advfirewall firewall delete rule name=\"Allow hardware monitor\"";
            deleteRule.StartInfo.CreateNoWindow = true;
            deleteRule.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            deleteRule.Start();
            deleteRule.WaitForExit();

            Process addRule = new Process();
            addRule.StartInfo.FileName = "netsh";
            addRule.StartInfo.Arguments =
                $"advfirewall firewall add rule name=\"Allow hardware monitor\" protocol=TCP dir=in localport={webServerPort} action=allow";
            addRule.StartInfo.CreateNoWindow = true;
            addRule.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            addRule.Start();
            addRule.WaitForExit();
        }

        protected override void OnStop()
        {
            _host.Stop();
        }
    }
}
