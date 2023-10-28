using AutoMapper;
using MediatR;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Api.Domain.Models;
using PerTak.Common.Infrastructure.Exceptions;

namespace PerTak.Api.Application.Features.Department.Commands.Update;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, Guid>
{
    private readonly IMapper _mapper;
    private readonly IDepartmenRepository _departmenRepository;

    public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmenRepository departmenRepository)
    {
        _mapper = mapper;
        _departmenRepository = departmenRepository;
    }

    public async Task<Guid> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var dbDepartment = await _departmenRepository.GetByIdAsync(request.Id);

        if (dbDepartment is null)
            throw new DatabaseValidationException("Department not found!");

        var dbDepartmentName = dbDepartment.DepartmenName;
        var departmentNameChanged = string.CompareOrdinal(dbDepartmentName, request.DepartmenName);

        _mapper.Map<Departmen>(request);
        
        await _departmenRepository.UpdateAsync(dbDepartment);

        return dbDepartment.Id;
    }
}