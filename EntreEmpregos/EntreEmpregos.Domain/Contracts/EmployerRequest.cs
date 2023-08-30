using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Contracts;

public class EmployerRequest
{
    [Required]
    [StringLength(60)]
    public string Name { get; set; } = string.Empty;
}