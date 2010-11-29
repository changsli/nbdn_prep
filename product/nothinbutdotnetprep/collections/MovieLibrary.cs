using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        public class StudioRank
        {
            public int rank;
            public ProductionStudio studio;
        }

        IList<Movie> movies;

        private IList<StudioRank> studioRank = new List<StudioRank>
                                                   {
                                                       new StudioRank() {rank = 1, studio = ProductionStudio.MGM},
                                                       new StudioRank() {rank = 2, studio = ProductionStudio.Pixar},
                                                       new StudioRank() {rank = 3, studio = ProductionStudio.Dreamworks},
                                                       new StudioRank() {rank = 4, studio = ProductionStudio.Universal},
                                                       new StudioRank() {rank = 5, studio = ProductionStudio.Disney}
                                                   };
        
        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
            bool movieExists = false;
            if (!movies.Contains(movie))
            {
                foreach (Movie movie1 in movies)
                {
                    if (movie1.title == movie.title)
                        movieExists = true;
                }
                if (!movieExists)
                    movies.Add(movie);                
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                List<Movie> movieList = new List<Movie>(movies);
                movieList.Sort(delegate(Movie m1, Movie m2)
                                   {
                                       return m2.title.CompareTo(m1.title);
                                   });
                return movieList;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                List<Movie> movieList = new List<Movie>(movies);
                movieList.Sort(delegate(Movie m1, Movie m2) {
                                       return m1.title.CompareTo(m2.title);
                                   });
                return movieList;

            }
        }
        
        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> movieList = new List<Movie>(movies);
            movieList.Sort(delegate (Movie m1, Movie m2)
                               {

                                   return m1.production_studio.ToString().CompareTo(m2.production_studio.ToString());
                               });
            movieList.Sort(delegate (Movie m1, Movie m2)
                               {
                                   return m1.date_published.Year.CompareTo(m2.date_published.Year);
                               });
            return movieList;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year > year)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.kids)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.action)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> movieList = new List<Movie>(movies);
            movieList.Sort(delegate(Movie m1, Movie m2) {
                                   return m2.date_published.CompareTo(m1.date_published);
                               });
            return movieList;
            ;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> movieList = new List<Movie>(movies);
            movieList.Sort(delegate(Movie m1, Movie m2) {
                                   return m1.date_published.CompareTo(m2.date_published);
                               });
            return movieList;

        }
    }
}