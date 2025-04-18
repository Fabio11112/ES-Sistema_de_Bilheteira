// using System.Net.Http;

// public class MovieService

// {
    
//     private readonly HttpClient _httpClient;
//     private string APIlink = "https://api.themoviedb.org/3/movie/";

//     public MovieService(HttpClient httpClient)
//     {
//         _httpClient = httpClient;
//     }

//     public async Task<Movie> GetMovieById(int id)
//     {
//         var response = await _httpClient.GetFromJsonAsync<Movie>($"{APIlink}{id}?api_key=YOUR_API_KEY");
//         return response;
//     }
// }
