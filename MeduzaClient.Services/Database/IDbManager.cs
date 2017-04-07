using System.Threading.Tasks;

namespace MeduzaClient.Services.Database
{
    public interface IDbManager
    {
        Task DeleteDatabase();
        Task CreateDatabase();
        bool IsDbCreated { get; set; }
    }
}
