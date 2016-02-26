using System.Diagnostics;

namespace Launcher
{
    class Launcher
    {
        public static void Main()
        {
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = "HardwareMonitorApplication.exe",
                    Verb = "runas"
                }
            };
            process.Start();
        }
    }
}
