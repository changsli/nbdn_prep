using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie  : IEquatable<Movie>
    {
        int private_field;
        public string title { get; set; }

        public ProductionStudio production_studio { get; set; }

        public Genre genre { get; set; }

        public int rating { get; set; }

        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);             
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this,other) || is_equal_to_non_null_instance_of(other);
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return other.title == this.title;
        }

        public static Predicate<Movie> is_published_by_pixar_or_disney()
        {
            return movie => movie.production_studio == ProductionStudio.Pixar ||
                movie.production_studio == ProductionStudio.Disney;
        }

        public static Predicate<Movie> is_in_genre(Genre genre)
        {
            return movie => movie.genre == genre;
        }

        public static Predicate<Movie> is_not_published_by(ProductionStudio studio)
        {
            return movie => movie.production_studio != studio;
        }

        public static Predicate<Movie> is_published_by(ProductionStudio studio)
        {
            return movie => movie.production_studio == studio;
        }
    }
}