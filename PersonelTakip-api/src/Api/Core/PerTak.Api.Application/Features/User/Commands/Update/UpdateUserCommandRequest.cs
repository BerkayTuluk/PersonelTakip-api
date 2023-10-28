using MediatR;

namespace PerTak.Api.Application.Features.User.Commands.Update;

public class UpdateUserCommandRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }


    public string EmailAddress { get; set; }

    public string UserName { get; set; }
}