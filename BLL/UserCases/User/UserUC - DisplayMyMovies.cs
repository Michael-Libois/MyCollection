using Common.BTO;
using DAL.Entities;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {
        public IEnumerable<MovieSummaryBTO> DisplayMyMovies()
        {
            Func<MovieEF, bool> funcPred = p => p.UserID == userId;
            return iMovieRepository.Filter(funcPred).Select(x=>x.ToBTO());
        }
    }
}
