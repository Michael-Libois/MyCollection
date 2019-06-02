using Common.MTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{
    public class PostalMessageViewModel
    {
        public List<MovieSummary> ListMoviePostal { get; set; }

        
        
        public Message Message { get; set; }
    }
}
