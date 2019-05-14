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

        public IEnumerable<MovieSummaryBTO> ShowUsersSamePostalMovies()
        {
            Func<AdressEF, bool> funcFindUserAdress = p => p.UserID == userId;
            var UserPostalCode = iAdressRepository.Filter(funcFindUserAdress).FirstOrDefault().PostalCode;

            Func<AdressEF, bool> funcFindAllUsersInPostalCode = p => p.PostalCode == UserPostalCode;

            var UserIds = iAdressRepository.Filter(funcFindAllUsersInPostalCode);//.Select(x => x.UserID);

            List<MovieSummaryBTO> listmovies = new List<MovieSummaryBTO>();
            foreach (var item in UserIds)
                listmovies.AddRange(DisplayMoviesByUserId(item.UserID));
            //listusers.Add(ApplicationUserEF);

            //listmovies.ForEach(x => x.UserName = iUserRepository.GetById(x.UserID).UserName);
            listmovies.ForEach(x => x.UserName = formatName(x.UserID));
            
            return listmovies;
        }
        private string formatName(string id)
        { var u = iUserRepository.GetById(id);
            return u.FirstName + " " + u.LastName + $"{u.UserName}";
        }
    }
}
