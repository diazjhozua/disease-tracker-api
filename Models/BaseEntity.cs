using System.ComponentModel.DataAnnotations;

namespace disease_tracker_api.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}