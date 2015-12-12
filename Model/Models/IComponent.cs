using HardwareMonitor.Model.Translator;
using System.Collections.Generic;

namespace HardwareMonitor.Model
{
    public class CpuComponent : IComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ISensor> Sensors { get; set; }

        public TDest TranslateWith<TDest>(IComponentTranslator<TDest> translator)
        {
            return translator.Translate(this);
        }
    }
}