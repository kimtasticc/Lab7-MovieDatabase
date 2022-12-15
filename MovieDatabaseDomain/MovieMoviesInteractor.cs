using MovieDatabaseRepository;
using MovieDatabaseDTO;

namespace MovieDatabaseDomain
{
    public class MovieMoviesInteractor
    {
        private MovieMoviesRepository _repository;

        public MovieMoviesInteractor()
        {
            _repository = new MovieMoviesRepository();
        }

        public bool AddNewMovie(Movie movieToAdd)
        {
            if (string.IsNullOrEmpty(movieToAdd.Title) || string.IsNullOrEmpty(movieToAdd.Genre))
            {
                throw new ArgumentException("Title and Genre must contain valid text.");
            }
            return _repository.AddMovie(movieToAdd);
        }

        public List<Movie> GettAllMovies()
        {
            return _repository.GettAllMovies();
        }

        public List<Movie> SearchByGenre(string movieGenre)
        {
            return _repository.SearchByGenre(movieGenre);
        }

        public List<Movie> SearchByTitle(string movieTitle)
        {
            return _repository.SearchByTitle(movieTitle);
        }

        public bool GetMovieGenre(string movieGenre, out Movie movieToReturn)
        {
            Movie movie = _repository.GetMovieByGenre(movieGenre);
            movieToReturn = movie;
            return movieToReturn != null;
        }
        public bool GetMovieTitle(string movieTitle, out Movie movieToReturn)
        {
            Movie movie = _repository.GetMovieByTitle(movieTitle);
            movieToReturn = movie;
            return movieToReturn != null;
        }
    }
}