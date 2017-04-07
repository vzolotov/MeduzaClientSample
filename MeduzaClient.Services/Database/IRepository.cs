using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeduzaClient.Services.Database
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Create(T item);
        Task AddRange(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        void Clear();
    }
}
