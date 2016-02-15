using Microsoft.VisualStudio.TestTools.UnitTesting;
using HardwareMonitor.Monitor;
using HardwareMonitor.Model;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class NetworkComponentTests
    {
        private readonly NetworkMonitor _networkMonitor;

        public NetworkComponentTests(NetworkMonitor networkMonitor)
        {
            _networkMonitor = networkMonitor;
        }

        [TestMethod]
        public void Network_Has_Name()
        {
            // Yeah, I know, your's different
            Assert.IsTrue(_networkMonitor.GetComponents().Any(x => x.Name.StartsWith("Intel")));
        }

        [TestMethod]
        public void Network_Has_Throughput_Sensor()
        {
            Assert.IsTrue(_networkMonitor.GetComponents().First().Sensors.OfType<ThroughputSensor>().Any());
        }

        [TestMethod]
        public void Network_Has_Throughput()
        {
            var throughputSensors = _networkMonitor.GetComponents().First().Sensors.OfType<ThroughputSensor>();

            Assert.IsTrue(throughputSensors.All(t => t.Value.HasValue));
        }
    }
}
