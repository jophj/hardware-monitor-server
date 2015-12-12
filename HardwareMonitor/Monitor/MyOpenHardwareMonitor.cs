using HardwareMonitor.Model;
using HardwareMonitor.Utils;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareMonitor.Monitor
{
    public abstract class MyOpenHardwareMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            OpenHardwareMonitorService openHardwareMonitor = OpenHardwareMonitorService.GetInstance();
            IEnumerable<IHardware> hardware = GetHardware(openHardwareMonitor);

            OpenHardwareMonitorHardwareConverter converter = new OpenHardwareMonitorHardwareConverter(GetComponent());

            return hardware.Select(converter.ConvertHardware);
        }

        internal abstract IComponent GetComponent();
        internal abstract IEnumerable<IHardware> GetHardware(OpenHardwareMonitorService openHardwareMonitor);
    }


    public class CpuMonitor : MyOpenHardwareMonitor
    {
        internal override IComponent GetComponent()
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
        internal override IComponent GetComponent()
        {
            return new MemoryComponent();
        }

        internal override IEnumerable<IHardware> GetHardware(OpenHardwareMonitorService openHardwareMonitor)
        {
            return openHardwareMonitor.GetMemoryHardware();
        }
    }
}
