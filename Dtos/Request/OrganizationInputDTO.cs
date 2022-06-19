using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using disease_tracker_api.Components.Validators;

namespace disease_tracker_api.Dtos.Request
{
    public class OrganizationInputDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Components.Validators.EmailAddressAttribute]
        public string Email { get; set; }

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "The {0} field is not a valid phone number.")]
        [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Region { get; set; }

        // [Required]
        [StringLength(100)]
        public string Country { get; set; }

        // [Required]
        [StringLength(100)]
        public string City { get; set; }

        // [Required]
        [StringLength(100)]
        public string Province { get; set; }
        
        // [RequiredInt]
        [RegularExpression("([0-9]+)", ErrorMessage = "The {0} field is not a valid zip code.")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        
        // [Required]
        [StringLength(1000)]
        public string Address { get; set; }
    }
}