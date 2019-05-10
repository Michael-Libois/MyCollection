using Common.BTO;
using DAL.Entities;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {
        public MovieDetailBTO DisplayMovieDetail(int id)
            => iMovieRepository.GetById(id).ToDetailBTO();
    }
}
