using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Domain
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool Disponivel { get; set; } = true;

        public override string ToString()
        {
            string status = Disponivel ? "Disponível" : "Alugado";
            return $"[{Id}] {Marca} {Modelo} - {status}";
        }
    }
}
