namespace FastTech.Domain.Common;
internal abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected Guid Id { get; private set; }

    protected abstract void Validar();
}

