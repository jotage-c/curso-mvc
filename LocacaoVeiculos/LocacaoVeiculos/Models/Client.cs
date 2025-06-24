using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculos.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ClientContactNum { get; set; }


        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
