using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Entities;

public abstract class Entity
{
    [Key] public Guid Id { get; set; }

    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; private set; }

    public DateTime? DeletedAt { get; private set; }
}