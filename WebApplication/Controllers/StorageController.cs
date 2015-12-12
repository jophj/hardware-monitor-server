using System.Collections.Generic;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class StorageController : AbstractApiController
    {
        public StorageController()
        {
            _monitor = DataConfiguration.StorageMonitor;
            _translator = DataConfiguration.ComponentTranslator;
        }

    }
}
