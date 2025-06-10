using System.ComponentModel.DataAnnotations;

namespace SisControl.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Barcode { get; set; }
    }
}
