using System.ComponentModel.DataAnnotations;

namespace BibliotecaIdentitty.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }
    }
}
