﻿using Newtonsoft.Json;

namespace SistemaDeBilheteira.Services.API_Deserializer.Deserializable.Models;

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
    public DateTime? ReleaseDate { get; set; }

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



