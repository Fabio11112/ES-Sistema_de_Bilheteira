using Newtonsoft.Json;
using SistemaDeBilheteira.Models.Movies;

namespace SistemaDeBilheteira.Services.API_Deserializer;

public interface IResponse<T>
{
    [JsonProperty("genres")]
    public List<Genre> Genres { get; set; }
    
    
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