using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraReposDesign.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _items = new();
        private int _nextId = 1;

        public void Add(T item)
        {
            var prop = item!.GetType().GetProperty("Id");
            if (prop != null)
            {
                prop.SetValue(item, _nextId++);
            }
            _items.Add(item);
        }

        public List<T> GetAll() => _items;

        public T? GetById(int id)
        {
            var prop = typeof(T).GetProperty("Id");
            return _items.FirstOrDefault(x =>
                (int?)typeof(T).GetProperty("Id")?.GetValue(x)! == id);
        }

        public void Update(T item)
        {
            var id = (int?)typeof(T).GetProperty("Id")?.GetValue(item)!;
            var index = _items.FindIndex(x =>
                (int?)typeof(T).GetProperty("Id").GetValue(x)! == id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
                _items.Remove(item);
        }
    }
}
