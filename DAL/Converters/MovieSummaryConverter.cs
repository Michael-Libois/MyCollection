using Common.MTO;
using Common.DTO.IMDBProxy;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Converters
{
    public class MovieSummaryConverter : TypeConverter<MovieSummary, MovieEF>
    {
        public MovieEF ToEF(MovieSummary MovieDetail)
            => new MovieEF
            {
                Id = MovieDetail.Id,
                UserID = MovieDetail.UserID,
                Director = MovieDetail.Director,
                Genre = MovieDetail.Genre,
                imdbID = MovieDetail.imdbID,
                Poster = MovieDetail.Poster,
                Title = MovieDetail.Title,
                Year = MovieDetail.Year
            };

        public MovieSummary ToMTO(MovieEF Entity)
            => new MovieSummary
            {
                UserID = Entity.UserID,
                Id = Entity.Id,
                Director = Entity.Director,
                Genre = Entity.Genre,
                imdbID = Entity.imdbID,
                Poster = Entity.Poster,
                Title = Entity.Title,
                Year = Entity.Year
            };
    }

}
