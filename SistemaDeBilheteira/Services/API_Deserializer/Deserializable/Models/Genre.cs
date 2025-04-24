using Newtonsoft.Json;

namespace SistemaDeBilheteira.Services.Movies;

public class Genre
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}