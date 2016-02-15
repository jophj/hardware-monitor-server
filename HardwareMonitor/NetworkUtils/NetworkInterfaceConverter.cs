using System.Net.NetworkInformation;
using HardwareMonitor.Model;

namespace HardwareMonitor.NetworkUtils
{
    public class NetworkInterfaceConverter
    {
        public IComponent ConvertNetworkInterface(NetworkInterface networkInterface)
        {
            if (networkInterface == null)
                return null;

            NetworkComponent netComponent = new NetworkComponent()
            {
                Id = networkInterface.Id,
                Name = networkInterface.Description,
                Sensors = null
            };

            return netComponent;
        }
    }
}
