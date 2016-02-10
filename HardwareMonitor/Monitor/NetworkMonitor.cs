using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using HardwareMonitor.Model;
using HardwareMonitor.NetworkUtils;
using OpenHardwareMonitor.Collections;

namespace HardwareMonitor.Monitor
{
    public class NetworkMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            Collection<IComponent> netComponents = new Collection<IComponent>();
            NetworkInterfaceConverter converter = new NetworkInterfaceConverter();

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                var component = converter.ConvertNetworkInterface(netInterface);
                var throughputs = GetThroughputData(netInterface);

                ThroughputSensor sentSensor = new ThroughputSensor()
                {
                    Id = "Bytes sent/sec",
                    Name = "Bytes sent/sec",
                    Value = throughputs.First
                };

                ThroughputSensor receivedSensor = new ThroughputSensor()
                {
                    Id = "Bytes received/sec",
                    Name = "Bytes received / sec",
                    Value = throughputs.Second
                };

                component.Sensors = new[] {sentSensor, receivedSensor};
                netComponents.Add(component);
            }

            return netComponents;
        }

        private Pair<double, double> GetThroughputData(NetworkInterface netInterface)
        {
            DateTime startTime = DateTime.Now;
            long bytesReceived = netInterface.GetIPStatistics().BytesReceived;
            long bytesSent = netInterface.GetIPStatistics().BytesSent;
            Thread.Sleep(128);
            bytesSent = netInterface.GetIPStatistics().BytesReceived - bytesSent;

            TimeSpan timespan = DateTime.Now - startTime;
            double receivedThroughput = (double)bytesReceived / (1024) / timespan.TotalSeconds;
            double sentThroughput = (double)bytesSent / (1024) / timespan.TotalSeconds;

            return new Pair<double, double>(sentThroughput, receivedThroughput);
        }
    }
}