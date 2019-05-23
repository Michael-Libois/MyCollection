using Common.MTO;
using Common.DTO.IMDBProxy;
using Common.MTO;
using DAL.Entities;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Converters
{
    public class MessageConverter : TypeConverter<Message, MessageEF>
    {
        public MessageEF ToEF(Message Message)
            => new MessageEF
            {
                UserId = Message.UserId,
                Content = Message.Content,
                Datetime = Message.Datetime,
                IsChecked = Message.IsChecked,
                ConversationId = Message.ConversationId

            };

        public Message ToMTO(MessageEF messageEF)
            => new Message
            {
                UserId = messageEF.UserId,
                Content = messageEF.Content,
                Datetime = messageEF.Datetime,
                IsChecked = messageEF.IsChecked,
                ConversationId = messageEF.ConversationId
            };
    }
}
