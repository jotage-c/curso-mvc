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
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
