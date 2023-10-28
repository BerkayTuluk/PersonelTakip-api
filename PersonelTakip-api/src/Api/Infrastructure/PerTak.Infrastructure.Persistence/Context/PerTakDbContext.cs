using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PerTak.Api.Domain.Models;

namespace PerTak.Infrastructure.Persistence.Context;

public class PerTakDbContext : DbContext
{
	public const string DEFAULT_SCHEMA = "public";

	public PerTakDbContext()
	{

	}

    public PerTakDbContext(DbContextOptions options) : base(options)
    {
    }

	public DbSet<User> Users { get; set; }
	public DbSet<Work> Works { get; set; }
	public DbSet<Departmen> Departmens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connString = "User ID=postgres;Password=mysecretpassword;Server=localhost;Port=5432;Database=postgres;Integrated Security=true;Pooling=true;";
        optionsBuilder.UseNpgsql(connString, opt =>
        {
            opt.EnableRetryOnFailure();
        });
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntites = ChangeTracker.Entries()
                                .Where(i => i.State == EntityState.Added)
                                .Select(i => (BaseEntity)i.Entity);

        PrepareAddedEntities(addedEntites);
    }

    private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.CreateDate == DateTime.MinValue)
                entity.CreateDate = DateTime.UtcNow;
        }
    }
}

