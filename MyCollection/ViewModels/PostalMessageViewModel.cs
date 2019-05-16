using Common.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{
    public class PostalMessageViewModel
    {
        public List<MovieSummaryBTO> ListMoviePostal { get; set; }
        public MessageBTO messagePost { get; set; }
    }
}
