using HardwareMonitor.Model.Translator;
using System.Collections.Generic;
using System;

namespace HardwareMonitor.Model
{
    public interface IComponent : IComponentTranslateable
    {
        string Id { get; set; }
        string Name { get; set; }

        IEnumerable<ISensor> Sensors { get; set; }
    }

    public abstract class Component : IComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ISensor> Sensors { get; set; }

        public abstract TDest TranslateWith<TDest>(IComponentTranslator<TDest> translator);
    }

    public class CpuComponent : Component
    {
        public override TDest TranslateWith<TDest>(IComponentTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }

    public class MemoryComponent : Component
    {
        public override TDest TranslateWith<TDest>(IComponentTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }

    public class GpuComponent : Component
    {
        public override TDest TranslateWith<TDest>(IComponentTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }
}