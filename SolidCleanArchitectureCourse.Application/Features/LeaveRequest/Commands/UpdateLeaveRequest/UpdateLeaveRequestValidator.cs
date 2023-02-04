using FluentValidation;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Shared;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestValidator(
        ILeaveTypeRepository leaveTypeRepository, 
        ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;

        Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(LeaveRequestMustExist)
            .WithMessage("{PropertyName} must be present");
    }

    private async Task<bool> LeaveRequestMustExist(int id, CancellationToken token)
    {
        var leaveAllocation = await _leaveRequestRepository.GetByIdAsync(id);
        return leaveAllocation is not null;
    }
}
