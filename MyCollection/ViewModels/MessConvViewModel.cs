using Common.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{
    public class MessConvViewModel
    {

        public MessageBTO message { get; set; }
        public List<ConversationBTO> conversation { get; set; }

    }
}
