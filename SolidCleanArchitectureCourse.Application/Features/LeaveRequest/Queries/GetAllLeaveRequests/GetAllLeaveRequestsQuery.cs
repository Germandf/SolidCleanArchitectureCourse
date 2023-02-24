using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;

public record GetAllLeaveRequestsQuery(bool IsLoggedInUser) : IRequest<List<LeaveRequestDto>>;
