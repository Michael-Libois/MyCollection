using Common.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Messages
{
    public class ConversationEF : IGenericEntities<int>
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        [ForeignKey("User1")]
        public string UserId1 { get; set; }

        public ApplicationUserEF User1 { get; set; } //Sender

        [ForeignKey("User2")]
        public string UserId2 { get; set; }
        public ApplicationUserEF User2 { get; set; } //Receiver
        
        public ICollection<MessageEF> Messages { get; set; }
        //public ICollection<ConvUserEF> ConvUserEFs { get; set; } //Liste de user qu'on access a la conversation
    }
}
