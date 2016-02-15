using System;
using System.Collections.Generic;
using System.Linq;
using OpenHardwareMonitor.Hardware;

namespace HardwareMonitor.OpenHardwareMonitorUtils
{
    public class OpenHardwareMonitorService
    {
        private static OpenHardwareMonitorService _hardwareMonitor;
        private readonly Computer _computer;

        private OpenHardwareMonitorService() {
            _computer = new Computer
            {
                CPUEnabled = true,
                GPUEnabled = true,
                RAMEnabled = true,
                HDDEnabled = true,
                MainboardEnabled = true,
                FanControllerEnabled = true
            };

            try {
                _computer.Open();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static OpenHardwareMonitorService GetInstance()
        {
            return _hardwareMonitor ?? (_hardwareMonitor = new OpenHardwareMonitorService());
        }

        private void Update(IEnumerable<IHardware> hardware)
        {
            foreach (var h in hardware)
            {
                h.Update();
            }
        }

        internal IEnumerable<IHardware> GetCpuHardware()
        {
            IEnumerable<IHardware> hardware = _computer.Hardware.Where(h => h.HardwareType == HardwareType.CPU);
            Update(hardware);
            return hardware;
        }

        internal IEnumerable<IHardware> GetMemoryHardware()
        {
            IEnumerable<IHardware> hardware = _computer.Hardware.Where(h => h.HardwareType == HardwareType.RAM);
            Update(hardware);
            return hardware;
        }

        internal IEnumerable<IHardware> GetGpuHardware()
        {
            IEnumerable<IHardware> hardware = _computer.Hardware
                .Where(h =>
                    h.HardwareType == HardwareType.GpuAti ||
                    h.HardwareType == HardwareType.GpuNvidia
                );
            Update(hardware);
            return hardware;
        }

        internal IEnumerable<IHardware> GetStorageHardware()
        {
            IEnumerable<IHardware> hardware = _computer.Hardware
                .Where(h =>
                    h.HardwareType == HardwareType.HDD
                );
            Update(hardware);
            return hardware;
        }
    }
}
