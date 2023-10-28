using MediatR;
using Microsoft.AspNetCore.Mvc;
using PerTak.Api.Application.Features.Work.Commands.Create;
using PerTak.Api.Application.Features.Work.Commands.Update;

namespace PerTak.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] CreateWorkCommandRequest command)
    {
        var res = await _mediator.Send(command);
        return Ok(res);
    }
    
    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateWorkCommandRequest command)
    {
        var res = await _mediator.Send(command);
        return Ok(res);
    }
}