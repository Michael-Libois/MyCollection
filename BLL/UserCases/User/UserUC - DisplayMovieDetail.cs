using Common.MTO;
using DAL.Entities;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {
        public MovieDetail DisplayMovieDetail(int id)
            => iMovieRepository.GetById(id).ToDetailBTO();
    }
}
