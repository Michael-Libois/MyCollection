using Common.DataContracts;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases
{
    public partial class Visitor
    {
        private readonly IUnitOfWork unitOfWork;

        public Visitor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
