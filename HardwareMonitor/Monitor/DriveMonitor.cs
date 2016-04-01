using System.Collections.Generic;
using System.IO;
using System.Linq;
using HardwareMonitor.Model;

namespace HardwareMonitor.Monitor
{
    public class DriveMonitor : IMonitor
    {
        public IEnumerable<IComponent> GetComponents()
        {
            return DriveInfo.GetDrives()
                .Where(d => d.TotalSize > 0 && d.TotalFreeSpace > 0)
                .Select(GetDriveComponent);
        }

        private DriveComponent GetDriveComponent(DriveInfo drive)
        {
            var component = new DriveComponent()
            {
                Id = drive.Name,
                Name = drive.Name,
                Sensors = new[] {
                    new DataSensor()
                    {
                        Id = "TotalSize",
                        Name = "TotalSize",
                        Value = drive.TotalSize
                    },
                    new DataSensor()
                    {
                        Id = "TotalFreeSpace",
                        Name = "TotalFreeSpace",
                        Value = drive.TotalFreeSpace
                    }
                }
            };

            return component;
        }
    }
}