using Newtonsoft.Json;
using SistemaDeBilheteira.Services.Movies;

namespace SistemaDeBilheteira.Services.API_Deserializer;

public class MovieResponse
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("results")]
    public List<Movie> Results { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    [JsonProperty("total_results")]
    public int TotalResults { get; set; }
}