namespace SistemaDeBilheteira.Services.Movies;

using Newtonsoft.Json;

public class Movie
{

    [JsonProperty("adult")]
    public bool Adult { get; set; }

    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("genre_ids")]
    public List<int> GenreIds { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; set; }

    [JsonProperty("overview")]
    public string Overview { get; set; }

    [JsonProperty("popularity")]
    public double Popularity { get; set; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; set; }

    [JsonProperty("release_date")]
    public DateTime ReleaseDate { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; } = String.Empty;

    [JsonProperty("video")]
    public bool Video { get; set; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; set; }

    [JsonProperty("Runtime")]
    public int Runtime { get; set; }  // Duración en minutos

    [JsonProperty("certification")]
    public string? certification { get; set; }  // PG-13, R, etc.

 
}

public class Actor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("character")]
    public string Character { get; set; }

    [JsonProperty("profile_path")]
    public string ProfilePath { get; set; }
}

public class MovieCredits
    {
        [JsonProperty("cast")]
        public List<Actor> Cast { get; set; } = new();
    }

public class MovieVideosResponse
{
    [JsonProperty("results")]
    public List<Video>? Results { get; set; }  
}

public class Video
{
    [JsonProperty("key")]
    public string? Key { get; set; }

    [JsonProperty("site")]
    public string? Site { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }
}