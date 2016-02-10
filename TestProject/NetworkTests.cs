using Microsoft.VisualStudio.TestTools.UnitTesting;
using HardwareMonitor.Monitor;
using HardwareMonitor.Model;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class NetworkComponentTests
    {
        [TestMethod]
        public void Network_Has_Name()
        {
            IMonitor networkMonitor = new NetworkMonitor();
            // Yeah, I know, your's different
            Assert.IsTrue(networkMonitor.GetComponents().Any(x => x.Name.StartsWith("Intel")));
        }

        [TestMethod]
        public void Network_Has_Throughput_Sensor()
        {
            IMonitor networkMonitor = new NetworkMonitor();
            Assert.IsTrue(networkMonitor.GetComponents().First().Sensors.OfType<ThroughputSensor>().Any());
        }

        [TestMethod]
        public void Network_Has_Throughput()
        {
            IMonitor networkMonitor = new NetworkMonitor();
            var throughputSensors = networkMonitor.GetComponents().First().Sensors.OfType<ThroughputSensor>();

            Assert.IsTrue(throughputSensors.All(t => t.Value.HasValue));
        }
    }
}
