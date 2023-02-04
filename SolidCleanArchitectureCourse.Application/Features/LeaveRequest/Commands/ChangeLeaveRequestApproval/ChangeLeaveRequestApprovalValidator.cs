using FluentValidation;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
{
	public ChangeLeaveRequestApprovalValidator()
	{
		RuleFor(x => x.Approved)
			.NotNull()
			.WithMessage("Approval status cannot be null");
	}
}
