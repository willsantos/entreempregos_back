using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Entities;

public class TransmissionGroup
{
    public Guid Id { get; set; }

    [StringLength(20)]
    public string GroupId { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime DeletedAt { get; set; }
}