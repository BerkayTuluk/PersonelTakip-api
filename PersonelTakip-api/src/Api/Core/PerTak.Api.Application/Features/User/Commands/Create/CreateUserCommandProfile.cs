using AutoMapper;

namespace PerTak.Api.Application.Features.User.Commands.Create;

public class CreateUserCommandProfile : Profile
{
    public CreateUserCommandProfile()
    {
        CreateMap<CreateUserCommandRequest, Domain.Models.User>();
    }
}