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
        public IEnumerable<MovieSummaryBTO> DisplayMoviesByUserId(string UserID)
        {
            Func<MovieEF, bool> funcPred = p => p.UserID == UserID;
            return iMovieRepository.Filter(funcPred).Select(x => x.ToSummaryBTO());
        }
    }
}
