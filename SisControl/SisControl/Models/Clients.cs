using System.ComponentModel.DataAnnotations;

namespace SisControl.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1, 150)]
        public int Age { get; set; }

        public string Job { get; set; }
    }
}
