using Microsoft.AspNetCore.Identity;

namespace IIBSASTHA.Models
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
    }
}
