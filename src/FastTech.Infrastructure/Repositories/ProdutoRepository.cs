using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;

namespace FastTech.Infrastructure.Repositories;

internal class ProdutoRepository : IProdutoRepository
{
    public Task<IEnumerable<Produto>> BuscarTodos()
    {
        throw new NotImplementedException();
    }
}
