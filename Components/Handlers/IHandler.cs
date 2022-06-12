using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Components.Handlers.Others;

namespace disease_tracker_api.Components.Handlers
{
    public interface IHandler
    {
        IUtilityService Utility { get; }
    }
}