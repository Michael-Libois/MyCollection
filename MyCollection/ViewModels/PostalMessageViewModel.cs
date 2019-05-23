using Common.MTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{
    public class PostalMessageViewModel
    {
        public List<MovieSummary> ListMoviePostal { get; set; }
        public Message message { get; set; }
    }
}
