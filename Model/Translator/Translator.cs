﻿namespace HardwareMonitor.Model.Translator
{
    public interface IComponentTranslator<TDest>
    {
        TDest Translate(CpuComponent component);
        TDest Translate(MemoryComponent memoryComponent);
        TDest Translate(GpuComponent gpuComponent);
        TDest Translate(StorageComponent storageComponent);
        TDest Translate(NetworkComponent networkComponent);
        TDest Translate(DriveComponent driveComponent);
    }


    public interface ISensorTranslator<TDest>
    {
        TDest Translate(TemperatureSensor sensor);
        TDest Translate(ClockSensor clockSensor);
        TDest Translate(LoadSensor loadSensor);
        TDest Translate(PowerSensor powerSensor);
        TDest Translate(DataSensor dataSensor);
        TDest Translate(ThroughputSensor throughputSensor);
    }
}