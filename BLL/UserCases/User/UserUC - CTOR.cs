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
        private readonly IRepositoryGeneric<MovieEF, int> iMovieRepository;
        private readonly IRepositoryGeneric<AdressEF, int> iAdressRepository;
        private readonly IRepositoryGeneric<ApplicationUserEF, string> iUserRepository;

        public User(string UserId, IRepositoryGeneric<MovieEF, int> MovieRepository,
            IRepositoryGeneric<AdressEF, int> AdressRepository,
            IRepositoryGeneric<ApplicationUserEF, string> UserRepository)
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrEmpty(UserId))
            {
                throw new ArgumentException("message", nameof(UserId));
            }

            userId = UserId;
            iMovieRepository = MovieRepository;
            iAdressRepository = AdressRepository;
            iUserRepository = UserRepository;
        }

    }
}
