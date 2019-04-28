using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Database=MuCollection;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }


        public virtual DbSet<Movie> Movies { get; set; }
    }
}
