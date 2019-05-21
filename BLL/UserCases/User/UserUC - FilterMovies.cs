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


        public IEnumerable<MovieSummaryBTO> FilterMovies(IEnumerable<MovieSummaryBTO> list,  string filter, string searchTerm)
        {
            Func<MovieEF, bool> funcPred = p => p.UserID == userId;
            Func<MovieSummaryBTO, bool> funcFilter;

            var result1 = new List<MovieSummaryBTO>();
            
                switch (filter)
                {
                    case "Genre":
                        funcFilter = p => p.Genre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
                        break;
                    case "Title":
                        funcFilter = p => p.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
                        break;
                    case "Year":
                        funcFilter = p => p.Year.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
                        break;
                    case "Director":
                        funcFilter = p => p.Director.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
                        break;
                    default:
                        funcFilter = p => true;
                        break;
                }
                result1 = list.Where(funcFilter).ToList();

            return result1;

            


      
        }

    }
}
