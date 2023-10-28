using AutoMapper;

namespace PerTak.Api.Application.Features.Work.Commands.Update;

public class UpdateWorkCommandProfile : Profile
{
    public UpdateWorkCommandProfile()
    {
        CreateMap<UpdateWorkCommandRequest, Domain.Models.Work>();
    }
}