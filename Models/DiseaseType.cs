using System.ComponentModel;

namespace disease_tracker_api.Models
{
    public enum DiseaseType
    {
        [Description("Non-Communicable")]
        NonCommunicable = 1,
        [Description("Communicable")]
        Communicable = 2,
    }
}