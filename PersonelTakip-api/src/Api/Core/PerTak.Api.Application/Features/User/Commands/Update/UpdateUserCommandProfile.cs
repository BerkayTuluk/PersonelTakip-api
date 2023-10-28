using AutoMapper;

namespace PerTak.Api.Application.Features.User.Commands.Update;

public class UpdateUserCommandProfile : Profile
{
    public UpdateUserCommandProfile()
    {
        CreateMap<UpdateUserCommandRequest, Domain.Models.User>();
    }
}