using Moq;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Domain;

namespace SolidCleanArchitectureCourse.UnitTests.Mocks;

public class LeaveTypeRepositoryMock
{
    public static Mock<ILeaveTypeRepository> Get()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            },
            new LeaveType
            {
                Id = 2,
                DefaultDays = 15,
                Name = "Test Sick"
            },
            new LeaveType
            {
                Id = 3,
                DefaultDays = 15,
                Name = "Test Maternity"
            },
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(x => x.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return Task.CompletedTask;
        });

        return mockRepo;
    }
}
