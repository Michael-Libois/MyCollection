using Common.DataContracts;
using Common.MTO;
using DAL.Entities;
using DAL.Entities.Messages;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepositoryGeneric<Conversation, ConversationEF, int> iConversationRepository { get; }
        IRepositoryGeneric<Message, MessageEF, int> iMessageRepository { get; }
        IRepositoryGeneric<Adress, AdressEF, int> iAdressRepository { get; }
        IRepositoryGeneric<MovieDetail, MovieEF, int> iMovieDetailRepository { get; }
        IRepositoryGeneric<MovieSummary, MovieEF, int> iMovieSummaryRepository { get; }
        IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string> iUserRepository { get; }

        void Dispose();
        void SaveChanges();
    }
}