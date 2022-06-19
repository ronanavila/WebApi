namespace FastTech.Domain.Entidades;
internal abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected Guid Id { get; private set; }
}

