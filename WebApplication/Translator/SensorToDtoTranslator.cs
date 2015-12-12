using System;
using HardwareMonitor.Model;
using HardwareMonitor.Model.Translator;

namespace WebApplication.Translator
{
    internal class SensorToDtoTranslator : ISensorTranslator<ISensorDto>
    {
        public ISensorDto Translate(TemperatureSensor sensor)
        {
            SensorDto dto = new SensorDto(sensor);
            dto.SensorType = SensorType.Temperature.ToString();

            return dto;
        }
    }
}