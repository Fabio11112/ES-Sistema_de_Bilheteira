using RestSharp;

namespace SistemaDeBilheteira.Services.Movies;
using SistemaDeBilheteira.Services.Enviroment;

using Newtonsoft.Json;

public class MovieDeserializer
{
    
    public async Task<MovieResponse?> FetchPopularMovies()
    {
        var response = await GetResponse($"{Environment.GetEnvironmentVariable("MOVIES_LINK")}/popular");
        if (response == null || string.IsNullOrEmpty(response.Content))
            return null;
        return DeserializeMovieResponse(response.Content);
    }

    public async Task<Movie?> FetchMovie(int id)
    {
        var response = await GetResponse($"{Environment.GetEnvironmentVariable("MOVIES_LINK")}/{id}");
        if (response == null || string.IsNullOrEmpty(response.Content))
            return null;
        return DeserializeMovie(response.Content);
    }

    private async Task<RestResponse?> GetResponse(string url)
    {
        var options = new RestClientOptions(url);
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {Enviroment.TmdbApiKey}");
        return await client.GetAsync(request);
    }

    private MovieResponse? DeserializeMovieResponse(string? jsonString)
    {
        return jsonString != null ? JsonConvert.DeserializeObject<MovieResponse>(jsonString) : null;
    }
    
    private Movie? DeserializeMovie(string? jsonString)
    {
        return jsonString != null ? JsonConvert.DeserializeObject<Movie>(jsonString) : null;
    }

}
