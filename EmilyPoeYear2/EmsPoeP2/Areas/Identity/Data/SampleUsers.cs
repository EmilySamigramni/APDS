
using Microsoft.AspNetCore.Identity;

namespace EmsPoeP2.Areas.Identity.Data
{
    public class SampleUsers :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
