using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using DAL.Entities.Messages;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Repo;
using DAL.Converters;
using Common.MTO;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        //public int MyProperty { get; private set; }
        public IRepositoryGeneric<Conversation, ConversationEF, int> iConversationRepository { get; } = null;
        public IRepositoryGeneric<Message, MessageEF, int> iMessageRepository { get; } = null;
        public IRepositoryGeneric<Adress, AdressEF, int> iAdressRepository { get; } = null;
        public IRepositoryGeneric<MovieSummary, MovieEF, int> iMovieSummaryRepository { get; } = null;
        public IRepositoryGeneric<MovieDetail, MovieEF, int> iMovieDetailRepository { get; } = null;
        public IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string> iUserRepository { get; } = null;


        public IdentityDbContext<ApplicationUserEF> contextDB;

        public UnitOfWork(IdentityDbContext<ApplicationUserEF> ContextDB)
        {
            iConversationRepository = new RepositoryGeneric<Conversation, ConversationEF, int>(ContextDB, new ConversationConverter());
            iMessageRepository = new RepositoryGeneric<Message, MessageEF, int>(ContextDB, new MessageConverter());
            iAdressRepository = new RepositoryGeneric<Adress, AdressEF, int>(ContextDB, new AdressConverter());
            iMovieSummaryRepository = new RepositoryGeneric<MovieSummary, MovieEF, int>(ContextDB, new MovieSummaryConverter());
            iMovieDetailRepository = new RepositoryGeneric<MovieDetail, MovieEF, int>(ContextDB, new MovieDetailConverter());
            iUserRepository = new RepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string>(ContextDB, new ApplicationUserConverter());
            contextDB = ContextDB;
        }

        public void Dispose()
        {
            SaveChanges();
        }

        public void SaveChanges()
        {
            contextDB.SaveChanges();
        }


    }
}
