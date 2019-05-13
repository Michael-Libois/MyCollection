using Common.DataContracts;
using DAL.Context;
using DAL.Entities;
using DAL.Entities.Messages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class RepositoryGeneric<T,U> : IRepositoryGeneric<T,U> where T : class, IGenericEntities<U>
    {

        public IdentityDbContext<ApplicationUserEF> _context;


        public RepositoryGeneric(IdentityDbContext<ApplicationUserEF> Context)
        {
            this._context = Context;
        }


        public RepositoryGeneric(DatabaseContext context) => _context = context;

        public void Create(T entity)
        {
                _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Delete(U id)
        {
            var entityToDelete = _context.Set<T>().FirstOrDefault(e => e.Id.Equals(id));
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }
        }

        public void Edit(T entity)
        {
            if (_context.Set<T>().Any(e => e.Id.Equals(entity.Id)))
            {
                _context.Set<T>().Attach(entity);
                _context.Set<T>().Update(entity);
            }

            //var editedEntity = _context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            //editedEntity = entity;
        }

        public T GetById(U id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id.Equals(id));
        }

        public IEnumerable<T> Filter()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void SaveChanges() => _context.SaveChanges();

    }

}
