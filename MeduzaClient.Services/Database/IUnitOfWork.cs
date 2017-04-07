using MeduzaClient.Models;
using MeduzaClient.Models.Entity;
using System;

namespace MeduzaClient.Services.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DocumentEntity> DocsRepository { get; }
        void Save();
    }
}
