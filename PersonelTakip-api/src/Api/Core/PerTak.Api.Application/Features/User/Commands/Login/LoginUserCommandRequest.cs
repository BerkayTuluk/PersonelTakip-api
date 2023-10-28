using MediatR;

namespace PerTak.Api.Application.Features.User.Commands.Login;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public LoginUserCommandRequest(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }

    public LoginUserCommandRequest()
    {
    }
}