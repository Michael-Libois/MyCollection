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
        public IEnumerable<MovieSummaryBTO> FilterMyMovies(string filter, string searchTerm)
        {
            Func<MovieEF, bool> funcPred = p => p.UserID == userId;
            Func<MovieSummaryBTO, bool> funcFilter;

            var result1 = iMovieRepository.Filter(funcPred).Select(x => x.ToBTO());

            switch (filter)
            {
                case "Genre":
                    funcFilter = p => p.Genre.Contains(searchTerm);
                    break;
                case "Title":
                    funcFilter = p => p.Title.Contains(searchTerm);
                    break;
                case "Year":
                    funcFilter = p => p.Year.Contains(searchTerm);
                    break;
                case "Director":
                    funcFilter = p => p.Director.Contains(searchTerm);
                    break;
                default:
                    funcFilter = p => true;
                    break;
            }

            return result1.Where(funcFilter);
        }
    }
}
