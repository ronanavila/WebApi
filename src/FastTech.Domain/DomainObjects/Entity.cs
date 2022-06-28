namespace FastTech.Domain.DomainObjects;
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    protected abstract void Validar();
}

