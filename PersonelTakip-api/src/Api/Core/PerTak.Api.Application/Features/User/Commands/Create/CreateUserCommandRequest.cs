using MediatR;

namespace PerTak.Api.Application.Features.User.Commands.Create;

public class CreateUserCommandRequest : IRequest<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }


    public string EmailAddress { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
}