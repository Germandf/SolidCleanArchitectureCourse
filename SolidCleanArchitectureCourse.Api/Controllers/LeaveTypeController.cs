using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.CreateLeaveType;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.DeleteLeaveType;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Commands.UpdateLeaveType;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using SolidCleanArchitectureCourse.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

namespace SolidCleanArchitectureCourse.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<LeaveTypeDto>> Get()
    {
        return await _mediator.Send(new GetAllLeaveTypesQuery());
    }

    [HttpGet("{id}")]
    public async Task<LeaveTypeDetailsDto> Get(int id)
    {
        return await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeCommand request)
    {
        return CreatedAtAction(nameof(Get), new { id = await _mediator.Send(request) });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveTypeCommand request)
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
        await _mediator.Send(new DeleteLeaveTypeCommand(id));
        return NoContent();
    }
}
