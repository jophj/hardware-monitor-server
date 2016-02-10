using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HardwareMonitor.Monitor;
using HardwareMonitor.Model;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class CpuComponentTests
    {
        [TestMethod]
        public void CPU_Has_Name()
        {
            IMonitor cpuMonitor = new CpuMonitor();

            // Yeah, I know
            Assert.AreEqual(cpuMonitor.GetComponents().First().Name, "Intel Core i7-4500U");
        }

        [TestMethod]
        public void CPU_Has_Temperature_Sensor()
        {
            IMonitor cpuMonitor = new CpuMonitor();

            Assert.IsTrue(cpuMonitor.GetComponents().First().Sensors.OfType<TemperatureSensor>().Any());
        }

        [TestMethod]
        public void CPU_Has_Temperature()
        {
            IMonitor cpuMonitor = new CpuMonitor();
            var temperatureSensors = cpuMonitor.GetComponents().First().Sensors.OfType<TemperatureSensor>();

            Assert.IsTrue(temperatureSensors.All(t => t.Value.HasValue));
        }
    }
}
