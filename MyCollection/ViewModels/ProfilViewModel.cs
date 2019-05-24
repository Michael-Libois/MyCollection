using Common.MTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{
    public class ProfilViewModel
    {
        public ApplicationUserEF User { get; set; }
        public Adress AdressUser { get; set; }

    }
}
