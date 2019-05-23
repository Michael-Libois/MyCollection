using Common.MTO;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {


        public void EditMovie (MovieDetail movie)
        {

            iMovieRepository.Edit(movie.DetBToToDEF());
            iMovieRepository.SaveChanges();


        }


    }
}
