using MeduzaClient.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.System;

namespace MeduzaClient.Services
{
    internal class OpenLinkService : IOpenLinkService
    {
        ISettingsService _settings;
        INotifycationService _notify;
        public OpenLinkService(ISettingsService settings, INotifycationService notify)
        {
            _settings = settings;
            _notify = notify;
        }
        public async Task OpenLinkAsync(string urlPath)
        {
            var path = Path.Combine(_settings.BaseUrl, urlPath);
            var uri = new Uri(path, UriKind.RelativeOrAbsolute);
            var success = await Launcher.LaunchUriAsync(uri);
            if (!success)
            {
                await _notify.ShowMessageAsync("Ошибка открытия ссылки");
            }
        }
    }
}
