using DAL.Context;
using DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Factory
{
    class DbFactory : IDbFactory, IDisposable
    {

        private DatabaseContext _dataContext;
        public DbFactory(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }
        public DatabaseContext GetDataContext
        {
            get
            {
                return _dataContext;
            }
        }
        
        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    
                }
            }
            isDisposed = true;
        }


    }
}
