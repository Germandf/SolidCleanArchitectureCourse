using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public record CancelLeaveRequestCommand(int Id) : IRequest<Unit>;
