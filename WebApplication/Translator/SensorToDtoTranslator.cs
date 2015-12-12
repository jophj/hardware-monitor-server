using System;
using HardwareMonitor.Model;
using HardwareMonitor.Model.Translator;
using System.Collections.Generic;

namespace WebApplication.Translator
{
    internal class SensorToDtoTranslator : ISensorTranslator<ISensorDto>
    {
        private readonly Dictionary<Type, SensorType> _dtoStrategies;

        public SensorToDtoTranslator()
        {
            _dtoStrategies = new Dictionary<Type, SensorType>()
            {
                { typeof(TemperatureSensor), SensorType.Temperature },
                { typeof(ClockSensor), SensorType.Clock }
            };
        }

        public ISensorDto Translate(ClockSensor sensor)
        {
            return new SensorDto(sensor, _dtoStrategies[sensor.GetType()]);
        }

        public ISensorDto Translate(TemperatureSensor sensor)
        {
            return new SensorDto(sensor, _dtoStrategies[sensor.GetType()]);
        }
    }
}