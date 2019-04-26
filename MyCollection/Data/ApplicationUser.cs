using Microsoft.AspNetCore.Identity;

namespace MyCollection.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
