using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Contracts;

public class JobRegionRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(3,ErrorMessage = "Sigla deve ter no máximo 3 caracteres")] 
    public string Abbr { get; set; } = string.Empty;
    
}