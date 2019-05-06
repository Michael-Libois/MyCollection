using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class ApplicationUserEF : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AcceptShared { get; set; }
    }
}
