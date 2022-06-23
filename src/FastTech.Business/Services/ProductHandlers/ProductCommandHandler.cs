using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using MediatR;

namespace FastTech.Aplication.Services.ProductHandlers;

public class ProductCommandHandler : IRequestHandler<RegisterProductCommand, bool>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProductCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto(request.Nome, request.Descricao, request.Valor, 
            request.Tipo, request.QuantidadeEstoque);

        await _produtoRepository.RegisterProduct(produto);
        return true;
    }
}
