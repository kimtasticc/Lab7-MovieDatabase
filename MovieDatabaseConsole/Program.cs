using MovieDatabaseDomain;
using MovieDatabaseDTO;

MovieMoviesInteractor _movieMoviesInteractor = new MovieMoviesInteractor();

//LoadStartUpData();

Console.WriteLine("Welcome to the Movie Database!\nDo you want to search by genre or by title?");
string userInput = Console.ReadLine().ToLower();

if (userInput == "genre")
{
    Console.WriteLine("Which genre are you searching for?");
    string movieGenre = Console.ReadLine().ToLower();
    
    SearchByGenre(movieGenre);
}
else if (userInput == "title")
{
    Console.WriteLine("Which title are you searching for?");
    string movieTitle = Console.ReadLine().ToLower();

    SearchByTitle(movieTitle);
}

Console.WriteLine("\nPress any key to exit.");
Console.ReadKey();

void LoadStartUpData()
{
    foreach (Movie movie in BuildMovieCollection())
    {
        if (_movieMoviesInteractor.AddNewMovie(movie) == true)
        {
            Console.WriteLine($"{movie.Title} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{movie.Title} was NOT added to the database.");
        }
    }
}

List<Movie> BuildMovieCollection()
{
    List<Movie> initialMovies = new List<Movie>();
    initialMovies.Add(new Movie() { Title = "Glass Onion: A Knives Out Mystery", Genre = "Mystery", Runtime = 139 });
    initialMovies.Add(new Movie() { Title = "The Menu", Genre = "Thriller", Runtime = 107 });
    initialMovies.Add(new Movie() { Title = "Wendell & Wild", Genre = "Animation", Runtime = 107 });
    initialMovies.Add(new Movie() { Title = "Underworld", Genre = "Fantasy", Runtime = 122 });
    initialMovies.Add(new Movie() { Title = "Interview with the Vampire", Genre = "Drama", Runtime = 123 });
    initialMovies.Add(new Movie() { Title = "Emma.", Genre = "Romance", Runtime = 125 });
    initialMovies.Add(new Movie() { Title = "Barbarian", Genre = "Horror", Runtime = 103 });
    initialMovies.Add(new Movie() { Title = "Always Be My Maybe", Genre = "Romance", Runtime = 102 });
    initialMovies.Add(new Movie() { Title = "Full Metal Jacket", Genre = "Drama", Runtime = 117 });
    initialMovies.Add(new Movie() { Title = "Prey", Genre = "Thriller", Runtime = 100 });
    initialMovies.Add(new Movie() { Title = "Evil Dead II", Genre = "Horror", Runtime = 84 });
    initialMovies.Add(new Movie() { Title = "Nope", Genre = "Mystery", Runtime = 130 });
    initialMovies.Add(new Movie() { Title = "The Worst Person In The World", Genre = "Comedy", Runtime = 128 });
    initialMovies.Add(new Movie() { Title = "Paddington 2", Genre = "Family", Runtime = 104 });
    initialMovies.Add(new Movie() { Title = "Millenium Actress", Genre = "Animation", Runtime = 87 });
    return initialMovies;
}

void SearchByGenre(string movieGenre)
{
    Console.WriteLine($"\nGENRE SELECTED: {movieGenre}");
    bool doesMovieExist = _movieMoviesInteractor.GetMovieGenre(movieGenre, out Movie movieToReturn);
    if (doesMovieExist)
    {
        foreach (Movie movie in _movieMoviesInteractor.SearchByGenre(movieGenre))
        {
            if (movie.Runtime != null)
            {
                Console.WriteLine($" - {movie.Title} | {movie.Genre} | {movie.Runtime} minute runtime");
            }
            else
            {
                Console.WriteLine($" - {movie.Title} | {movie.Genre}");
            }
        }  
    }
    else
    {
        Console.WriteLine("That movie genre is not in our database.");
    }
}

void SearchByTitle(string movieTitle)
{
    Console.WriteLine($"\nTitle SELECTED: {movieTitle}");
    bool doesMovieExist = _movieMoviesInteractor.GetMovieTitle(movieTitle, out Movie movieToReturn);
    if (doesMovieExist)
    {
        foreach (Movie movie in _movieMoviesInteractor.SearchByTitle(movieTitle))
        {
            if (movie.Runtime != null)
            {
                Console.WriteLine($" - {movie.Title} | {movie.Genre} | {movie.Runtime} minute runtime");
            }
            else
            {
                Console.WriteLine($" - {movie.Title} | {movie.Genre}");
            }
        }
    }
    else
    {
        Console.WriteLine("That movie title is not in our database.");
    }
}

//

void DisplayAllMovies()
{
    Console.WriteLine("\nThe following movies are in the database:\n");
    foreach (Movie movie in _movieMoviesInteractor.GettAllMovies())
    {
        if (movie.Runtime != null)
        {
            Console.WriteLine($" - {movie.Title} | {movie.Genre} | {movie.Runtime} minute runtime");
        }
        else
        {
            Console.WriteLine($" - {movie.Title} | {movie.Genre}");
        }
    }
}