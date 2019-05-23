using Common.MTO;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Converters
{
    public class ConversationConverter : TypeConverter<Conversation, ConversationEF>
    {


        public ConversationEF ToEF(Conversation Conversation)
            => new ConversationEF
            {

                Id = Conversation.Id,
                UserId1 = Conversation.UserId1,
                UserId2 = Conversation.UserId2,
                Subject = Conversation.Subject
                 

            };

        public Conversation ToMTO(ConversationEF conversationEF)
            => new Conversation
            {
                Id = conversationEF.Id,
                UserId1 = conversationEF.UserId1,
                UserId2 = conversationEF.UserId2,
                Subject = conversationEF.Subject,
                
            };
    }




}
