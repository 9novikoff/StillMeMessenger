using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StillMeBackend.Gateway;

public class IdentityDbContext: IdentityDbContext<User>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
            
    }
}