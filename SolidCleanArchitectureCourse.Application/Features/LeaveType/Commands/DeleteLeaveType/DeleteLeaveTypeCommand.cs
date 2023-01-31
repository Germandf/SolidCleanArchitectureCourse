using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.DeleteLeaveType;

public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
