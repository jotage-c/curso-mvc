using System.ComponentModel.DataAnnotations;

namespace SisReservaRestaurante.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Lugares { get; set; }


        public ICollection<Reserva> Reservas { get; set; }
    }
}
