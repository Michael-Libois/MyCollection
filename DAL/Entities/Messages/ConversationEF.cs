using Common.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Messages
{
    public class ConversationEF : IGenericEntities<int>
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public ICollection<MessageEF> Messages { get; set; }
        public ICollection<ConvUserEF> ConvUserEFs { get; set; }
    }
}
