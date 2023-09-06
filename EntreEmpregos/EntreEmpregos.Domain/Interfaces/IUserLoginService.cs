using EntreEmpregos.Domain.Contracts;

namespace EntreEmpregos.Domain.Interfaces;

public interface IUserLoginService
{
    Task<TokenResponse> AuthenticateAsync(UserLoginRequest request);
}