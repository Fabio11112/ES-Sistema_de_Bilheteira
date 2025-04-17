namespace SistemaDeBilheteira.Models.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string BackdropPath { get; set; }
        public string PosterPath { get; set; }
        public double VoteAverage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<string> Genres { get; set; } = new();
        public List<Actor> Cast { get; set; } = new();
    }

    public class Actor
    {
        public string Name { get; set; }
        public string ProfilePath { get; set; }
    }
}
