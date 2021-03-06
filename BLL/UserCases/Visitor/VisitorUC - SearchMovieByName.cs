﻿using Common.MTO;
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
        public IEnumerable<MovieSummary> SearchMoviesByName(string name)
        {
            var a = new IMDBProxy();

            var result = (Task.Run(() => a.GetMovies(name)).Result);

            if (result.Count()==0)
                result = (Task.Run(() => a.GetMoviesT(name)).Result);

            return result.Select(x => x.ToMTO());
        }
    }
}
