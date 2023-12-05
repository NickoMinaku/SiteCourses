using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SiteCourses.Models
{
    public class IDBContext : IdentityDbContext<User>
    {
        public IDBContext(DbContextOptions<IDBContext> options) : base(options)
        {
        }
    }
}