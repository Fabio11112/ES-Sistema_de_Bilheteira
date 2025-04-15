using RestSharp;

namespace SistemaDeBilheteira.Services.Movies;
using SistemaDeBilheteira.Services.Enviroment;

using Newtonsoft.Json;

public class MovieDeserializer
{
    private HttpClient Client { get; } = new HttpClient();
    
    public async Task<MovieResponse?> FetchPopularMovies()
    {
        var options = new RestClientOptions($"{Enviroment.MoviesLink}/popular");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {Enviroment.TmdbApiKey}");
        Console.WriteLine(Enviroment.TmdbApiKey);
        var response = await client.GetAsync(request);

        
        var jsonString = response.Content;
        return jsonString != null ? JsonConvert.DeserializeObject<MovieResponse>(jsonString) : null;
    }

    // public Movie? FetchMovie(int id)
    // {
    //     using var client = new HttpClient();
    //     var endpoint = new Uri();
    // }
}
