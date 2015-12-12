using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;

namespace HardwareMonitor.Utils
{
    public interface ISensorConverter
    {
        Model.ISensor ConvertSensor(OpenHardwareMonitor.Hardware.ISensor sensor);
    }

    public class SensorConverter : ISensorConverter
    {
        private Dictionary<SensorType, Func<OpenHardwareMonitor.Hardware.ISensor, Model.ISensor>> _sensorConverters;

        public SensorConverter()
        {
            _sensorConverters = new Dictionary<SensorType, Func<OpenHardwareMonitor.Hardware.ISensor, Model.ISensor>>()
            {
                {
                    SensorType.Temperature,
                    s => {
                        return new TemperatureSensor()
                        {
                            Id = s.Identifier.ToString(),
                            Name = s.Name,
                            Value = s.Value,
                            Min = s.Min,
                            Max = s.Max
                        };
                    }
                }
            };
        }

        public Model.ISensor ConvertSensor(OpenHardwareMonitor.Hardware.ISensor sensor)
        {
            if (!_sensorConverters.ContainsKey(sensor.SensorType))
                return null;

            return _sensorConverters[sensor.SensorType](sensor);
        }
    }
}
