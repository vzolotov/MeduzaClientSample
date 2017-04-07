using MeduzaClient.Models;
using MeduzaClient.Models.Entity;
using MeduzaClient.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MeduzaClient.Database
{
    public class Repository<T> : IRepository<T> where T : DbEntityBase
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _dbSet;
        public Repository(DbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T Get(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public Task AddRange(IEnumerable<T> items)
        {
            var data = items?.ToArray();
            if (data != null)
            {
                _dbSet.AddRange(data);
            }
            return Task.FromResult(0);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public void Clear()
        {
            var data = _dbSet.Where(x => x.Id > int.MinValue);
            _dbSet.RemoveRange(data);
        }
    }
}
