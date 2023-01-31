using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
