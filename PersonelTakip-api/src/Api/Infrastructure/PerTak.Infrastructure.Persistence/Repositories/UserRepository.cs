using Microsoft.EntityFrameworkCore;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Api.Domain.Models;
using PerTak.Infrastructure.Persistence.Context;

namespace PerTak.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(PerTakDbContext dbContext) : base(dbContext)
    {
    }
}