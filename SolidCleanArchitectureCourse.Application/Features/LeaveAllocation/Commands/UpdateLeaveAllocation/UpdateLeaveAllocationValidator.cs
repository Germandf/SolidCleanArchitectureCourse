using FluentValidation;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(x => x.NumberOfDays)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

        RuleFor(x => x.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("{PropertyName} does not exist");

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(LeaveAllocationMustExist)
            .WithMessage("{PropertyName} must be present");
    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType is not null;
    }

    private async Task<bool> LeaveAllocationMustExist(int id, CancellationToken token)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(id);
        return leaveAllocation is not null;
    }
}
