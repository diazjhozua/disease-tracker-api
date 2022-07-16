using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Configuration
{
    // public class AppSettings
    // {
        
    // }

    public sealed class ErrorMessage
    {
        private ErrorMessage(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }

    public sealed class Entities
    {
        public const string Disease = "Disease";
        
        public const string Organization = "Organization";
    }
}