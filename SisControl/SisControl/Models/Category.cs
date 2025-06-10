using System.ComponentModel.DataAnnotations;

namespace SisControl.Models
{
    public class Category
    {

        //essas classes que usamos para db não têm que ter um nome específico
        [Key] //o que está em cima atinge a propriedade em baixo
        public int Id { get; set; } //TEM QUE TER UM ID


        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        [Range(1,100)] //não aceita valores de 1 a 100
        public int DisplayOrder { get; set; }
    }
}
