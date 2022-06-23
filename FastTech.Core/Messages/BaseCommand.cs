using MediatR;

namespace FastTech.Core.Messages;

public abstract class BaseCommand : IRequest<bool>
{
    public Guid AggregateId { get; set; }
    public string TipoCommando { get; set; }
    public DateTime Criacao { get; set; }

    protected BaseCommand()
    {
        Criacao = DateTime.UtcNow;
        TipoCommando = GetType().Name;
    }
}
