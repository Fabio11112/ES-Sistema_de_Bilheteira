namespace SistemaDeBilheteira.Services.Movies;

using Newtonsoft.Json;

public class MovieDeserializer
{
    public MovieResponse FetchPopularMovies(string link)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri(link + "?api_key=" + "88c2011578e30a692349e50d3119755c");
            var response = client.GetAsync(endpoint).Result;
            string jsonString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<MovieResponse>(jsonString);
        }
    }
}
