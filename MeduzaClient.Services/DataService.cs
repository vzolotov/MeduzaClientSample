using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeduzaClient.Models.Page;
using MeduzaClient.Services.Interfaces;
using System.Linq;
using MeduzaClient.Models;

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
                //await _cacheService.SaveData(result);
            }
            else
            {
                result = await _cacheService.GetData<IEnumerable<Document>>();
            }
            return result;
        }
    }
}
