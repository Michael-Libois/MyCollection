using Common.BTO;

using DAL.Entities;
using DAL.ExternalData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserCases
{
    public partial class User : Visitor
    {
        public void DeleteFromUserCollection(int id)
        {

            iMovieRepository.Delete(id);
            iMovieRepository.SaveChanges();





        }
    }
}
