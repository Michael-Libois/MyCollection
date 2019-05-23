using Common.MTO;
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
        public MovieDetail SearchDetailsOfMovie(string ImdbId)
        {
            var a = new IMDBProxy();

            return Task.Run(() => a.GetMovieDetail(ImdbId)).Result.ToMTO();
        }
    }
}
