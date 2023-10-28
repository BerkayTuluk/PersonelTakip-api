using Microsoft.EntityFrameworkCore;
using PerTak.Api.Application.Interfaces.Repositories;
using PerTak.Api.Domain.Models;
using PerTak.Infrastructure.Persistence.Context;

namespace PerTak.Infrastructure.Persistence.Repositories;

public class WorkRepository : GenericRepository<Work>, IWorkRepository
{
    public WorkRepository(PerTakDbContext dbContext) : base(dbContext)
    {
    }
}