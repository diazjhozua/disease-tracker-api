using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Models;

namespace disease_tracker_api.Dtos.Request
{

    public abstract class DiseaseInputBaseDTO 
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Disease Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        [Required]
        [EnumDataType(typeof(DiseaseType))]
        [Display(Name = "Disease Type")]
        public DiseaseType Type { get; set; }

    }
    public partial class DiseaseCreateDTO : DiseaseInputBaseDTO
    {
        public DiseaseCreateDTO()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

        public DateTime DateCreated { get; set; } 
        public DateTime DateModified { get; set; }
        
    }

    public partial class DiseaseUpdateDTO : DiseaseInputBaseDTO
    {
        public DiseaseUpdateDTO()
        {
            DateModified = DateTime.Now;
        }

        public DateTime DateModified { get; set; }
        
    }
}