using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace HardwareMonitor.Utils
{
    public interface IHardwareConverter
    {
        IComponent ConvertHardware(IHardware hardware);
    }

    public class CpuConverter : IHardwareConverter
    {
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
