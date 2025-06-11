using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    //Code first - da classe eu crio a estrutura do db
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name= "Category Name")]
        public string? Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "State a number between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
