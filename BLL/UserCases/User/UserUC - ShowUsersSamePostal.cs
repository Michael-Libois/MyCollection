using Common.BTO;
using DAL.Entities;
using DAL.Repo;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {

        //Func<AdressEF, bool> funcPred = p => p.PostalCode == ;
        //return iMovieRepository.Filter(funcPred).Select(x=>x.ToBTO());

        public IEnumerable<AdressBTO> ShowUsersSamePostal()
        {
            Func<AdressEF, bool> funcFindUserAdress = p => p.UserID == userId;
            var UserPostalCode = iAdressRepository.Filter(funcFindUserAdress).FirstOrDefault().PostalCode;

            Func<AdressEF, bool> funcFindAllUsersInPostalCode = p => p.PostalCode == UserPostalCode;

            return iAdressRepository.Filter(funcFindAllUsersInPostalCode).Select(x => x.ToBTO());
        }
    }
}
