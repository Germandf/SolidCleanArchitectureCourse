using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.Commands.DeleteLeaveType;

public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
