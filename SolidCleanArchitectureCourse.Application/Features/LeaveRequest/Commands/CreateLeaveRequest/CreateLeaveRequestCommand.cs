using MediatR;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Shared;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public record CreateLeaveRequestCommand(string RequestComments, DateTime StartDate, DateTime EndDate, int LeaveTypeId) 
    : BaseLeaveRequest(StartDate, EndDate, LeaveTypeId), IRequest<Unit>;
