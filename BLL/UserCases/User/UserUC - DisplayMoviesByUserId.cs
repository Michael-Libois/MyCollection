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
        public IEnumerable<MovieSummary> DisplayMoviesByUserId(string UserID)
        {
            Func<MovieEF, bool> funcPred = p => p.UserID == UserID;
            return iMovieRepository.Filter(funcPred).Select(x => x.ToSummaryBTO());
        }
    }
}
