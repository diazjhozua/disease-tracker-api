using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Models
{
    public class Organization : BaseEntity
    {
        public Organization()
        {
            DateCreated = DateTime.Now;
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Region { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Province { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(1000)]
        #nullable enable
        public string? ArchiveReason { get; set; }

        public bool IsArchived { get; set; } = false;

    }
}