using Common.MTO;
using Common.DTO.IMDBProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeExtentions
{
    public static class MovieDetailExtentions
    {
        public static MovieDetail ToMTO(this IMDBMovieDetail MovieDetail)
        {
            return new MovieDetail
            {
                Id = MovieDetail.Id,
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
}
