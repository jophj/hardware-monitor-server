namespace HttpServer.Module
{
    public class CpuModule : ApiModule
    {
        public CpuModule() : base(Bootstrapper.CpuMonitor, Bootstrapper.ComponentTranslator)
        {
            Get["/api/cpu"] = _ => GetResponse();
        }
    }
}