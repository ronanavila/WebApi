using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDBContext _applicationDBContext;

    public ProdutoRepository(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task<IEnumerable<Produto>> BuscarTodosAsync()
    {
        return await _applicationDBContext.Produtos
            .Where(p => p.Ativo == true).ToListAsync();
    }
}
