using System.Threading.Tasks;
using MeduzaClient.Models.Page;

namespace MeduzaClient.Services.Interfaces
{
    public interface IApiService
    {
        Task<Main> GetAllAsync();
        Task<object> SearchAsync();
    }
}