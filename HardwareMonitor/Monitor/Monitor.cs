using HardwareMonitor.Model;
using System.Collections.Generic;

namespace HardwareMonitor.Monitor
{
    public interface IMonitor
    {
        IEnumerable<IComponent> GetComponents();
    }
}
