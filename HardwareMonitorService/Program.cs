using System.IO;
using System.ServiceProcess;
using Nancy.ViewEngines;
using Newtonsoft.Json;

namespace HardwareMonitorService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var _logStream = new StreamWriter("service.log");
            _logStream.WriteLine("dsadasd");
            _logStream.Flush();

            var ServicesToRun = new ServiceBase[]
            {
                new HardwareMonitorService(),
            };
            ServiceBase.Run(ServicesToRun);
        }
    }

    public class SettingsManager
    {
        private readonly string _settingsFileName = "settings.json";

        private readonly ServiceSettings _defaultSettings = new ServiceSettings()
        {
            WebServerPort = 6620
        };

        public ServiceSettings GetSettings()
        {
            string fileContent = ReadSettingsFile();
            if (string.IsNullOrEmpty(fileContent))
            {
                return _defaultSettings;
            }

            return JsonConvert.DeserializeObject<ServiceSettings>(fileContent);
        }

        private string ReadSettingsFile()
        {
            StreamReader fileStream = null;
            try
            {
                fileStream = new StreamReader(_settingsFileName);
            }
            catch
            {
                return null;
            }

            string settingsContent = fileStream.ReadToEnd();
            return settingsContent;
        }
    }

    public class ServiceSettings
    {
        public int WebServerPort { get; set; }
    }
}
