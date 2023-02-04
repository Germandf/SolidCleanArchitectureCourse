using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public record CreateLeaveAllocationCommand(int LeaveTypeId) : IRequest<Unit>;
