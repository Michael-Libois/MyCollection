using Common.BTO;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {


        public void EditMovie (MovieDetailBTO movie)
        {

            iMovieRepository.Edit(movie.DetBToToDEF());
            iMovieRepository.SaveChanges();


        }


    }
}
