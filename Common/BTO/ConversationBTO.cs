using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BTO
{
    public class ConversationBTO
    {

        public int Id { get; set; }

        public string Subject { get; set; }

        public string UserB { get; set; }
        public string UserId1 { get; set; }

        //public ApplicationUserEF User1 { get; set; } //Sender

        //[ForeignKey("User2")]
        public string UserId2 { get; set; }
        //public ApplicationUserEF User2 { get; set; } //Receiver

        //public ICollection<MessageEF> Messages { get; set; }

    }
}
