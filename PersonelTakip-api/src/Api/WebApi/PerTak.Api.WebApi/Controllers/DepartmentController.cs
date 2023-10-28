using MediatR;
using Microsoft.AspNetCore.Mvc;
using PerTak.Api.Application.Features.Department.Commands.Create;

namespace PerTak.Api.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class DepartmentController : Controller
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentCommandRequest command)
    {
        var res = await _mediator.Send(command);

        return Ok(res);
    }
}