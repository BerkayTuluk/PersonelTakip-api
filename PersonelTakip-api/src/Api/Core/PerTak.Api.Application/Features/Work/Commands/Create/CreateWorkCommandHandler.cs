using AutoMapper;
using MediatR;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Common.Infrastructure.Exceptions;

namespace PerTak.Api.Application.Features.Work.Commands.Create;

public class CreateWorkCommandHandler : IRequestHandler<CreateWorkCommandRequest, Guid>
{
    private readonly IMapper _mapper;
    private readonly IWorkRepository _workRepository;

    public CreateWorkCommandHandler(IMapper mapper, IWorkRepository workRepository)
    {
        _mapper = mapper;
        _workRepository = workRepository;
    }

    public async Task<Guid> Handle(CreateWorkCommandRequest request, CancellationToken cancellationToken)
    {
        var existsWork = await _workRepository.GetSingleAsync(x => x.WorkerName == request.WorkerName);

        if (existsWork is not null)
            throw new DatabaseValidationException("Work already exists!");

        var dbWork = _mapper.Map<Domain.Models.Work>(request);

        await _workRepository.AddAsync(dbWork);

        return dbWork.Id;
    }
}