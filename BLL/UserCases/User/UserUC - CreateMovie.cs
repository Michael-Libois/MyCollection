using Common.MTO;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {

        public void CreateMovie(MovieDetail movie)
        {
            movie.UserID = userId;
            unityOfWork.iMovieDetailRepository.Create(movie);
            unityOfWork.SaveChanges();

        }


    }
}
