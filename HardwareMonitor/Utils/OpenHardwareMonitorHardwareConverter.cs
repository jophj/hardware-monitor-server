using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace HardwareMonitor.Utils
{
    public class OpenHardwareMonitorHardwareConverter
    {
        private IComponent cpuComponent;

        public OpenHardwareMonitorHardwareConverter(IComponent cpuComponent)
        {
            this.cpuComponent = cpuComponent;
        }

        public IComponent ConvertHardware(IHardware hardware)
        {
            if (hardware == null)
                return null;

            CpuComponent cpu = new CpuComponent()
            {
                Id = hardware.Identifier.ToString(),
                Name = hardware.Name
            };

            cpu.Sensors = hardware.Sensors
                .Select(new SensorConverter().ConvertSensor)
                .Where(s => s != null);

            return cpu;
        }
    }
}
