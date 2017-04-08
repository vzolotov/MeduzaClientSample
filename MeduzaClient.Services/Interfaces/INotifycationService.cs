using System.Threading.Tasks;

namespace MeduzaClient.Services.Interfaces
{
    public interface INotifycationService
    {
        /// <summary>
        /// Показ сообщения пользователю
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <returns></returns>
        Task ShowMessageAsync(string message);
    }
}
