using Common.MTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{
    public class MessConvViewModel
    {

        public Message message { get; set; }
        public List<Conversation> conversation { get; set; }

    }
}
