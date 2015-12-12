﻿using HardwareMonitor.Model;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HardwareMonitor.Utils
{
    public class OpenHardwareMonitorService
    {
        private static OpenHardwareMonitorService _hardwareMonitor;
        private Computer _computer;

        private OpenHardwareMonitorService() {
            _computer = new Computer();
            _computer.CPUEnabled = true;
            _computer.GPUEnabled = true;
            _computer.RAMEnabled = true;
            _computer.HDDEnabled = true;
            _computer.MainboardEnabled = true;
            _computer.FanControllerEnabled = true;

            try {
                _computer.Open();
            }
            catch (Exception) { }
            
        }

        public static OpenHardwareMonitorService GetInstance()
        {
            if (_hardwareMonitor == null)
                _hardwareMonitor = new OpenHardwareMonitorService();

            return _hardwareMonitor;
        }

        public IEnumerable<IHardware> GetCpuHardware()
        {
            IEnumerable<IHardware> hardware = _computer.Hardware.Where(h => h.HardwareType == HardwareType.CPU);
            Update(hardware);

            return hardware;
        }

        private void Update(IEnumerable<IHardware> hardware)
        {
            foreach (var h in hardware)
            {
                h.Update();
            }
        }
    }
}