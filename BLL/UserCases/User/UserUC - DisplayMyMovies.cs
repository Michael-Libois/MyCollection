using Common.MTO;
using DAL.Entities;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {
        public IEnumerable<MovieSummary> DisplayMyMovies()
        {
            return DisplayMoviesByUserId(userId);
        }
    }
}
