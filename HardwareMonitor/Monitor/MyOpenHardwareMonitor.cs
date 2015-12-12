using HardwareMonitor.Model;
using HardwareMonitor.Utils;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;

namespace HardwareMonitor.Monitor
{
    public abstract class MyOpenHardwareMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            OpenHardwareMonitorService openHardwareMonitor = OpenHardwareMonitorService.GetInstance();
            IEnumerable<IHardware> hardware = GetHardware(openHardwareMonitor);

            OpenHardwareMonitorHardwareConverter converter = new OpenHardwareMonitorHardwareConverter();

            return hardware.Select(h => converter.ConvertHardware(h, GetEmptyComponent()));
        }

        internal abstract IComponent GetEmptyComponent();
        internal abstract IEnumerable<IHardware> GetHardware(OpenHardwareMonitorService openHardwareMonitor);
    }


    public class CpuMonitor : MyOpenHardwareMonitor
    {
        internal override IComponent GetEmptyComponent()
        {
            return new CpuComponent();
        }

        internal override IEnumerable<IHardware> GetHardware(OpenHardwareMonitorService openHardwareMonitor)
        {
            return openHardwareMonitor.GetCpuHardware();
        }
    }

    public class MemoryMonitor : MyOpenHardwareMonitor
    {
        internal override IComponent GetEmptyComponent()
        {
            return new MemoryComponent();
        }

        internal override IEnumerable<IHardware> GetHardware(OpenHardwareMonitorService openHardwareMonitor)
        {
            return openHardwareMonitor.GetMemoryHardware();
        }
    }

    public class GpuMonitor : MyOpenHardwareMonitor
    {
        internal override IComponent GetEmptyComponent()
        {
            return new GpuComponent();
        }

        internal override IEnumerable<IHardware> GetHardware(OpenHardwareMonitorService openHardwareMonitor)
        {
            return openHardwareMonitor.GetGpuHardware();
        }
    }
}
