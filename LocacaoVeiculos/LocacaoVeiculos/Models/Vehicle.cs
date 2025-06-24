using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoVeiculos.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? VehicleType { get; set; }

        [Required]
        public string? VehicleModel { get; set; }

        [Required]
        public string? VehiclePlate { get; set; }

        [Required]
        public double VehiclePrice { get; set; }

        [Required]
        public bool VehicleWasRented { get; set; } = false;

        [ForeignKey("Client")]
        public int? ClientIdRented { get; set; }
        public Client? Client { get; set; }

    }
}
