using System.ComponentModel.DataAnnotations;

namespace ComercioIdentity.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        // Lista de itens vendidos nesta venda
        public List<SaleItem> Items { get; set; } = new();
    }
}
