using System.Threading.Tasks;

namespace MeduzaClient.Services.Interfaces
{
    public interface IOpenLinkService
    {
        Task OpenLinkAsync(string urlPath);
    }
}
