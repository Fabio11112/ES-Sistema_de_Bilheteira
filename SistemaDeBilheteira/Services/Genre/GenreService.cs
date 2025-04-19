using Newtonsoft.Json;
using System.Net;

public class GenreService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public GenreService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _apiKey = configuration["TmdbApiKey"]; // Get API key from configuration
        _http.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        
        // Configure default headers if needed
        _http.DefaultRequestHeaders.Accept.Clear();
        _http.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        try
        {
            var response = await _http.GetStringAsync($"genre/movie/list?api_key={_apiKey}&language=pt-PT");
            var result = JsonConvert.DeserializeObject<GenreResponse>(response);
            return result?.Genres ?? new List<Genre>();
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            // Handle 404 specifically
            return new List<Genre>();
        }
        catch (Exception ex)
        {
            // Log error here
            Console.WriteLine($"Error fetching genres: {ex.Message}");
            return new List<Genre>();
        }
    }
}

public class GenreResponse
{
    [JsonProperty("genres")]
    public List<Genre> Genres { get; set; } = new();
}

public class Genre
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}

