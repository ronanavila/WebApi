using FastTech.Domain.DomainObjects;
using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace FastTech.Aplication.Services.ProductHandlers;

public class ProductRequestHandler : IRequestHandler<RegisterProductRequest, bool>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProductRequestHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> Handle(RegisterProductRequest request, CancellationToken cancellationToken)
    {
        var result = Validar(request, new RegisterProductRequestValidator());

        if(!result.IsValid)
        {
            return false;
        }

        var produto = new Produto(request.Nome, request.Descricao, request.Valor,
            request.Tipo, request.QuantidadeEstoque);

        await _produtoRepository.RegisterProduct(produto);

        return true;
    }

    private ValidationResult Validar<TEntity, TValidator>(TEntity entity, TValidator validator)
        where TEntity : class where TValidator : AbstractValidator<TEntity>
    {
        return validator.Validate(entity);
    }
}
