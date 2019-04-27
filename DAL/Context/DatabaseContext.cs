using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
    }
}
