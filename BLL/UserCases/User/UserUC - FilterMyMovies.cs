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
        public IEnumerable<MovieSummary> FilterMyMovies(string filter, string searchTerm)
        {
            Func<MovieSummary, bool> funcPred = p => p.UserID == userId;
            Func<MovieSummary, bool> funcFilter;

            var result1 = unitOfWork.iMovieSummaryRepository.Filter(funcPred);

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

            return result1.Where(funcFilter);
        }
    }
}
