﻿using Common.BTO;
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
            return DisplayMoviesByUserId(userId);
        }
    }
}