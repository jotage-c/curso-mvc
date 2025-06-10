using System.ComponentModel.DataAnnotations;

namespace SisControl.Models
{
    public class Games
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1990,2025)]
        public int LaunchingYear { get; set; }
        [Range(0, 10)]
        public double Rating { get; set; }
    }
}
