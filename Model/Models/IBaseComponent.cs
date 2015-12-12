using HardwareMonitor.Model.Translator;
using System.Collections.Generic;

namespace HardwareMonitor.Model
{
    public interface IComponent: IComponentTranslateable
    {
        string Id { get; set; }
        string Name { get; set; }

        IEnumerable<ISensor> Sensors { get; set; }
    }
}
