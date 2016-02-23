using System.IO;
using Newtonsoft.Json;

namespace HardwareMonitorService
{
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

        public void SetSettings(ServiceSettings settings)
        {
            string json = JsonConvert.SerializeObject(settings);
            WriteSettingsFile(json);
        }

        private void WriteSettingsFile(string json)
        {
            StreamWriter fileStream = null;
            try
            {
                fileStream = new StreamWriter(_settingsFileName, false);
            }
            catch
            {
                return;
            }

            fileStream.Write(json);
            fileStream.Close();
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
