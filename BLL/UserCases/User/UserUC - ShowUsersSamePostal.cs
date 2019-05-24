using Common.MTO;
using DAL.Entities;
using DAL.Repo;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {

        public IEnumerable<MovieSummary> ShowUsersSamePostalMovies()
        {
            Func<Adress, bool> funcFindUserAdress = p => p.UserID == userId;
            var UserPostalCode = unitOfWork.AdressRepository.Filter(funcFindUserAdress).FirstOrDefault().PostalCode;

            Func<Adress, bool> funcFindAllUsersInPostalCode = p => (p.PostalCode == UserPostalCode)&&(p.UserID != userId);

            var UserIds = unitOfWork.AdressRepository.Filter(funcFindAllUsersInPostalCode);//.Select(x => x.UserID);

            List<MovieSummary> listmovies = new List<MovieSummary>();
            foreach (var item in UserIds)
                listmovies.AddRange(DisplayMoviesByUserId(item.UserID));
            
            listmovies.ForEach(x => x.UserName = formatName(x.UserID));
            
            return listmovies;
        }

        private string formatName(string id)
        { var u = unitOfWork.UserRepository.GetById(id);
            return u.FirstName + " " + u.LastName + $"{u.UserName}";
        }
    }
}
