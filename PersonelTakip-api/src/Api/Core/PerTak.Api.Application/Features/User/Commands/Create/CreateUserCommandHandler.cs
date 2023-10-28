using AutoMapper;
using MediatR;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Common.Infrastructure;
using PerTak.Common.Infrastructure.Exceptions;

namespace PerTak.Api.Application.Features.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        _userRepository = userRepository;
    }


    public async Task<Guid> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var existsUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (existsUser is not null)
            throw new DatabaseValidationException("User already exists!");
        
        request.Password = PasswordEncryptor.Encrpt(request.Password);
        
        var dbUser = mapper.Map<Domain.Models.User>(request);

        var rows = await _userRepository.AddAsync(dbUser);

        return dbUser.Id;
    }
}