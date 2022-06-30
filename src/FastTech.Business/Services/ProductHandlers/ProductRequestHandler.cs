using AutoMapper;
using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using MediatR;

namespace FastTech.Aplication.Services.ProductHandlers;

public class ProductRequestHandler : MainHandler, IRequestHandler<RegisterProductRequest, bool>
{
    private readonly IProdutoRepository _produtoRepository;


    public ProductRequestHandler(IProdutoRepository produtoRepository, IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> Handle(RegisterProductRequest request, CancellationToken cancellationToken)
    {
        var result = Validar(request, new RegisterProductRequestValidator());

        if (!result)
            return false;

        var produto = Mapper.Map<Product>(request);

        await _produtoRepository.RegisterProduct(produto);
        await _produtoRepository.UnityOfWork.Commit();

        return true;
    }

}
