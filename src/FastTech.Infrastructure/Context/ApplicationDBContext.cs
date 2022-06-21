using FastTech.Domain.Entities;
using FastTech.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Context;

internal class ApplicationDBContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Produto> Produtos { get; set; }

}
