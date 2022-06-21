﻿namespace FastTech.Domain.Common;
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    protected abstract void Validar();
}

