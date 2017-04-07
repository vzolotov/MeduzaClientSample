using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeduzaClient.Services.Interfaces;

namespace MeduzaClient.Services
{
    public class CacheService : ICacheService
    {
        public Task<T> GetData<T>()
        {
            throw new NotImplementedException();
        }

        public Task RemoveData<T>(T data)
        {
            throw new NotImplementedException();
        }

        public Task SaveData<T>(T data)
        {
            throw new NotImplementedException();
        }
    }
}
