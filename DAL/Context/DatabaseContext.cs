using DAL.Entities;
using DAL.Entities.Messages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class DatabaseContext : IdentityDbContext<ApplicationUserEF>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
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
            //builder.Entity<ConvUserEF>().HasKey(cu => new { cu.ConversationId, cu.UserId });

            //builder.Entity<ConvUserEF>()
            //    .HasOne<ConversationEF>(cu => cu.ConversationEF)
            //    .WithMany(c => c.ConvUserEFs)
            //    .HasForeignKey(cu => cu.ConversationId);


            //builder.Entity<ConvUserEF>()
            //    .HasOne<ApplicationUserEF>(cu => cu.ApplicationUserEF)
            //    .WithMany(au => au.ConvUserEFs)
            //    .HasForeignKey(cu => cu.UserId);

        }

        public virtual void Save()
        {
            base.SaveChanges();
        }


        public virtual DbSet<MovieEF> Movies { get; set; }
        public virtual DbSet<AdressEF> Adresses { get; set; }
        public virtual DbSet<MessageEF> Messages { get; set; }
        public virtual DbSet<ConversationEF> Conversations { get; set; }
        //public virtual DbSet<ConvUserEF> ConvUsers { get; set; }

    }
}
