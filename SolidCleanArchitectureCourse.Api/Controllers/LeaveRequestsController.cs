using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using SolidCleanArchitectureCourse.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

namespace SolidCleanArchitectureCourse.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<LeaveRequestDto>> Get()
    {
        return await _mediator.Send(new GetAllLeaveRequestsQuery());
    }

    [HttpGet("{id}")]
    public async Task<LeaveRequestDetailsDto> Get(int id)
    {
        return await _mediator.Send(new GetLeaveRequestDetailsQuery(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestCommand request)
    {
        return CreatedAtAction(nameof(Get), new { id = await _mediator.Send(request) });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveRequestCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpPut]
    [Route("CancelRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelRequest([FromBody] CancelLeaveRequestCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpPut]
    [Route("UpdateApproval")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateApproval([FromBody] ChangeLeaveRequestApprovalCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveRequestCommand(id));
        return NoContent();
    }
}
