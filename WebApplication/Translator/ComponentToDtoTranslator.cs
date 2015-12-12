using HardwareMonitor.Model;
using HardwareMonitor.Model.Translator;
using System.Linq;

namespace WebApplication.Translator
{
    public class ComponentToDtoTranslator : IComponentTranslator<IComponentDto>
    {
        public IComponentDto Translate(CpuComponent component)
        {
            ComponentDto dto = new ComponentDto(component);
            dto.ComponentType = ComponentType.Cpu.ToString();

            ISensorTranslator<ISensorDto> sensorTranslator = new SensorToDtoTranslator();
            dto.Sensors = component.Sensors.Select(s => s.TranslateWith(sensorTranslator));

            return dto;
        }
    }
}