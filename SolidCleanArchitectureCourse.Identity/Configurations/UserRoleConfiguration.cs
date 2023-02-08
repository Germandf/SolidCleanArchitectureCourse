using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolidCleanArchitectureCourse.Identity.Configurations;
public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "be484926-f176-4b98-8204-a19e4890547d",
                UserId = "9b9ede6d-f70f-41c3-9052-d5ed1f669023"
            },
            new IdentityUserRole<string>
            {
                RoleId = "6e635e97-24e0-407d-b127-49e78633873d",
                UserId = "116f101c-84c3-4eba-bbd8-73599fd4beb9"
            });
    }
}
