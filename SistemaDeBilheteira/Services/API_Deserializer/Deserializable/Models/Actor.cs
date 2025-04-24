using Newtonsoft.Json;

namespace SistemaDeBilheteira.Services.API_Deserializer.Deserializable.Models;

public class Actor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("character")]
    public string Character { get; set; }

    [JsonProperty ("profile_path")]
    public string ProfilePath { get; set; }

    
}
