using FastTech.Domain.Entities;
using FastTech.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Context;

public class ApplicationDBContext : DbContext
{
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .AreUnicode(false)
            .HaveColumnType("varchar(400)");
        
        base.ConfigureConventions(configurationBuilder);   
    }

    public DbSet<Produto> Produtos { get; set; }

}
