using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using SolidCleanArchitectureCourse.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

namespace SolidCleanArchitectureCourse.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<LeaveAllocationDto>> Get()
    {
        return await _mediator.Send(new GetAllLeaveAllocationsQuery());
    }

    [HttpGet("{id}")]
    public async Task<LeaveAllocationDetailsDto> Get(int id)
    {
        return await _mediator.Send(new GetLeaveAllocationDetailsQuery(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationCommand request)
    {
        return CreatedAtAction(nameof(Get), new { id = await _mediator.Send(request) });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationCommand request)
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
        await _mediator.Send(new DeleteLeaveAllocationCommand(id));
        return NoContent();
    }
}
