using MediatR;

namespace PerTak.Api.Application.Features.Department.Commands.Create;

public class CreateDepartmentCommandRequest : IRequest<Guid>
{
    public string DepartmenName { get; set; }
}