using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace MetaMask.Models
{

    public class MetaMaskOptions
    {

        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("symbol")]
        [JsonPropertyName("symbol")]
        public object Symbol { get; set; }

        [JsonProperty("decimals")]
        [JsonPropertyName("decimals")]
        public object Decimals { get; set; }

        [JsonProperty("image")]
        [JsonPropertyName("image")]
        public object Image { get; set; }

    }
}
