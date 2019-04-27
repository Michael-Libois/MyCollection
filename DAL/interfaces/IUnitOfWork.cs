using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface IUnitOfWork
    {

        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();


    }
}
