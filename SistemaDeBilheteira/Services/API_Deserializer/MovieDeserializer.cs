using Newtonsoft.Json;
using RestSharp;
using SistemaDeBilheteira.Services.Movies;
using Actor = SistemaDeBilheteira.Services.Movies.Actor;
using Movie = SistemaDeBilheteira.Services.Movies.Movie;

namespace SistemaDeBilheteira.Services.API_Deserializer;

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
        request.AddHeader("Authorization", $"Bearer {Enviroment.Enviroment.TmdbApiKey}");
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

    public static async Task<MovieResponse?> GetPopularMoviesAsync()
    {
        string apiUrl = "https://api.themoviedb.org/3/movie/popular?language=en-US&page=1";
        var options = new RestClientOptions(apiUrl);
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxYTcwMTUzMjMwYTg1MTdjNDJmNjIwYzdiYzNiZWYwMCIsIm5iZiI6MTc0MzAwNzIyNi4wMDQ5OTk5LCJzdWIiOiI2N2U0MmRmOWVjOThiZjBhMGQ3NjFkYWYiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.PbOoXIOv1DhHXPun6PnxgwfgjEbx4Bg5ilWjh7ABw_s");

        var response = await client.GetAsync(request);

        if (response.IsSuccessful && response.Content != null)
        {
            return JsonConvert.DeserializeObject<MovieResponse>(response.Content);
        }

        return null;
    }

    public async Task<List<Actor>?> FetchMovieActors(int movieId)
    {
        var response = await GetResponse($"{Environment.GetEnvironmentVariable("MOVIES_LINK")}/{movieId}/credits");
        
        if (response == null || string.IsNullOrEmpty(response.Content))
            return null;

        var credits = JsonConvert.DeserializeObject<MovieCredits>(response.Content);
        return credits?.Cast;
    }

public async Task<string?> FetchMovieTrailerKey(int movieId)
    {
        var client = new RestClient($"https://api.themoviedb.org/3/movie/{movieId}/videos");
        var request = new RestRequest();
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxYTcwMTUzMjMwYTg1MTdjNDJmNjIwYzdiYzNiZWYwMCIsIm5iZiI6MTc0MzAwNzIyNi4wMDQ5OTk5LCJzdWIiOiI2N2U0MmRmOWVjOThiZjBhMGQ3NjFkYWYiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.PbOoXIOv1DhHXPun6PnxgwfgjEbx4Bg5ilWjh7ABw_s");

        var response = await client.GetAsync(request);

        if (response != null && response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
        {
            var videos = JsonConvert.DeserializeObject<MovieVideosResponse>(response.Content);
            var trailer = videos?.Results?.FirstOrDefault(v =>
                v.Type == "Trailer" &&
                v.Site == "YouTube" &&
                !string.IsNullOrEmpty(v.Key));

            return trailer?.Key;
        }

        return null;
    }

    



}


