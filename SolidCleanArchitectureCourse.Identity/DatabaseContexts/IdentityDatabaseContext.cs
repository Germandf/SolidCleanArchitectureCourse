using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolidCleanArchitectureCourse.Identity.Models;

namespace SolidCleanArchitectureCourse.Identity.DatabaseContexts;

public class IdentityDatabaseContext : IdentityDbContext<ApplicationUser>
{
	public IdentityDatabaseContext(
		DbContextOptions<IdentityDatabaseContext> options) : base(options)
	{
	}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(
            typeof(IdentityDatabaseContext).Assembly);
    }
}
