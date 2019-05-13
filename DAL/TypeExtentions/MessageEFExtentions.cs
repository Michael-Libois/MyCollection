using Common.BTO;
using Common.DTO.IMDBProxy;
using DAL.Entities;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TypeExtentions
{
    public static class MessageEFExtentions
    {
        public static MessageEF ToEF(this MessageBTO messageBTO)
            => new MessageEF
            {
                UserId = messageBTO.UserId,
                Content = messageBTO.Content,
                Datetime = messageBTO.Datetime,
                IsChecked = messageBTO.IsChecked,
                ConversationId = messageBTO.ConversationId

            };

        public static MessageBTO ToBTO(this MessageEF messageEF)
            => new MessageBTO
            {
                UserId = messageEF.UserId,
                Content = messageEF.Content,
                Datetime = messageEF.Datetime,
                IsChecked = messageEF.IsChecked,
                ConversationId = messageEF.ConversationId
            };
    }
}
