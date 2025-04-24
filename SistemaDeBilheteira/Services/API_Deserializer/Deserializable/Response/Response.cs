using Newtonsoft.Json;
using SistemaDeBilheteira.Services.Movies;
using Actor = SistemaDeBilheteira.Models.Movies.Actor;

namespace SistemaDeBilheteira.Services.API_Deserializer;

public class Response<T> : IResponse<T>
{
    [JsonProperty("cast")]
    public List<Actor> Cast { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("results")]
    public List<T> Results { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    [JsonProperty("total_results")]
    public int TotalResults { get; set; }
}