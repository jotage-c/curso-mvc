using LocadoraReposDesign.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Repositories
{
    public class VeiculoRepository : InMemoryRepository<Veiculo>
    {
        public List<Veiculo> ListarDisponiveis()
        {
            return GetAll().Where(v => v.Disponivel).ToList();
        }
    }
}
