using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using SolidCleanArchitectureCourse.Application.Contracts.Identity;
using SolidCleanArchitectureCourse.Domain;
using SolidCleanArchitectureCourse.Persistence.DatabaseContexts;

namespace SolidCleanArchitectureCrouse.IntegrationTests;

public class DatabaseContextTests
{
    private DatabaseContext _databaseContext;
    private readonly string _userId;
    private readonly Mock<IUserService> _userServiceMock;

    public DatabaseContextTests()
	{
		var dbOptions = new DbContextOptionsBuilder<DatabaseContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _userId = "00000000-0000-0000-0000-000000000000";
        _userServiceMock = new Mock<IUserService>();
        _userServiceMock.Setup(m => m.UserId).Returns(_userId);

        _databaseContext = new DatabaseContext(dbOptions, _userServiceMock.Object);
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
