using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Email;
using SolidCleanArchitectureCourse.Application.Contracts.Logging;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Application.Exceptions;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using SolidCleanArchitectureCourse.Application.Models.Email;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<ChangeLeaveRequestApprovalCommandHandler> _logger;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public ChangeLeaveRequestApprovalCommandHandler(
        IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IEmailSender emailSender,
        IAppLogger<ChangeLeaveRequestApprovalCommandHandler> logger,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
        _logger = logger;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var validator = new ChangeLeaveRequestApprovalValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Leave Request Approval", validationResult);
        }

        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
        }

        leaveRequest.Approved = request.Approved;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        if (request.Approved)
        {
            var daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

            var leaveAllocation = await _leaveAllocationRepository.GetUserAllocations(
                leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

            leaveAllocation.NumberOfDays -= daysRequested;
            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
        }

        var email = new EmailMessage
        {
            To = "",
            Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                   $"has been updated",
            Subject = "Leave Request Approval Status Updated"
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
