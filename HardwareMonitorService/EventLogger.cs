using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareMonitorService
{
    public static class EventLogger
    {
        public static string Source = "HardwareMonitorService";
        public static EventLog EventLog = new EventLog("Application");

        public static void LogDebug(string message)
        {
            Log(message, EventLogEntryType.Information);
        }

        public static void LogError(string message)
        {
            Log(message, EventLogEntryType.Error);
        }

        private static void Log(string message, EventLogEntryType entryType)
        {
            EventLog.WriteEntry(Source, message, entryType);

            if (Environment.UserInteractive)
            {
                Console.WriteLine(message);
            }
        }

    }
}
