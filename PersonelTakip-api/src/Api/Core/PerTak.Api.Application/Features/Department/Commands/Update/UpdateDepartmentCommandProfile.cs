using AutoMapper;
using PerTak.Api.Domain.Models;

namespace PerTak.Api.Application.Features.Department.Commands.Update;

public class UpdateDepartmentCommandProfile : Profile
{
    public UpdateDepartmentCommandProfile()
    {
        CreateMap<UpdateDepartmentCommandRequest, Departmen>();
    }
}