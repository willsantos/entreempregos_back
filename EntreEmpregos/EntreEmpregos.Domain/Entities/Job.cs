using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Api.Entities;
using EntreEmpregos.Domain.Enums;

namespace EntreEmpregos.Domain.Entities;

public class Job : Entity
{
    public DateTime Publication { get; set; }

    [StringLength(60)] public string Position { get; set; } = string.Empty;

    public JobFormat Format { get; set; }

    public JobContract Contract { get; set; }

    public Guid LevelId { get; set; }
    public JobLevel Level { get; set; }


    public Guid RegionId { get; set; }
    public JobRegion Region { get; set; }

    public Guid EmployerId { get; set; }
    public Employer Employer { get; set; }

    [StringLength(200)] public string Link { get; set; } = string.Empty;

    public bool Exclusivo { get; set; }
}