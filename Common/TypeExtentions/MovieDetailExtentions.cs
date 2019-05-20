using Common.BTO;
using Common.DTO.IMDBProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeExtentions
{
    public static class MovieDetailExtentions
    {
        public static MovieDetailBTO ToBTO(this IMDBMovieDetail MovieDetail)
            => new MovieDetailBTO
            {
                Id= MovieDetail.Id,
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
