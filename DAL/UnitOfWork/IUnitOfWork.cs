using Common.DataContracts;
using Common.MTO;
using DAL.Entities;
using DAL.Entities.Messages;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork // : IDispose
    {
        IRepositoryGeneric<Conversation, ConversationEF, int> ConversationRepository { get; }
        IRepositoryGeneric<Message, MessageEF, int> MessageRepository { get; }
        IRepositoryGeneric<Adress, AdressEF, int> AdressRepository { get; }
        IRepositoryGeneric<MovieDetail, MovieEF, int> MovieDetailRepository { get; }
        IRepositoryGeneric<MovieSummary, MovieEF, int> MovieSummaryRepository { get; }
        IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string> UserRepository { get; }

        void SaveChanges();
    }
}