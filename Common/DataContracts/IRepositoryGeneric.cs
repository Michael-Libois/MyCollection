using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataContracts
{
    public interface IRepositoryGeneric<TDto, Tef,TIdType> where Tef : IGenericEntities<TIdType>
    {

        void Create(TDto entity);
        void Delete(TDto entity);
        void Delete(TIdType id);
        void Edit(TDto entity);

        //read side (could be in separate Readonly Generic Repository)
        TDto GetById(TIdType id);
        IEnumerable<TDto> Filter();
        IEnumerable<TDto> Filter(Func<TDto, bool> predicate);

        //separate method SaveChanges can be helpful when using this pattern with UnitOfWork
        void SaveChanges();


    }
}
