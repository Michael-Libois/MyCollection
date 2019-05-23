using Common.DataContracts;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class User
    {
        private readonly string userId;
        private readonly IUnitOfWork unityOfWork;

        public User(string UserId, IUnitOfWork unityOfWork)
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrEmpty(UserId))
            {
                throw new ArgumentException("message", nameof(UserId));
            }

            userId = UserId;
            this.unityOfWork = unityOfWork;
        }

    }
}
