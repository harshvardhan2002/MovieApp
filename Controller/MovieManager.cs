using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLayered.Models;
using MovieAppLayered.Services;

namespace MovieAppLayered.Controller
{
    internal class MovieManager
    {
        private static Movie[] movies = new Movie[5];

        public MovieManager() {
            movies = MovieSerializer.Deserialize();
        }
        public void CreateMovie(int movieId, string movieName, string movieGenre, int movieYear)
        {
            var movie = new Movie(movieId, movieName, movieGenre, movieYear);
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i] == null)
                {
                    movies[i] = movie;
                    break;
                }
            }
        }

        public Movie GetMovieById(int movieId)
        {
            return movies.Where(m => m != null && m.MovieId == movieId).FirstOrDefault();
        }

        public Movie[] GetAllMovies()
        {
            return movies;
        }

        public void ClearMovieById(int movieId)
        {
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i] != null && movies[i].MovieId == movieId)
                {
                    movies[i] = null;
                    Console.WriteLine($"Movie with Id {movieId} cleared.");
                    return;
                }
            }
            Console.WriteLine($"Movie with Id {movieId} not found.");
        }

        public void SerializeMoviesBeforeExit()
        {
            MovieSerializer.Serialize(movies);
        }
    }
}
