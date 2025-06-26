using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisReservaRestaurante.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Mesa")]
        public int IdMesa { get; set; }
        public Mesa Mesa { get; set; }

        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public int NumeroClientes { get; set; }
        [Required]
        public List<string> NomeClientes { get; set; }
    }
}
