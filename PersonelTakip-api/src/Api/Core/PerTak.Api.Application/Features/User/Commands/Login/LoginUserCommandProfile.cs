using AutoMapper;

namespace PerTak.Api.Application.Features.User.Commands.Login;

public class LoginUserCommandProfile : Profile
{
    public LoginUserCommandProfile()
    {
        CreateMap<Domain.Models.User, LoginUserCommandResponse>().ReverseMap();
    }
}