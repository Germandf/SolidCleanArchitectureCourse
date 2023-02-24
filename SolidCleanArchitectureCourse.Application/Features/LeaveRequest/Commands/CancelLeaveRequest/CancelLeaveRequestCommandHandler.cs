using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Email;
using SolidCleanArchitectureCourse.Application.Contracts.Logging;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Application.Exceptions;
using SolidCleanArchitectureCourse.Application.Models.Email;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<CancelLeaveRequestCommandHandler> _logger;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CancelLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IEmailSender emailSender,
        IAppLogger<CancelLeaveRequestCommandHandler> logger,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
        _logger = logger;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
        }

        leaveRequest.Cancelled = true;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        if (leaveRequest.Approved == true)
        {
            int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

            var allocation = await _leaveAllocationRepository.GetUserAllocations(
                leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

            allocation.NumberOfDays += daysRequested;
            await _leaveAllocationRepository.UpdateAsync(allocation);
        }

        var email = new EmailMessage
        {
            To = "",
            Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                   $"has been cancelled successfully",
            Subject = "Leave Request Cancelled"
        };

        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}
