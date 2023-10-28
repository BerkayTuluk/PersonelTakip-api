using AutoMapper;
using MediatR;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Common.Infrastructure.Exceptions;

namespace PerTak.Api.Application.Features.Work.Commands.Update;

public class UpdateWorkCommandHandler : IRequestHandler<UpdateWorkCommandRequest, Guid>
{
    private readonly IMapper _mapper;
    private readonly IWorkRepository _workRepository;

    public UpdateWorkCommandHandler(IMapper mapper, IWorkRepository workRepository)
    {
        _mapper = mapper;
        _workRepository = workRepository;
    }

    public async Task<Guid> Handle(UpdateWorkCommandRequest request, CancellationToken cancellationToken)
    {
        var dbWork = await _workRepository.GetByIdAsync(request.Id);

        if (dbWork is null)
            throw new DatabaseValidationException("Work not found!");

        _mapper.Map<Domain.Models.Work>(request);
        await _workRepository.UpdateAsync(dbWork);

        return dbWork.Id;
    }
}