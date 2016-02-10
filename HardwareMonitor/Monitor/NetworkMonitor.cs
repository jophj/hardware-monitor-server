using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using HardwareMonitor.Model;
using HardwareMonitor.NetworkUtils;

namespace HardwareMonitor.Monitor
{
    public class NetworkMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            NetworkInterfaceConverter converter = new NetworkInterfaceConverter();
            var netComponents = NetworkInterface.GetAllNetworkInterfaces()
                .Select(converter.ConvertNetworkInterface);

            return netComponents;
        }
    }
}