namespace SistemaDeBilheteira.Services.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
