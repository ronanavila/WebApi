using FastTech.Domain.Enum;
using MediatR;

namespace FastTech.Aplication.Services.ProductHandlers;

public class RegisterProductRequest : IRequest<bool>
{ 
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public TipoProduto Tipo { get; private set; }
    public int QuantidadeEstoque { get; private set; }

    public RegisterProductRequest(string? nome, string? descricao, decimal valor, TipoProduto tipo, int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tipo = tipo;
        QuantidadeEstoque = quantidadeEstoque;
    }
}
