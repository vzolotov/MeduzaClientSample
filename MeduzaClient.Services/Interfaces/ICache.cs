using System.Text;
using System.Threading.Tasks;

namespace MeduzaClient.Services.Interfaces
{
    public interface ICacheService
    {
        Task SaveData<T>(T data);
        Task RemoveData<T>(T data);
        Task<T> GetData<T>();
    }
}
