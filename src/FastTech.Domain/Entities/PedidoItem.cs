using FastTech.Domain.Common;

namespace FastTech.Domain.Entities;

internal class PedidoItem : Entity
{

    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public string? NomeProduto { get; private set; }
    public Pedido? Pedido { get; set; }

    public PedidoItem(Guid pedidoId, string nomeProduto, int quantidade, decimal valorUnitario)
    {
        PedidoId = pedidoId;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;

        Validar();
    }

    public void VincularPedido(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }
    public decimal CalcularValor()
    {
        return Quantidade * ValorUnitario;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        Quantidade += quantidade;
    }

    public void AtualizarQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }

    protected override void Validar()
    {
        if (ProdutoId == Guid.Empty)
            throw new DomainException("Id do produto inválido");

        if (Quantidade <= 0)
            throw new DomainException("Quantidade deve ser maior que 0.");

        if (ValorUnitario <= 0)
            throw new DomainException("Valor Unitário deve ser maior que 0.");

        if (String.IsNullOrWhiteSpace(NomeProduto))
            throw new DomainException("Nome inválido.");
    }
}
