using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace MetaMask.Models
{

    public class MetaMaskParameters
    {

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("options")]
        [JsonPropertyName("options")]
        public object Options { get; set; }

    }
}
