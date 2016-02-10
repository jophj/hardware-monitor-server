using System.Linq;
using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;

namespace HardwareMonitor.OpenHardwareMonitorUtils
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
