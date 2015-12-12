using HardwareMonitor.Model.Translator;

namespace HardwareMonitor.Model
{
    public interface IComponentTranslateable
    {
        TDest TranslateWith<TDest>(IComponentTranslator<TDest> translator);
    }

    public interface ISensorTranslateable
    {
        TDest TranslateWith<TDest>(ISensorTranslator<TDest> translator);
    }
}