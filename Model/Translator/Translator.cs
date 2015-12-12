namespace HardwareMonitor.Model.Translator
{
    public interface IComponentTranslator<TDest>
    {
        TDest Translate(CpuComponent component);
        TDest Translate(MemoryComponent memoryComponent);
    }


    public interface ISensorTranslator<TDest>
    {
        TDest Translate(TemperatureSensor sensor);
        TDest Translate(ClockSensor clockSensor);
        TDest Translate(LoadSensor loadSensor);
        TDest Translate(PowerSensor powerSensor);
    }
}