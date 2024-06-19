using CollegeBooks.Api.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegeBooks.Api.AuthWithIdentity
{
    public class ApiDbContext : IdentityDbContext<ApiUser>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    }
}
