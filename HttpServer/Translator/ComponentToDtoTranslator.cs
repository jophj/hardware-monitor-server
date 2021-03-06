﻿using HardwareMonitor.Model;
using HardwareMonitor.Model.Translator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HardwareMonitor.HttpServer.Translator
{
    public class ComponentToDtoTranslator : IComponentTranslator<IComponentDto>
    {
        private readonly Dictionary<Type, ComponentType> _componentTypes;

        public ComponentToDtoTranslator()
        {
            _componentTypes = new Dictionary<Type, ComponentType>()
            {
                { typeof(CpuComponent), ComponentType.Cpu},
                { typeof(MemoryComponent), ComponentType.Memory},
                { typeof(GpuComponent), ComponentType.Gpu},
                { typeof(StorageComponent), ComponentType.Storage},
                { typeof(NetworkComponent), ComponentType.Network},
                { typeof(DriveComponent), ComponentType.Drive}
            };
        }

        private IComponentDto DoTranslation(IComponent component)
        {
            IComponentDto dto =  new ComponentDto(component, _componentTypes[component.GetType()]);

            ISensorTranslator<ISensorDto> sensorTranslator = new SensorToDtoTranslator();
            dto.Sensors = component.Sensors.Select(s => s.TranslateWith(sensorTranslator));

            return dto;
        }

        public IComponentDto Translate(CpuComponent component)
        {
            return DoTranslation(component);
        }

        public IComponentDto Translate(MemoryComponent component)
        {
            return DoTranslation(component);
        }

        public IComponentDto Translate(GpuComponent component)
        {
            return DoTranslation(component);
        }

        public IComponentDto Translate(StorageComponent component)
        {
            return DoTranslation(component);
        }

        public IComponentDto Translate(NetworkComponent component)
        {
            return DoTranslation(component);
        }

        public IComponentDto Translate(DriveComponent component)
        {
            return DoTranslation(component);
        }
    }
}