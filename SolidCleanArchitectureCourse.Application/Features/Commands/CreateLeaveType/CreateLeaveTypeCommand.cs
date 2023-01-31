using MediatR;

namespace SolidCleanArchitectureCourse.Application.Features.Commands.CreateLeaveType;

public record CreateLeaveTypeCommand(string Name, int DefaultDays) : IRequest<int>;
