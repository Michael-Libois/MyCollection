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
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //public int MyProperty { get; private set; }
        public IRepositoryGeneric<Conversation, ConversationEF, int> ConversationRepository { get; } = null;
        public IRepositoryGeneric<Message, MessageEF, int> MessageRepository { get; } = null;
        public IRepositoryGeneric<Adress, AdressEF, int> AdressRepository { get; } = null;
        public IRepositoryGeneric<MovieSummary, MovieEF, int> MovieSummaryRepository { get; } = null;
        public IRepositoryGeneric<MovieDetail, MovieEF, int> MovieDetailRepository { get; } = null;
        public IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string> UserRepository { get; } = null;

        public IdentityDbContext<ApplicationUserEF> contextDB { get; } = null;

        public UnitOfWork(DatabaseContext ContextDB,
                          IRepositoryGeneric<Message, MessageEF, int> iMessageRepository,
                          IRepositoryGeneric<Conversation, ConversationEF, int> iConversationRepository,
                          IRepositoryGeneric<Adress, AdressEF, int> iAdressRepository,
                          IRepositoryGeneric<MovieSummary, MovieEF, int> iMovieSummaryRepository,
                          IRepositoryGeneric<MovieDetail, MovieEF, int> iMovieDetailRepository,
                          IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string> iUserRepository)
        {
            ConversationRepository = iConversationRepository;
            MessageRepository = iMessageRepository;
            AdressRepository = iAdressRepository;
            MovieSummaryRepository = iMovieSummaryRepository;
            MovieDetailRepository = iMovieDetailRepository;
            UserRepository = iUserRepository;
            contextDB = ContextDB;
        }

        //public UnitOfWork(DatabaseContext ContextDB)
        //{
        //    ConversationRepository = new RepositoryGeneric<Conversation, ConversationEF, int>(ContextDB, new ConversationConverter());
        //    MessageRepository = new RepositoryGeneric<Message, MessageEF, int>(ContextDB, new MessageConverter());
        //    AdressRepository = new RepositoryGeneric<Adress, AdressEF, int>(ContextDB, new AdressConverter());
        //    MovieSummaryRepository = new RepositoryGeneric<MovieSummary, MovieEF, int>(ContextDB, new MovieSummaryConverter());
        //    MovieDetailRepository = new RepositoryGeneric<MovieDetail, MovieEF, int>(ContextDB, new MovieDetailConverter());
        //    UserRepository = new RepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string>(ContextDB, new ApplicationUserConverter());
        //    contextDB = ContextDB;
        //}

        public void SaveChanges()
        {
            //try
            //{

                contextDB.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    foreach (var entry in ex.Entries)
            //    {
            //        if (entry.Entity is ApplicationUserEF)
            //        {
            //            var proposedValues = entry.CurrentValues;
            //            var databaseValues = entry.GetDatabaseValues();

            //            foreach (var property in proposedValues.Properties)
            //            {
            //                var proposedValue = proposedValues[property];
            //                var databaseValue = databaseValues[property];

            //                // TODO: decide which value should be written to database
            //                // proposedValues[property] = <value to be saved>;
            //                if (property.Name.Contains("Concu"))
            //                    databaseValues[property] = proposedValues[property];
            //            }

            //            // Refresh original values to bypass next concurrency check
            //            entry.OriginalValues.SetValues(databaseValues);
            //        }
            //        else
            //        {
            //            throw new NotSupportedException(
            //                "Don't know how to handle concurrency conflicts for "
            //                + entry.Metadata.Name);
            //        }
            //    }
            //    contextDB.SaveChanges();
            //}
        }
    }
}
