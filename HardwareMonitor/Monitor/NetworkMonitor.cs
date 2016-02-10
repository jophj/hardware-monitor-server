using System.Collections.Generic;
using HardwareMonitor.Model;

namespace HardwareMonitor.Monitor
{
    public class NetworkMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            return new NetworkComponent();
        }
    }
}