using Microsoft.AspNetCore.Identity;

namespace PlaceListing.API.Data.Model
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
