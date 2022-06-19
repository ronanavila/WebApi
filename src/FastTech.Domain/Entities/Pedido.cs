using FastTech.Domain.Common;
using FastTech.Domain.Enum;

namespace FastTech.Domain.Entities;

internal class Pedido : Entity
{
    public DateTime Cadastro { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }

    private List<PedidoItem> _pedidoItems;
    public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItems;

    public Pedido()
    {
        _pedidoItems = new List<PedidoItem>();
        Cadastro = DateTime.UtcNow;
        Status = StatusPedido.Novo;
        Validar();
    }

    public void CalcularValorTotal()
    {
        ValorTotal = _pedidoItems.Sum(x => x.CalcularValor());
    }

    public void AdicionarItemNoPedido(PedidoItem pedidoItem)
    {
        pedidoItem.VincularPedido(Id);

        if (ExitePedidoItem(pedidoItem) is var itemEcontrado && itemEcontrado != null)
        {
            itemEcontrado.AdicionarQuantidade(pedidoItem.Quantidade);
            pedidoItem = itemEcontrado;
        }
        else
        {
            _pedidoItems.Add(pedidoItem);
        }

        pedidoItem.CalcularValor();
        CalcularValorTotal();
    }

    public void RemoverItem(PedidoItem pedidoItem)
    {
        if (ExitePedidoItem(pedidoItem) is var itemEncontrado && itemEncontrado == null)
        {
            throw new DomainException("O item não foi encontrato no pedido. Item Inválido.");
        }

        _pedidoItems.Remove(itemEncontrado);

        CalcularValorTotal();
    }

    public void AtualizarQuantidadeItem(PedidoItem pedidoItem, int novaQuantidade)
    {
        if (ExitePedidoItem(pedidoItem) is var itemEncontrado && itemEncontrado == null)
        {
            throw new DomainException("O item não foi encontrato no pedido. Item Inválido.");
        }

        itemEncontrado.AtualizarQuantidade(novaQuantidade);

        CalcularValorTotal();
    }

    public void AguardarPagamento()
    {
        Status = StatusPedido.AguardandoPagamento;
    }

    public void ConcluirPedido()
    {
        Status = StatusPedido.Concluido;
    }

    private PedidoItem ExitePedidoItem(PedidoItem item)
    {
        return _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
    }

    protected override void Validar()
    {
        if (Cadastro.Date <= DateTime.UtcNow.Date)
            throw new DomainException("Data inválida.");
    }
}
