using AutoMapper;

namespace PerTak.Api.Application.Features.Work.Commands.Create;

public class CreateWorkCommandProfile : Profile
{
    public CreateWorkCommandProfile()
    {
        CreateMap<CreateWorkCommandRequest, Domain.Models.Work>();
    }
}