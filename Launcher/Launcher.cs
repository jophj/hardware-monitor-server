using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
