using Common.DataContracts;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {
        private readonly string userId;
        private readonly IRepositoryGeneric<MovieEF> iMovieRepository;
        private readonly IRepositoryGeneric<AdressEF> iAdressRepository;

        public User(string UserId, IRepositoryGeneric<MovieEF> MovieRepository, IRepositoryGeneric<AdressEF> AdressRepository)
        {
            if (string.IsNullOrWhiteSpace(UserId)|| string.IsNullOrEmpty(UserId))
            {
                throw new ArgumentException("message", nameof(UserId));
            }

            userId = UserId;
            iMovieRepository = MovieRepository;
            iAdressRepository = AdressRepository;
        }

    }
}
