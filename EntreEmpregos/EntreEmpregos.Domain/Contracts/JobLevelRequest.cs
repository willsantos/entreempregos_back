using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Contracts;

public class JobLevelRequest
{
    [Required] [StringLength(60)] public string Description { get; set; }
}