using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerTak.Api.Application.Features.User.Commands.Create;
using PerTak.Api.Application.Features.User.Commands.Login;
using PerTak.Api.Application.Features.User.Commands.Update;

namespace PerTak.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest command)
    {
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest command)
    {
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest command)
    {
        var res = await mediator.Send(command);
        return Ok(res);
    }
}