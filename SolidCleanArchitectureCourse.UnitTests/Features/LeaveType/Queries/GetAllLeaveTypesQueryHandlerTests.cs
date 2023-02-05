using AutoMapper;
using Moq;
using Shouldly;
using SolidCleanArchitectureCourse.Application.Contracts.Logging;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using SolidCleanArchitectureCourse.Application.MappingProfiles;
using SolidCleanArchitectureCourse.UnitTests.Mocks;

namespace SolidCleanArchitectureCourse.UnitTests.Features.LeaveType.Queries;

public class GetAllLeaveTypesQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
	private readonly Mock<IAppLogger<GetAllLeaveTypesQueryHandler>> _mockAppLogger;

	public GetAllLeaveTypesQueryHandlerTests()
	{
        _mapper = new MapperConfiguration(x => x.AddProfile<LeaveTypeProfile>()).CreateMapper();
        _mockRepo = LeaveTypeRepositoryMock.Get();
		_mockAppLogger = new Mock<IAppLogger<GetAllLeaveTypesQueryHandler>>();
    }

	[Fact]
	public async Task GetAllLeaveTypesTest()
	{
		var handler = new GetAllLeaveTypesQueryHandler(
			_mapper, _mockRepo.Object, _mockAppLogger.Object);

		var result = await handler.Handle(new GetAllLeaveTypesQuery(), default);

		result.ShouldBeOfType<List<LeaveTypeDto>>();
		result.Count.ShouldBe(3);
	}
}
