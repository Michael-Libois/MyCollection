using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.MTO
{
    public class Message
    {
        public int Id { get; set; }


        public string UserId { get; set; } //Sender
        //public ApplicationUserEF User { get; set; }
        public string UserName { get; set; }

        public int ConversationId { get; set; }
        //public ConversationEF Conversation { get; set; }

        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datetime { get; set; }
        public bool IsChecked { get; set; }
    }
}
