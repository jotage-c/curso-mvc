using System.ComponentModel.DataAnnotations;

namespace ComercioDigitalEx.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        public int ProductQty { get; set; }
    }
}
