using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseDTO;

namespace MovieDatabaseRepository
{
    public class MovieMoviesRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;

        public MovieMoviesRepository()
        {
            BuildOptions();
        }

        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieDatabase"));
        }

        public bool AddMovie(Movie movieToAdd)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                Movie existingMovie = db.Movies.FirstOrDefault(x => x.Title.ToLower() == movieToAdd.Title.ToLower());

                if (existingMovie == null)
                {
                    db.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Movie> GettAllMovies()
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.ToList();
            }
        }

        public Movie GetMovieByGenre(string movieGenre)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.FirstOrDefault(x => x.Genre == movieGenre);
            }
        }

        public Movie GetMovieByTitle(string movieTitle)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.FirstOrDefault(x => x.Title == movieTitle);
            }
        }

        public List<Movie> SearchByGenre(string movieGenre)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Genre == movieGenre).ToList();
            }
        }
        public List<Movie> SearchByTitle(string movieTitle)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Title == movieTitle).ToList();
            }
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                db.Movies.Update(movieToUpdate);
                db.SaveChanges();
            }
        }

        public void DeleteMovie(Movie movieToDelete)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                db.Movies.Remove(movieToDelete);
                db.SaveChanges();
            }
        }
    }
}
