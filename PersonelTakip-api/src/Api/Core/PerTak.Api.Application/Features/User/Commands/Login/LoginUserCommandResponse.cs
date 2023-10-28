namespace PerTak.Api.Application.Features.User.Commands.Login;

public class LoginUserCommandResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }
    
    public string Token { get; set; }
}