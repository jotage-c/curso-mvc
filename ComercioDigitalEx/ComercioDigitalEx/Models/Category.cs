using System.ComponentModel.DataAnnotations;

namespace ComercioDigitalEx.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Range(1, 100)]
        public int CategoryDisplayOrder { get; set; }
    }
}
