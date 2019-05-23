using Common.MTO;
using DAL.Entities;

namespace DAL.Converters
{
    public class MovieDetailConverter : TypeConverter<MovieDetail, MovieEF>
    {
        public MovieDetail ToMTO(MovieEF MovieDetail)
            => new MovieDetail
            {
                Id = MovieDetail.Id,
                UserID = MovieDetail.UserID,
                Director = MovieDetail.Director,
                Genre = MovieDetail.Genre,
                imdbID = MovieDetail.imdbID,
                Poster = MovieDetail.Poster,
                Title = MovieDetail.Title,
                Year = MovieDetail.Year,
                Actors = MovieDetail.Actors,
                Country = MovieDetail.Country
            };

        public MovieEF ToEF(MovieDetail MovieDetail)
            => new MovieEF
            {
                Id = MovieDetail.Id,
                UserID = MovieDetail.UserID,
                Director = MovieDetail.Director,
                Genre = MovieDetail.Genre,
                imdbID = MovieDetail.imdbID,
                Poster = MovieDetail.Poster,
                Title = MovieDetail.Title,
                Year = MovieDetail.Year,
                Actors = MovieDetail.Actors,
                Country = MovieDetail.Country
            };
    }
}

