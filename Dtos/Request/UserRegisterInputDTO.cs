using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Dtos.Request
{
    public class UserRegisterInputDTO
    {
        [Required]
        [StringLength(100)]
        [Components.Validators.EmailAddressAttribute]
        public string Email { get; set; }
        [StringLength(30)]
        public string Password { get; set; }
    }
}