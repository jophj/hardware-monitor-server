using System;
using HardwareMonitor.Model.Translator;

namespace HardwareMonitor.Model
{
    public interface ISensor: ISensorTranslateable
    {
        string Id { get; set; }
        string Name { get; set; }

        double? Value { get; set; }
        double? Max { get; set; }
        double? Min { get; set; }
    }

    // useful to avoid to write all the code implementing the auto properties
    public abstract class Sensor: ISensor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }

        public abstract TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator);
    }

    public class TemperatureSensor : Sensor
    {
        public override TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }

    public class ClockSensor : Sensor
    {
        public override TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }

    public class LoadSensor : Sensor
    {
        public override TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }

    public class PowerSensor : Sensor
    {
        public override TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }
}