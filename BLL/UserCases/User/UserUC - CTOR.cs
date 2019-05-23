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
        private readonly IUnitOfWork unitOfWork;

        public User(string UserId, IUnitOfWork unitOfWork)
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrEmpty(UserId))
            {
                throw new ArgumentException("message", nameof(UserId));
            }

            userId = UserId;
            this.unitOfWork = unitOfWork;
        }

    }
}
