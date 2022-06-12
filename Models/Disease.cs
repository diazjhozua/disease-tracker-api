using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Models
{
    public class Disease : BaseEntity
    {
        public Disease()
        {
            DateCreated = DateTime.Now;
        }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        public DiseaseType Type { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime? DateModified { get; set; }
        #nullable enable
        public string? ArchiveReason { get; set; } = null;
        public bool IsArchived { get; set; } = false;
    }
} 