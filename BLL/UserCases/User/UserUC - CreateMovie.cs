using Common.BTO;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {

        public void CreateMovie(MovieDetailBTO movie)
        {
            movie.UserID = userId;
            iMovieRepository.Create(movie.DetBToToDEF());
            iMovieRepository.SaveChanges();

        }


    }
}
