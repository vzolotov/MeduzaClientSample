using System.Collections.Generic;
using System.Threading.Tasks;
using MeduzaClient.Models;

namespace MeduzaClient.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Document>> GetAllDataAsync();
    }
}
