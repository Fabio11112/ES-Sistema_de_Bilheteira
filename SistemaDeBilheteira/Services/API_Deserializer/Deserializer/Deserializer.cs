
using Newtonsoft.Json;
using RestSharp;

namespace SistemaDeBilheteira.Services.API_Deserializer;



public class Deserializer<T> : IDeserializer<T>
{
    public async Task<T?>? Fetch(string url)
    {
        // $"{Environment.GetEnvironmentVariable("MOVIES_LINK")}/{id}"
        var response = await GetResponse(url);
        if (response == null || string.IsNullOrEmpty(response.Content))
            return default;
        return JsonConvert.DeserializeObject<T>(response.Content);
    }
    
    


    
    private async Task<RestResponse?> GetResponse(string url)
    {
        var options = new RestClientOptions(url);
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {Environment.GetEnvironmentVariable("TMDB_API_KEY")}");
        return await client.GetAsync(request);
    }
    
    //
    // public async Task<Response<T>?> FetchPopularMovies()
    // {
    //     var response = await GetResponse($"{Environment.GetEnvironmentVariable("MOVIES_LINK")}/popular");
    //     if (response == null || string.IsNullOrEmpty(response.Content))
    //         return null;
    //     return DeserializeMovieResponse(response.Content);
    // }
    //
    // public Response<T>? FetchResponse(string? jsonString)
    // {
    //     if (string.IsNullOrEmpty(jsonString))
    //         return null;
    //
    //     return JsonConvert.DeserializeObject<Response<T> >(jsonString);
    //     
    // }
    
    // private T? Deserialize(string? jsonString)
    // {
    //     if (string.IsNullOrEmpty(jsonString))
    //         return default;
    //
    //     return JsonConvert.DeserializeObject<T>(jsonString);
    //     
    // }

}