using Common.BTO;
using Common.DTO.IMDBProxy;
using Common.TypeExtentions;
using DAL.Entities;
using DAL.ExternalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserCases
{
    public partial class Visitor
    {
        public IEnumerable<MovieSummaryBTO> SearchMoviesByName(string Name)
        {
            var a = new IMDBProxy();
            return (Task.Run(() => a.GetMovies(Name)).Result).Select(x => x.ToBTO());
        }
    }
}
