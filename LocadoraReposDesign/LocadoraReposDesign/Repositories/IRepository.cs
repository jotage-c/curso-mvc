using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
        T? GetById(int id);
        void Update(T item);
        void Delete(int id);
    }
}
