using Microsoft.EntityFrameworkCore;
using Shouldly;
using SolidCleanArchitectureCourse.Domain;
using SolidCleanArchitectureCourse.Persistence.DatabaseContexts;

namespace SolidCleanArchitectureCrouse.IntegrationTests;

public class DatabaseContextTests
{
    private DatabaseContext _databaseContext;

    public DatabaseContextTests()
	{
		var dbOptions = new DbContextOptionsBuilder<DatabaseContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

		_databaseContext = new DatabaseContext(dbOptions);
	}

	[Fact]
	public async Task Save_SetDateCreatedValue()
	{
		var leaveType = new LeaveType
		{
			Id = 1,
			DefaultDays = 10,
			Name = "Test Vacation"
		};

		await _databaseContext.LeaveTypes.AddAsync(leaveType);
		await _databaseContext.SaveChangesAsync();

		leaveType.DateCreated.ShouldNotBeNull();
	}

    [Fact]
    public async Task Save_SetDateModifiedValue()
    {
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        await _databaseContext.LeaveTypes.AddAsync(leaveType);
        await _databaseContext.SaveChangesAsync();

        leaveType.DateModified.ShouldNotBeNull();
    }
}
