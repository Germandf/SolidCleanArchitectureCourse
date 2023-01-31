using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.Queries.GetAllLeaveTypes;

public record GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
