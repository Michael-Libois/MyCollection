using Common.BTO;
using Common.TypeExtentions;
using DAL.Entities;
using DAL.ExternalData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserCases
{
    public partial class Visitor
    {
        public MovieDetailBTO SearchDetailsOfMovie(string ImdbId)
        {
            var a = new IMDBProxy();

            return Task.Run(() => a.GetMovieDetail(ImdbId)).Result.ToBTO();
        }
    }
}
