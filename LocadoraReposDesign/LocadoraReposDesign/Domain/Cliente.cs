using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Id}] {Nome} - CPF: {Cpf}";
        }
    }
}
