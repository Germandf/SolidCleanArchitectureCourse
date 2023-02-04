using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;

public record GetAllLeaveRequestsQuery : IRequest<List<LeaveRequestDto>>;
