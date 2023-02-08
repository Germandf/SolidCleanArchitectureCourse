using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolidCleanArchitectureCourse.Identity.Models;

namespace SolidCleanArchitectureCourse.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser
            {
                Id = "9b9ede6d-f70f-41c3-9052-d5ed1f669023",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null!, "Pass12345!"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "116f101c-84c3-4eba-bbd8-73599fd4beb9",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "System",
                LastName = "User",
                UserName = "user@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null!, "Pass12345!"),
                EmailConfirmed = true
            });
    }
}
