using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawRescue.Domain.Entities.Identity;

namespace PawRescue.DataAccess.Contexts;

public class PawRescueContext : IdentityDbContext<AppUser>
{
    public PawRescueContext(DbContextOptions<PawRescueContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
