using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Contracts;

public class TransGroupRequest
{
    [Required]
    [StringLength(20)]
    public string GroupId { get; set; } = string.Empty;

    //Provavelmente essa info pode ser retirada do response.

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}