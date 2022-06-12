using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Configuration;

namespace disease_tracker_api.Components.Handlers.Others
{
    public class UtilityService : IUtilityService
    {
        // private readonly AppSettings _appSettings;

        public dynamic FormatObjectResult(int code, dynamic message = null, object data = null)
        {
            dynamic[] messages = { null };
            IDictionary<string, object> result = new ExpandoObject();
            result.Add("status", code);
            var title = "";
            switch (code)
            {
                case 400:
                    title = "One or more validation errors detected.";
                    messages[0] = message;
                    break;
                case 404:
                    title = "Record does not exist.";
                    message += " does not exist.";
                    break;
                case 409:
                    title = "Record already exists.";
                    break;
            }
            if (!string.IsNullOrEmpty(title)) result.Add("title", title);
            if (messages[0] != null) result.Add("message", messages);
            else result.Add("message", message);
            if (data != null) result.Add("data", data);

            // _log.AddAsync(new Log
            // {
            //     Message = message,
            //     Code = code
            // });
            return result;
        }

        // public AppSettings GetAppSettings() => _appSettings;
    }
}