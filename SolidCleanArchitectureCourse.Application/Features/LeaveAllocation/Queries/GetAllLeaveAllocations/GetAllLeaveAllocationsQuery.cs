using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public record GetAllLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>;
