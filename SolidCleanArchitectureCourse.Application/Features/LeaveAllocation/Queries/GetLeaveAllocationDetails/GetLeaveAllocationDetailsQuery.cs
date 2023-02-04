using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public record GetLeaveAllocationDetailsQuery(int Id) : IRequest<LeaveAllocationDetailsDto>;
