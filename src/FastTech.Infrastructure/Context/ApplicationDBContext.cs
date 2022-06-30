using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Context;

public class ApplicationDBContext : DbContext, IUnityOfWork
{
    public DbSet<Product> Produtos { get; set; }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(x => Console.WriteLine(x))
            .EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .AreUnicode(false)
            .HaveColumnType("varchar(400)");

        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task Commit()
    {
        foreach (var entry in ChangeTracker.Entries()
                                .Where(x => x.Entity.GetType().GetProperty("Cadastro") != null))
        {
            if (entry.State == EntityState.Modified)
                entry.Property("Cadastro").IsModified = false;
        }

        await SaveChangesAsync();
    }
}
