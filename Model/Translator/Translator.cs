namespace HardwareMonitor.Model.Translator
{
    public interface IComponentTranslator<TDest>
    {
        TDest Translate(CpuComponent component);
    }


    public interface ISensorTranslator<TDest>
    {
        TDest Translate(TemperatureSensor sensor);
        TDest Translate(ClockSensor clockSensor);
    }
}