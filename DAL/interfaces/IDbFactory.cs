using DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface IDbFactory
    {
        DatabaseContext GetDataContext { get; }
    }
}
