using HardwareMonitor.Model;
using System.Collections.Generic;
using System;

namespace HardwareMonitor.HttpServer
{
    public enum ComponentType
    {
        Cpu,
        Memory,
        Gpu,
        Storage
    }

    public enum SensorType
    {
        Temperature,
        Clock,
        Load,
        Power,
        Data
    }

    public interface IComponentDto
    {
        string Id { get; set; }
        string Name { get; set; }
        string ComponentType { get; set; }

        IEnumerable<ISensorDto> Sensors { get; set; }
    }

    public interface ISensorDto
    {
        string Id { get; set; }
        string Name { get; set; }
        double? Value { get; set; }
        double? Max { get; set; }
        double? Min { get; set; }
    }

    public class ComponentDto : IComponentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ComponentType { get; set; }
        public IEnumerable<ISensorDto> Sensors { get; set; }


        public ComponentDto(IComponent component)
        {
            Id = component.Id;
            Name = component.Name;
        }

        public ComponentDto(IComponent component, ComponentType componentType): this(component)
        {
            ComponentType = componentType.ToString();
        }
    }

    public class SensorDto : ISensorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }
        public string SensorType { get; set; }


        public SensorDto(ISensor sensor)
        {
            Id = sensor.Id;
            Name = sensor.Name;
            Value = sensor.Value;
            Max = sensor.Max;
            Min = sensor.Min;
        }

        public SensorDto(ISensor sensor, SensorType sensorType): this(sensor)
        {
            SensorType = sensorType.ToString();
        }
    }
}