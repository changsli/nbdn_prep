using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public class StudioRank
        {
            public int rank;
            public ProductionStudio studio;
        }

        IList<StudioRank> studio_rank = new List<StudioRank>
        {
            new StudioRank {rank = 1, studio = ProductionStudio.MGM},
            new StudioRank {rank = 2, studio = ProductionStudio.Pixar},
            new StudioRank {rank = 3, studio = ProductionStudio.Dreamworks},
            new StudioRank {rank = 4, studio = ProductionStudio.Universal},
            new StudioRank {rank = 5, studio = ProductionStudio.Disney}
        };

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public
            IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_matching(Movie.is_published_by(ProductionStudio.Pixar).matches);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies_matching(is_published_between(startingYear, endingYear));
        }

        IEnumerable<Movie> all_movies_matching(Predicate<Movie> condition) 
        {
            return movies.all_items_matching(condition.as_criteria());
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return movies.all_items_matching(Movie.is_published_by_pixar_or_disney());
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_matching(x => x.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_matching(x => x.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_matching(movie => movie.genre == Genre.action);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_matching(movie => movie.genre == Genre.kids);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var movieList = new List<Movie>(movies);
                movieList.Sort(delegate(Movie m1, Movie m2) { return m1.title.CompareTo(m2.title); });
                return movieList;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var movieList = new List<Movie>(movies);
            movieList.Sort(
                delegate(Movie m1, Movie m2) { return m1.production_studio.ToString().CompareTo(m2.production_studio.ToString()); })
                ;
            movieList.Sort(
                delegate(Movie m1, Movie m2) { return m1.date_published.Year.CompareTo(m2.date_published.Year); });
            return movieList;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var movieList = new List<Movie>(movies);
                movieList.Sort(delegate(Movie m1, Movie m2) { return m2.title.CompareTo(m1.title); });
                return movieList;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var movieList = new List<Movie>(movies);
            movieList.Sort(delegate(Movie m1, Movie m2) { return m2.date_published.CompareTo(m1.date_published); });
            return movieList;
            ;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var movieList = new List<Movie>(movies);
            movieList.Sort(delegate(Movie m1, Movie m2) { return m1.date_published.CompareTo(m2.date_published); });
            return movieList;
        }

        Predicate<Movie> is_published_between(int starting_year, int ending_year)
        {
            return movie => movie.date_published.Year >= starting_year && 
                movie.date_published.Year <= ending_year;
        }

    }
}