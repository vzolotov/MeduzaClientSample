using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeduzaClient.Services.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        Task Create(T item);
        Task AddRange(IEnumerable<T> items);
        Task Update(T item);
        Task Delete(T item);
    }
}
