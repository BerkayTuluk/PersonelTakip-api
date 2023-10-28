using AutoMapper;
using PerTak.Api.Domain.Models;

namespace PerTak.Api.Application.Features.Department.Commands.Create;

public class CreateDepartmentCommandProfile : Profile
{
    public CreateDepartmentCommandProfile()
    {
        CreateMap<CreateDepartmentCommandRequest, Departmen>();
    }
}