using HardwareMonitor.Model.Translator;
using HardwareMonitor.Monitor;
using HardwareMonitor.HttpServer;
using HardwareMonitor.HttpServer.Translator;

namespace HardwareMonitor.HttpServer
{
    public static class DataConfiguration
    {
        public static IMonitor MemoryMonitor = new MemoryMonitor();
        public static IMonitor CpuMonitor = new CpuMonitor();
        public static IMonitor GpuMonitor = new GpuMonitor();
        public static IMonitor StorageMonitor = new StorageMonitor();

        public static IComponentTranslator<IComponentDto> ComponentTranslator = new ComponentToDtoTranslator();
    }
}
