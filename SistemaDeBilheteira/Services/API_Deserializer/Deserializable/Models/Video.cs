using Newtonsoft.Json;

namespace SistemaDeBilheteira.Services.API_Deserializer.Deserializable.Models;

public class Video
{
    [JsonProperty("key")]
    public string? Key { get; set; }

    [JsonProperty("site")]
    public string? Site { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }
}