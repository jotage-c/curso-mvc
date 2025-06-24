using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Domain
{
    public class Locacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public override string ToString()
        {
            string status = DataDevolucao.HasValue ? $"Devolvido em {DataDevolucao.Value:dd/MM/yyyy}" : "Em andamento";
            return $"Locação #{Id} - Cliente {ClienteId} - Veículo {VeiculoId} - {status}";
        }
    }
}
