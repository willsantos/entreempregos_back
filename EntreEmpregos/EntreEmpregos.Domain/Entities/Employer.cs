using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Entities;

public class Employer
{
    public Guid Id { get; set; }

    [StringLength(60)] public string Name { get; set; } = string.Empty;

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime DeletedAt { get; set; }

    //public IList<Job> Jobs { get; set; }
}