using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MeduzaClient.Models;
using MeduzaClient.Models.Page;
using MeduzaClient.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MeduzaClient.Services
{
    public class ApiService : IApiService
    {
        private Main _main;

        private readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        });

        private ISettingsService _settongsService;
        public ApiService(ISettingsService settings)
        {
            _settongsService = settings;
        }

        public async Task<Main> GetAllAsync()
        {
            var content = await _httpClient.GetStringAsync(_settongsService.Url);
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            return JsonConvert.DeserializeObject<Main>(content, settings);
        }

        public async Task<object> SearchAsync()
        {
            var content = await _httpClient.GetStringAsync(_settongsService.Url);
            return content;
        }
    }
}
