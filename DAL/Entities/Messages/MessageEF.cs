using Common.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Messages
{
    public class MessageEF : IGenericEntities<int>
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUserEF User { get; set; } //Sender

        [ForeignKey("Conversation")]
        public int ConversationId { get; set; }
        public ConversationEF Conversation { get; set; }

        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datetime { get; set; }
        public bool IsChecked { get; set; }

    }
}
