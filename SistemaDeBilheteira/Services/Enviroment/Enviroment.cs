namespace SistemaDeBilheteira.Services.Enviroment;

public class Enviroment
{
    public static string? TmdbApiKey { get; } = Environment.GetEnvironmentVariable("TMDB_API_KEY");
    public static string? BackdropLink { get; } = Environment.GetEnvironmentVariable("BACKDROP_LINK");
    public static string? MoviesLink { get; } = Environment.GetEnvironmentVariable("MOVIES_LINK");
}