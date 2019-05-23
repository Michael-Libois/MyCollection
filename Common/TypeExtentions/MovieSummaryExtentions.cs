using Common.MTO;
using Common.DTO.IMDBProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeExtentions
{
    public static class MovieDetailSummaryExtentions
    {
        public static MovieSummary ToMTO(this IMDBMovieSummary MovieDetail)
            => MovieDetail != null ? new MovieSummary
            {
                Id = 0,
                UserID = MovieDetail.UserID,
                Director = MovieDetail.Director,
                Genre = MovieDetail.Genre,
                imdbID = MovieDetail.imdbID,
                Poster = MovieDetail.Poster,
                Title = MovieDetail.Title,
                Year = MovieDetail.Year
            } : null;
        //public static MovieSummary ToBTOAncien(this IMDBMovieSummary MovieDetail)
        //    => new MovieSummary
        //    {
        //        Id = 0,
        //        UserID = MovieDetail.UserID,
        //        Director = MovieDetail.Director,
        //        Genre = MovieDetail.Genre,
        //        imdbID = MovieDetail.imdbID,
        //        Poster = MovieDetail.Poster,
        //        Title = MovieDetail.Title,
        //        Year = MovieDetail.Year
        //    };
    }
}
