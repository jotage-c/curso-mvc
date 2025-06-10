using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameProduct { get; set; }
        [Range(1, 30)]
        [Required]
        public int Quantity { get; set; }

    }
}
