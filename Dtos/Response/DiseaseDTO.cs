using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using disease_tracker_api.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace disease_tracker_api.Dtos.Response
{
    public class DiseaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DiseaseType Type { get; set; } = DiseaseType.NonCommunicable;
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}