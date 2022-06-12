using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Dtos.Request
{
    public class ArchiveInputDTO
    {
        [Display(Name = "Archive Reason")]
        [StringLength(1000)]
        public string ArchiveReason { get; set; }
        public bool IsArchived { get; set; }        
    }
}