using Newtonsoft.Json;

namespace MeduzaClient.Models.Card
{
    public sealed class BackgroundImage
    {
        [JsonProperty(PropertyName = "large_url")]
        public string LargeUri { get; set; }

        [JsonProperty(PropertyName = "small_url")]
        public string SmallUri { get; set; }

        public string Caption { get; set; }
        public string Credit { get; set; }
    }
}
