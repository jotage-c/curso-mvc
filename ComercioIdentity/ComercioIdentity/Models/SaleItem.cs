using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercioIdentity.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }

        // Relacionamento com Produto
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        // Relacionamento com Venda
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        // Propriedade calculada (não mapeada no banco)
        [NotMapped]
        public decimal Total => Quantity * UnitPrice;
    }
}
