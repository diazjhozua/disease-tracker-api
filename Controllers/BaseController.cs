using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Components.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace disease_tracker_api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IHandler _handler;

        public BaseController(IHandler handler) => _handler = handler;
    }
}