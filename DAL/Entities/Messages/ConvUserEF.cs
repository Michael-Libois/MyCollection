using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Messages
{
    public class ConvUserEF
    {
        //[ForeignKey("ConversationEF")]
        public int ConversationId { get; set; }
        public ConversationEF ConversationEF { get; set; }


        //[ForeignKey("ApplicationUserEF")]
        public string UserId { get; set; }
        public ApplicationUserEF ApplicationUserEF { get; set; }

    }
}
