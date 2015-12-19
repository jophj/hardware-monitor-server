namespace HttpServer.Module
{
    public class GpuModule : ApiModule
    {
        public GpuModule() : base(Bootstrapper.GpuMonitor, Bootstrapper.ComponentTranslator)
        {
            Get["/api/gpu"] = _ => GetResponse();
        }
    }
}