using Common.BTO;
using Common.DTO.IMDBProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeExtentions
{
    public static class MovieDetailSummaryExtentions
    {
        public static MovieSummaryBTO ToBTO(this IMDBMovieSummary MovieDetail)
            => new MovieSummaryBTO
            {
                Id = 0,
                Director = MovieDetail.Director,
                Genre = MovieDetail.Genre,
                imdbID = MovieDetail.imdbID,
                Poster = MovieDetail.Poster,
                Title = MovieDetail.Title,
                Year = MovieDetail.Year
            };

        //public static IMDBMovieSummary ToDTO(this MovieSummaryBTO MovieDetail)
        //    => new IMDBMovieSummary
        //    {
        //        Director = MovieDetail.Director,
        //        Genre = MovieDetail.Genre,
        //        imdbID = MovieDetail.imdbID,
        //        Poster = MovieDetail.Poster,
        //        Title = MovieDetail.Title,
        //        Year = MovieDetail.Year
        //    };
    }
}
