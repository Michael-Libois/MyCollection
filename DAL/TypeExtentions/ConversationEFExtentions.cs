using Common.BTO;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TypeExtentions
{
    public static class ConversationEFExtentions
    {


        public static ConversationEF ToEF(this ConversationBTO conversationBTO)
            => new ConversationEF
            {

                Id = conversationBTO.Id,
                UserId1 = conversationBTO.UserId1,
                UserId2 = conversationBTO.UserId2,
                Subject = conversationBTO.Subject
                 

            };

        public static ConversationBTO ToBTO(this ConversationEF conversationEF)
            => new ConversationBTO
            {
                Id = conversationEF.Id,
                UserId1 = conversationEF.UserId1,
                UserId2 = conversationEF.UserId2,
                Subject = conversationEF.Subject,
                
            };
    }




}
