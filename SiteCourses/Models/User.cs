using Microsoft.AspNetCore.Identity;

namespace SiteCourses.Models
{
    public class User : IdentityUser
    {
        public static implicit operator User?(IdentityRole? v)
        {
            throw new NotImplementedException();
        }
    }
}
