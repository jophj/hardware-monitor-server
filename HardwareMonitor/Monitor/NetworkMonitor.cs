using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using HardwareMonitor.Model;
using HardwareMonitor.NetworkUtils;
using OpenHardwareMonitor.Collections;

namespace HardwareMonitor.Monitor
{
    public class NetworkMonitor : IMonitor
    {
        NetworkInterfaceConverter Converter = new NetworkInterfaceConverter();

        public IEnumerable<IComponent> GetComponents()
        {
            Collection<IComponent> netComponents = new Collection<IComponent>();

            IEnumerable<Task<IComponent>> tasks = NetworkInterface.GetAllNetworkInterfaces().Select(GetThroughputDataAsync);
            IComponent[] components = WaitForResults(tasks).Result;
            return components;
        }

        private async Task<IComponent[]> WaitForResults(IEnumerable<Task<IComponent>> tasks)
        {
            return await Task.WhenAll(tasks);
        }

        private async Task<IComponent> GetThroughputDataAsync(NetworkInterface netInterface)
        {
            var component = Converter.ConvertNetworkInterface(netInterface);

            DateTime startTime = DateTime.Now;
            long bytesReceived = netInterface.GetIPStatistics().BytesReceived;
            long bytesSent = netInterface.GetIPStatistics().BytesSent;

            await Sleep(512);

            bytesSent = netInterface.GetIPStatistics().BytesSent - bytesSent;
            bytesReceived = netInterface.GetIPStatistics().BytesReceived - bytesReceived;

            TimeSpan timespan = DateTime.Now - startTime;
            double receivedThroughput = bytesReceived / timespan.TotalSeconds;
            double sentThroughput = bytesSent / timespan.TotalSeconds;

            ThroughputSensor sentSensor = new ThroughputSensor()
            {
                Id = "Bytes sent/sec",
                Name = "Bytes sent/sec",
                Value = sentThroughput
            };

            ThroughputSensor receivedSensor = new ThroughputSensor()
            {
                Id = "Bytes received/sec",
                Name = "Bytes received/sec",
                Value = receivedThroughput
            };

            component.Sensors = new[] { sentSensor, receivedSensor };

            return component;
        }

        private async Task Sleep(int timeout)
        {
            await Task.Delay(timeout);
        }
    }
}