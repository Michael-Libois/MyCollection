using Common.BTO;
using Common.DTO.IMDBProxy;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TypeExtentions
{
    public static class MovieEFExtentions
    {
        public static MovieEF ToEF(this MovieSummaryBTO MovieDetail)
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

        public static MovieSummaryBTO ToSummaryBTO(this MovieEF MovieDetail)
            => new MovieSummaryBTO
            {
                UserID = MovieDetail.UserID,
                Id = MovieDetail.Id,
                Director = MovieDetail.Director,
                Genre = MovieDetail.Genre,
                imdbID = MovieDetail.imdbID,
                Poster = MovieDetail.Poster,
                Title = MovieDetail.Title,
                Year = MovieDetail.Year
            };
        public static MovieDetailBTO ToDetailBTO(this MovieEF MovieDetail)
            => new MovieDetailBTO
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

        public static MovieEF DetBToToDEF(this MovieDetailBTO MovieDetail)
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
