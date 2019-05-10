using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataContracts
{
    public interface IRepositoryGeneric<T,U> where T : IGenericEntities<U>
    {

        void Create(T entity);
        void Delete(T entity);
        void Delete(U id);
        void Edit(T entity);

        //read side (could be in separate Readonly Generic Repository)
        T GetById(U id);
        IEnumerable<T> Filter();
        IEnumerable<T> Filter(Func<T, bool> predicate);

        //separate method SaveChanges can be helpful when using this pattern with UnitOfWork
        void SaveChanges();


    }
}
