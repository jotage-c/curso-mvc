using System.ComponentModel.DataAnnotations;

namespace LojaIdentity.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }
        public decimal Preco{ get; set; }
    }
}
