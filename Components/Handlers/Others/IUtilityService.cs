using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Configuration;

namespace disease_tracker_api.Components.Handlers.Others
{
    public interface IUtilityService
    {
        // AppSettings GetAppSettings();
        dynamic FormatObjectResult(int code, dynamic message = null, object data = null);
    }
}