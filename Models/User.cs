using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int MyProperty { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Organization> Organizations {get; set;}
    }
}