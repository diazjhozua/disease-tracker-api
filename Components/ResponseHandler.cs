using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace disease_tracker_api.Components
{
    public class ResponseHandler
    {
        private readonly RequestDelegate _next;
        public ResponseHandler(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                var response = context.Response;
                // await _logService.AddAsync(new Log
                // {
                //     Code = response.StatusCode,
                //     Message = ex.Message + " --- " + ex.StackTrace.ToString()
                // });
                response.StatusCode = 500;
                response.ContentType = "application/json";

                IDictionary<string, object> errorMessage = new ExpandoObject();
                errorMessage.Add("title", "Something went wrong.");
                errorMessage.Add("message", "Something went wrong.");
                errorMessage.Add("status", response.StatusCode);

                await response.WriteAsync(JsonSerializer.Serialize(errorMessage));
            }
        }
    }
}