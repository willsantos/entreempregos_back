using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Contracts;

public class UserRequest
{
    [StringLength(60)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required] public string Password { get; set; } = string.Empty;
}