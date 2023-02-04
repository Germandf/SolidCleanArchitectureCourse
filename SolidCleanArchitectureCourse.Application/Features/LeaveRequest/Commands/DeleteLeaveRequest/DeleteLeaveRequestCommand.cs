using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public record DeleteLeaveRequestCommand(int Id) : IRequest<Unit>;
