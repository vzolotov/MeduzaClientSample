using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeduzaClient.Models.Page;
using MeduzaClient.Services.Interfaces;
using System.Linq;
using MeduzaClient.Models;
using MeduzaClient.Services.Helpers;
using MeduzaClient.Models.Entity;

namespace MeduzaClient.Services
{
    public class DataService : IDataService
    {
        private IApiService _apiService;
        private IConnectionService _connectionService;
        private ICacheService _cacheService;
        public DataService(
            IApiService apiService, 
            IConnectionService connectionService,
            ICacheService cacheService)
        {
            _apiService = apiService;
            _connectionService = connectionService;
            _cacheService = cacheService;
        }
        public async Task<IEnumerable<Document>> GetAllDataAsync()
        {
            IEnumerable<Document> result;
            if (_connectionService.IsConnected)
            {
                var data = await _apiService.GetAllAsync();
                result = data.Documents.Select(x => x.Value).Where(
                    x => x != null && !string.IsNullOrWhiteSpace(x.document_type)
                    && x.document_type.Equals("news", StringComparison.OrdinalIgnoreCase));

                var cache = MapperHelper.MapToEntityArray(result);

                await _cacheService.SaveDataAsync(cache);
            }
            else
            {
                var cache = await _cacheService.GetDataAsync<DocumentEntity>();
                result = MapperHelper.MapToDocArray(cache);
            }
            return result;
        }
    }
}
