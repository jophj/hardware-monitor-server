namespace HttpServer.Module
{
    public class MemoryModule : ApiModule
    {
        public MemoryModule() : base(Bootstrapper.MemoryMonitor, Bootstrapper.ComponentTranslator)
        {
            Get["/api/memory"] = _ => GetResponse();
        }
    }
}