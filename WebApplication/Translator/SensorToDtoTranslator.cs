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
                { typeof(ClockSensor), SensorType.Clock },
                { typeof(LoadSensor), SensorType.Load },
                { typeof(PowerSensor), SensorType.Power }
            };
        }

        private ISensorDto DoTranslation(ISensor sensor)
        {
            return new SensorDto(sensor, _dtoStrategies[sensor.GetType()]);
        }

        public ISensorDto Translate(PowerSensor sensor)
        {
            return DoTranslation(sensor);
        }

        public ISensorDto Translate(LoadSensor sensor)
        {
            return DoTranslation(sensor);
        }

        public ISensorDto Translate(ClockSensor sensor)
        {
            return DoTranslation(sensor);
        }

        public ISensorDto Translate(TemperatureSensor sensor)
        {
            return DoTranslation(sensor);
        }
    }
}