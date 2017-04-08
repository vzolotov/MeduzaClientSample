using System;
using MeduzaClient.Services.Interfaces;
using Windows.Storage;

namespace MeduzaClient.Services
{
    internal class SettingsService: ISettingsService
    {
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public Uri Url => new Uri("https://meduza.io/api/v3/index", UriKind.Absolute);
        public string BaseUrl  => "https://meduza.io/";
        public string SearchUrl => "https://meduza.io/api/v3/search?chrono={0}&page={1}&per_page={2}&locale={3}";
    }
}
