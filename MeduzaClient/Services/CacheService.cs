using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeduzaClient.Services.Interfaces;
using MeduzaClient.Services.Database;
using System.Linq;
using MeduzaClient.Database;
using MeduzaClient.Models.Entity;

namespace MeduzaClient.Services
{
    public class CacheService : ICacheService
    {
        DataContext _ctx;
        IUnitOfWork _unitOfWork;
        IDbManager _dbManager;
        public CacheService(DataContext ctx, IUnitOfWork unitOfWork, IDbManager dbManager)
        {
            _ctx = ctx;
            _unitOfWork = unitOfWork;
            _dbManager = dbManager;
            _dbManager.CreateDatabase();
        }

        
        public Task<IEnumerable<T>> GetDataAsync<T>() where T : DbEntityBase
        {
            var _repository = new Repository<T>(_ctx);
            return Task.FromResult(_repository.GetAll().AsEnumerable());
        }

        public Task RemoveData<T>() where T : DbEntityBase
        {
            var _repository = new Repository<T>(_ctx);
            _repository.Clear();
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public async Task SaveDataAsync<T>(IEnumerable<T> data) where T : DbEntityBase
        {
            var _repository = new Repository<T>(_ctx);
            _repository.Clear();
            _unitOfWork.Save();
            await _repository.AddRange(data);
            _unitOfWork.Save();
        }
    }
}
