using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BTO
{
    public class MessageBTO
    {
        public int Id { get; set; }

        
        public string UserId { get; set; } //Sender
        //public ApplicationUserEF User { get; set; }
        public string UserName { get; set; }

        public int ConversationId { get; set; }
        //public ConversationEF Conversation { get; set; }

        public string Content { get; set; }
        public DateTime Datetime { get; set; }
        public bool IsChecked { get; set; }
    }
}
