using Common.MTO;

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
        public void AddToUserCollection(MovieDetail imdbmovie)
        {
            try
            {
                var movie = new Movie
                {
                    Director = imdbmovie.Director,
                    Genre = imdbmovie.Genre,
                    imdbID = imdbmovie.imdbID,
                    Poster = imdbmovie.Poster,
                    Title = imdbmovie.Title,
                    Year = imdbmovie.Year,
                    UserID = userId,
                    Actors = imdbmovie.Actors,
                    Country = imdbmovie.Country
                };

                // TODO: Add insert logic here
                unityOfWork.iMovieDetailRepository.Create(movie);
                unityOfWork.iMovieDetailRepository.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Movie not added to list");
            }
        }
    }
}
