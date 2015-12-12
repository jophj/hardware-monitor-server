using HardwareMonitor.Model;
using HardwareMonitor.Utils;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace HardwareMonitor.Monitor
{
    public interface IMonitor
    {
        IEnumerable<IComponent> GetComponents();
    }


    public class CpuMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            OpenHardwareMonitorService openHardwareMonitor = OpenHardwareMonitorService.GetInstance();
            IEnumerable<IHardware> cpuHardware = openHardwareMonitor.GetCpuHardware();

            CpuConverter cpuConverter = new CpuConverter();

            return cpuHardware.Select(cpuConverter.ConvertHardware);
        }
    }
}
