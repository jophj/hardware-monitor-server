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

    public class TemperatureSensor: ISensor
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public double? Value { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }

        public TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }
}