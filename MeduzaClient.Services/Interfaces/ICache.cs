using MeduzaClient.Models.Entity;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeduzaClient.Services.Interfaces
{
    public interface ICacheService
    {
        Task SaveDataAsync<T>(IEnumerable<T> data) where T : DbEntityBase;
        Task RemoveData<T>() where T : DbEntityBase;
        Task<IEnumerable<T>> GetDataAsync<T>() where T : DbEntityBase;
    }
}
