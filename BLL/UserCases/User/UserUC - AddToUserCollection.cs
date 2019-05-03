using Common.BTO;

using DAL.Entities;
using DAL.ExternalData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserCases
{
    public partial class User : Visitor
    {
        public void AddToUserCollection(MovieDetailBTO imdbmovie)
        {
            try
            {
                MovieEF movie = new MovieEF();
                movie.Director = imdbmovie.Director;
                movie.Genre = imdbmovie.Genre;
                movie.imdbID = imdbmovie.imdbID;
                movie.Poster = imdbmovie.Poster;
                movie.Title = imdbmovie.Title;
                movie.Year = imdbmovie.Year;
                movie.UserID = userId;

                // TODO: Add insert logic here
                iMovieRepository.Create(movie);
                iMovieRepository.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Movie not added to list");
            }
        }
    }
}
