using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Components.Handlers;
using disease_tracker_api.Components.Handlers.Others;

namespace disease_tracker_api.Components
{
    public class Handler : IHandler
    {
        public IUtilityService Utility { get; }

        public Handler(
            IUtilityService utility) 
        { 
            Utility = utility;
        }
    }
}