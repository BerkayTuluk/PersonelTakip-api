using AutoMapper;
using MediatR;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Api.Domain.Models;
using PerTak.Common.Infrastructure.Exceptions;

namespace PerTak.Api.Application.Features.Department.Commands.Create;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, Guid>
{
    private readonly IMapper _mapper;
    private readonly IDepartmenRepository _departmenRepository;

    public CreateDepartmentCommandHandler(IMapper mapper, IDepartmenRepository departmenRepository)
    {
        _mapper = mapper;
        _departmenRepository = departmenRepository;
    }

    public async Task<Guid> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var existsDepartment = await _departmenRepository.GetSingleAsync(i => i.DepartmenName == request.DepartmenName);
        if (existsDepartment is not null)
            throw new DatabaseValidationException("Department already exists!");

        var dbDepartment = _mapper.Map<Departmen>(request);

        await _departmenRepository.AddAsync(dbDepartment);

        return dbDepartment.Id;
    }
}