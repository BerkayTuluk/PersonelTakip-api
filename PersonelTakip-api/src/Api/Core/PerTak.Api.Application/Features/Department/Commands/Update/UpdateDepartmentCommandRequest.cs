using MediatR;

namespace PerTak.Api.Application.Features.Department.Commands.Update;

public class UpdateDepartmentCommandRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string DepartmenName { get; set; }
}