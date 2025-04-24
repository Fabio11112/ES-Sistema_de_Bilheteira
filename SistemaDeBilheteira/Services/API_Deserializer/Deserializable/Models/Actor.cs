using Newtonsoft.Json;

namespace SistemaDeBilheteira.Services.Movies;

public class Actor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("character")]
    public string Character { get; set; }

    [JsonProperty("profile_path")]
    public string ProfilePath { get; set; }
}