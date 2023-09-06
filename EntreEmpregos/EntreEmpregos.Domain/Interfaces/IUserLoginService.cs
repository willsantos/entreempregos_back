using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IUserLoginService
{
    Task<string> AuthenticateAsync(UserLoginRequest request);
}