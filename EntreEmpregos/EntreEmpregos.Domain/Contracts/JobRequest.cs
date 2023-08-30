using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Enums;

namespace EntreEmpregos.Domain.Contracts;

public class JobRequest
{
    [Required] public DateTime Publication { get; set; }

    [Required]
    [StringLength(60)]
    public string Position { get; set; } = string.Empty;

    [Required] public JobFormat Format { get; set; }

    [Required] public JobContract Contract { get; set; }

    [Required] public Guid LevelId { get; set; }

    [Required] public Guid RegionId { get; set; }

    [Required] public Guid EmployerId { get; set; }

    [StringLength(200)] public string Link { get; set; } = string.Empty;

    public bool Exclusivo { get; set; }
}