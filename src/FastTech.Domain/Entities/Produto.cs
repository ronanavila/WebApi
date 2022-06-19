using FastTech.Domain.Common;
using FastTech.Domain.Enum;

namespace FastTech.Domain.Entities;
internal class Produto : Entity
{
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime Cadastro { get; private set; }
    public TipoProduto Tipo { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public bool Ativo { get; private set; }

    public Produto(string nome, string descricao, decimal valor, DateTime cadastro,
      TipoProduto tipo, int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Cadastro = DateTime.UtcNow;
        Tipo = tipo;
        QuantidadeEstoque = quantidadeEstoque;
        Ativo = true;

        Validar();
    }

    public void Ativar() => Ativo = true;
    public void Desativar() => Ativo = false;
    public void AlterarTipo(TipoProduto novoTipo) => Tipo = novoTipo;
    public void AlterarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new DomainException("Nome Inválido.");

        Nome = novoNome;
    }

    public void AlterarDescricao(string novaDescricao)
    {
        if (string.IsNullOrWhiteSpace(novaDescricao))
            throw new DomainException("Descrição Inválida");

        Descricao = novaDescricao;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade < 0)
            throw new DomainException("Quantidade Inválida.");
        if (!PossuiEstoque(quantidade))
        {
            throw new DomainException("Quantidade Insuficiente");
        }

        QuantidadeEstoque -= quantidade;
    }

    public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;

    public void AdicionarEstoque(int quantidade) => QuantidadeEstoque += quantidade;

    protected override void Validar()
    {
        if (String.IsNullOrWhiteSpace(Nome))
            throw new DomainException("O nome não pode ser vazio.");

        if (String.IsNullOrWhiteSpace(Descricao))
            throw new DomainException("O descrição não pode ser vazio.");

        if (Valor <= 0)
            throw new DomainException("O valor não pode ser menor ou igual a 0.");

        if (Cadastro.Date < DateTime.UtcNow.Date)
            throw new DomainException("O produto não pode ser cadastrado com data retroativa.");

        if (QuantidadeEstoque < 0)
            throw new DomainException("O produto não pode ser cadastrado com quantidade negativa.");
    }
}
