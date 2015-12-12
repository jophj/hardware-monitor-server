using HardwareMonitor.Model;
using HardwareMonitor.Utils;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HardwareMonitor.Monitor
{
    public interface IMonitor
    {
        IEnumerable<IComponent> GetComponents();
    }
}
