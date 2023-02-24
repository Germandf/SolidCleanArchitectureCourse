using AutoMapper;
using MediatR;
using SolidCleanArchitectureCourse.Application.Contracts.Email;
using SolidCleanArchitectureCourse.Application.Contracts.Identity;
using SolidCleanArchitectureCourse.Application.Contracts.Logging;
using SolidCleanArchitectureCourse.Application.Contracts.Persistence;
using SolidCleanArchitectureCourse.Application.Exceptions;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using SolidCleanArchitectureCourse.Application.Models.Email;

namespace SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;
    private readonly IUserService _userService;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CreateLeaveRequestCommandHandler(
        IMapper mapper,
        IEmailSender emailSender,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<CreateLeaveRequestCommandHandler> logger,
        IUserService userService,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _emailSender = emailSender;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
        _userService = userService;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }

        var employeeId = _userService.UserId;
        var leaveAllocation = await _leaveAllocationRepository.GetUserAllocations(employeeId, request.LeaveTypeId);

        if (leaveAllocation is null)
        {
            validationResult.Errors.Add(new(nameof(request.LeaveTypeId), 
                "You do not have any allocations for this leave type."));

            throw new BadRequestException("Invalid Leave Request", validationResult);
        }

        var daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;

        if (daysRequested > leaveAllocation.NumberOfDays)
        {
            validationResult.Errors.Add(new(nameof(request.EndDate),
                "You do not have enough days for this request."));

            throw new BadRequestException("Invalid Leave Request", validationResult);
        }

        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
        leaveRequest.RequestingEmployeeId = employeeId;
        leaveRequest.DateRequested = DateTime.Now;
        await _leaveRequestRepository.CreateAsync(leaveRequest);

        var email = new EmailMessage
        {
            To = "",
            Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                   $"has been submitted successfully",
            Subject = "Leave Request Submitted"
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
