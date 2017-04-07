using MeduzaClient.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using MeduzaClient.Models;
using MeduzaClient.Models.Entity;

namespace MeduzaClient.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _ctx;

        public UnitOfWork(DataContext context)
        {
            _ctx = context;
        }

        public IRepository<DocumentEntity> DocsRepository { get; }

        public void Dispose()
        {
            try
            {
                _ctx.Database.CloseConnection();
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                _ctx.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save()
        {
            _ctx.SaveChanges(true);
        }
    }
}
