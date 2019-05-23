using Common.DataContracts;
using DAL.Entities;
using DAL.Entities.Messages;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class MessageUC
    {
        private readonly string userId;
        private readonly IUnitOfWork unitOfWork;

        public MessageUC(string UserId, IUnitOfWork unitOfWork)
        {

            userId = UserId;
            this.unitOfWork = unitOfWork;

        }
    }
}
