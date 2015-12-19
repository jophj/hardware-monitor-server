namespace HttpServer.Module
{
    public class StorageModule : ApiModule
    {
        public StorageModule() : base(Bootstrapper.StorageMonitor, Bootstrapper.ComponentTranslator)
        {
            Get["/api/storage"] = _ => GetResponse();
        }
    }
}