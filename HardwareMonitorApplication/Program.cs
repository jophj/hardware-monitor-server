using System;

namespace HardwareMonitorApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
        }
    }

    public interface ServiceManager
    {

        void InstallService();
    }
}
