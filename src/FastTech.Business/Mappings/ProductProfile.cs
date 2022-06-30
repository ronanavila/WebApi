using AutoMapper;
using FastTech.Aplication.Services.ProductHandlers;
using FastTech.Domain.Entities;

namespace FastTech.Aplication.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<RegisterProductRequest, Product>().ConstructUsing(request =>
        new Product(request.Nome, request.Descricao, request.Valor, request.Tipo, request.QuantidadeEstoque));
    }
}
