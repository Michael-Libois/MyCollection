using Common.DataContracts;
using DAL.Entities;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UserCases.Message
{
    public partial class MessageUC
    {
        private readonly string userId;
        private readonly IRepositoryGeneric<ConversationEF, int> iConversationRepository;
        private readonly IRepositoryGeneric<MessageEF, int> iMessageRepository;
        //private readonly IRepositoryGeneric<ConvUserEF, int> iConvUserRepository;
        private readonly IRepositoryGeneric<ApplicationUserEF, string> iUserRepository;


        public MessageUC(string UserId, IRepositoryGeneric<ApplicationUserEF, string> UserRepository, 
            IRepositoryGeneric<ConversationEF, int> ConversationRepository, IRepositoryGeneric<MessageEF, int> MessageRepository
            //IRepositoryGeneric<ConvUserEF, int> ConvUserRepository
            )
        {
            userId = UserId;
            iUserRepository = UserRepository;
            iConversationRepository = ConversationRepository;
            iMessageRepository = MessageRepository;
            //iConvUserRepository = ConvUserRepository;

        }
    }
}
