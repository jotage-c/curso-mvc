using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExercicioManipulacaoDb.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DisplayName("Launching Year")]
        public string? LaunchingYear { get; set; }
    }
}
