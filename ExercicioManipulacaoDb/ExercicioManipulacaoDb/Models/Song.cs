using System.ComponentModel.DataAnnotations;

namespace ExercicioManipulacaoDb.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [MaxLength(20)]
        [Required]
        public string Genre { get; set; }
    }
}
