using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace HardwareMonitor.Utils
{
    public class OpenHardwareMonitorHardwareConverter
    {
        public IComponent ConvertHardware(IHardware hardware, IComponent component)
        {
            if (hardware == null)
                return null;

            component.Id = hardware.Identifier.ToString();
            component.Name = hardware.Name;

            component.Sensors = hardware.Sensors
                .Select(new OpenHardwareMonitorSensorConverter().ConvertSensor)
                .Where(s => s != null);

            return component;
        }
    }
}
