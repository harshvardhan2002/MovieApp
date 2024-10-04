using MovieAppLayered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLayered.Controller;

namespace MovieAppLayered.Presentation
{
    internal class MovieStore
    {
        static MovieManager manager;
        public static void RetrieveMoviesFromJson()
        {
            manager = new MovieManager();
            Console.WriteLine("Movies are desearilized.");
        }
        public static void DisplayMenu()
        {
            while (true)
            {

                Console.WriteLine("Welcome to Movie App\nWhat do u wish to do: \n");
                Console.WriteLine("1. Display All Movies. ");
                Console.WriteLine("2. Display Movie by Movie Id.");
                Console.WriteLine("3. Add Movies.");
                Console.WriteLine("4. Clear All Movies.");
                Console.WriteLine("5. Serialize then exit");
                
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());

                DoTasks(choice);
            }
        }
        public static void DoTasks(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayAllMovies();
                    break;
                case 2:
                    DisplayMovieById();
                    break;
                case 3:
                    CreateMovie();
                    break;
                case 4:
                    ClearMovie();
                    break;
                case 5:
                    manager.SerializeMoviesBeforeExit();
                    Environment.Exit(0);
                    break;
                case 6:

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
        public static void DisplayAllMovies()
        {
            var movies = manager.GetAllMovies();
            bool anyMovieExists = false;
            foreach (var movie in movies)
            {
                if (movie != null)
                {
                    Console.WriteLine(movie);
                    anyMovieExists = true;
                }
            }
            if (!anyMovieExists)
                Console.WriteLine("No movies found.");
        }
        public static void DisplayMovieById()
        {
            Console.WriteLine("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            var movie = manager.GetMovieById(movieId);
            if (movie != null)
            {
                Console.WriteLine(movie);
                return;
            }
            Console.WriteLine("Movie not found.");
            
        }
        public static void CreateMovie()
        {
            Console.WriteLine("Enter Movie Id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Movie Name: ");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter Movie Genre: ");
            string movieGenre = Console.ReadLine();
            Console.WriteLine("Enter Movie Year: ");
            int movieYear = Convert.ToInt32(Console.ReadLine());

            manager.CreateMovie(movieId, movieName, movieGenre, movieYear);
        }
        public static void ClearMovie()
        {
            Console.WriteLine("Enter Movie Id to clear: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            manager.ClearMovieById(movieId);
        }
    }

}
