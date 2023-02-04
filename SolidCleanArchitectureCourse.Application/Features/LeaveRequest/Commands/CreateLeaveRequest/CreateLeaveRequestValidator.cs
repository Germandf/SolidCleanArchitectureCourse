using FluentValidation;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Shared;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
    }
}
