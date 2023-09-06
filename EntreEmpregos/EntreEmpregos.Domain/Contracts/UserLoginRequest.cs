using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Contracts;

public class UserLoginRequest
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required] public string Password { get; set; } = string.Empty;
}