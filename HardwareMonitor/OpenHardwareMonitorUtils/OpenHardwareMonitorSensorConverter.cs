﻿using System.Collections.Generic;
using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;

namespace HardwareMonitor.OpenHardwareMonitorUtils
{
    public class OpenHardwareMonitorSensorConverter
    {
        private readonly Dictionary<SensorType, Model.ISensor> _sensorConverters;

        public OpenHardwareMonitorSensorConverter()
        {
            _sensorConverters = new Dictionary<SensorType, Model.ISensor>()
            {
                { SensorType.Temperature, new TemperatureSensor() },
                { SensorType.Clock, new ClockSensor() },
                { SensorType.Load, new LoadSensor() },
                { SensorType.Power, new PowerSensor() },
                { SensorType.Data, new DataSensor() }
            };
        }

        private Model.ISensor FillSensorData(Model.ISensor sensor, OpenHardwareMonitor.Hardware.ISensor s) {
            sensor.Id = s.Identifier.ToString();
            sensor.Name = s.Name;
            sensor.Value = s.Value;
            sensor.Min = s.Min;
            sensor.Max = s.Max;

            return sensor;
        }

        public Model.ISensor ConvertSensor(OpenHardwareMonitor.Hardware.ISensor hardwareSensor)
        {
            if (!_sensorConverters.ContainsKey(hardwareSensor.SensorType))
                return null;

            Model.ISensor sensor = _sensorConverters[hardwareSensor.SensorType];
            return FillSensorData(sensor, hardwareSensor);

        }
    }
}
