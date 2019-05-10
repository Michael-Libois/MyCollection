using Common.DataContracts;
using DAL.Entities.Messages;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class ApplicationUserEF : IdentityUser, IGenericEntities<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AcceptShared { get; set; }
        public ICollection<ConvUserEF> ConvUserEFs { get; set; }
    }
}
