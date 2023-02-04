using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public record DeleteLeaveAllocationCommand(int Id) : IRequest<Unit>;
