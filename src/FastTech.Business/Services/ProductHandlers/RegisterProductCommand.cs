using FastTech.Core.Messages;
using FastTech.Domain.Enum;

namespace FastTech.Aplication.Services.ProductHandlers;

public class RegisterProductCommand : BaseCommand
{
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public TipoProduto Tipo { get; private set; }
    public int QuantidadeEstoque { get; private set; }

    public RegisterProductCommand(string? nome, string? descricao, decimal valor, TipoProduto tipo, int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tipo = tipo;
        QuantidadeEstoque = quantidadeEstoque;
    }
}
