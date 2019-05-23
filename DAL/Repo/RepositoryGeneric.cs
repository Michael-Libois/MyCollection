using Common.DataContracts;
using DAL.Context;
using DAL.Entities;
using DAL.Entities.Messages;
using DAL.Converters;
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
    public class RepositoryGeneric<TMto, TEf, TIdType> : IRepositoryGeneric<TMto, TEf, TIdType> where TEf : class, IGenericEntities<TIdType>
    {

        public IdentityDbContext<ApplicationUserEF> _context;
        private readonly TypeConverter<TMto, TEf> converter;

        public RepositoryGeneric(IdentityDbContext<ApplicationUserEF> Context, TypeConverter<TMto, TEf> Converter)
        {
            this._context = Context;
            converter = Converter;
        }


        public RepositoryGeneric(IdentityDbContext<ApplicationUserEF> contextDB, DatabaseContext context) => _context = context;

        public void Create(TMto Dto)
        {
            _context.Set<TEf>().Add(converter.ToEF(Dto));
        }

        public void Delete(TMto Dto)
        {
            _context.Set<TEf>().Remove(converter.ToEF(Dto));
        }

        public void Delete(TIdType id)
        {
            var entityToDelete = _context.Set<TEf>().FirstOrDefault(e => e.Id.Equals(id));
            if (entityToDelete != null)
            {
                _context.Set<TEf>().Remove(entityToDelete);
            }
        }

        public void Edit(TMto Dto)
        {
            if (_context.Set<TEf>().Any(e => e.Id.Equals((converter.ToEF(Dto).Id))))
            {
                _context.Set<TEf>().Attach(converter.ToEF(Dto));
                _context.Set<TEf>().Update(converter.ToEF(Dto));
            }

            //var editedEntity = _context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            //editedEntity = entity;
        }

        public TMto GetById(TIdType id)
        {
            return converter.ToMTO(_context.Set<TEf>().FirstOrDefault(e => e.Id.Equals(id)));
        }

        public IEnumerable<TMto> Filter()
        {
            return _context.Set<TEf>().Select(x => converter.ToMTO(x));
        }

        public IEnumerable<TMto> Filter(Func<TMto, bool> predicate)
        {
            return _context.Set<TEf>().Select(x => converter.ToMTO(x)).Where(predicate);
        }

        public void SaveChanges() => _context.SaveChanges();

    }

}
