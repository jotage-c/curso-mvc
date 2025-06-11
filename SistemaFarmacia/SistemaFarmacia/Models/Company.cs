using System.ComponentModel.DataAnnotations;

namespace SistemaFarmacia.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string WorkHour { get; set; }
    }
}
