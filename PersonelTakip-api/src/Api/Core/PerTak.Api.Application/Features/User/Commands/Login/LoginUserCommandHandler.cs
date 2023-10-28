using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Common.Infrastructure;
using PerTak.Common.Infrastructure.Exceptions;

namespace PerTak.Api.Application.Features.User.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }


    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

        if (dbUser == null)
            throw new DatabaseValidationException("User not found!");

        var pass = PasswordEncryptor.Encrpt(request.Password);
        if (dbUser.Password != pass)
            throw new DatabaseValidationException("Password is wrong!");
        var result = _mapper.Map<LoginUserCommandResponse>(dbUser);
        
        var claims = new Claim[] 
        {
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Email, dbUser.EmailAddress),
            new Claim(ClaimTypes.Name, dbUser.UserName),
            new Claim(ClaimTypes.GivenName, dbUser.FirstName),
            new Claim(ClaimTypes.Surname, dbUser.LastName)
        };

        result.Token = GenerateToken(claims);

        return result;
    }
    
    private string GenerateToken(Claim[] claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthConfig:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(10);

        var token = new JwtSecurityToken(claims: claims,
            expires: expiry,
            signingCredentials: creds,
            notBefore: DateTime.Now);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}