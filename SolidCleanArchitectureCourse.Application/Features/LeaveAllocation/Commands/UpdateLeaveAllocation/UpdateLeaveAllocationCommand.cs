using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public record UpdateLeaveAllocationCommand(int Id, int NumberOfDays, int LeaveTypeId, int Period) : IRequest<Unit>;
