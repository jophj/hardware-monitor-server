namespace HttpServer.Module
{
    public class NetworkModule : ApiModule
    {
        public NetworkModule() : base(Bootstrapper.NetworkMonitor, Bootstrapper.ComponentTranslator)
        {
            Get["/api/network"] = _ => GetResponse();
        }
    }

    public class MemoryModule : ApiModule
    {
        public MemoryModule() : base(Bootstrapper.MemoryMonitor, Bootstrapper.ComponentTranslator)
        {
            Get["/api/memory"] = _ => GetResponse();
        }
    }
}