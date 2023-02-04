using MediatR;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Shared;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public record UpdateLeaveRequestCommand(int Id, string RequestComments, bool Cancelled, DateTime StartDate, DateTime EndDate, int LeaveTypeId)
    : BaseLeaveRequest(StartDate, EndDate, LeaveTypeId), IRequest<Unit>;
