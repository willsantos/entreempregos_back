using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using EntreEmpregos.Domain.Contracts;
using EntreEmpregos.Domain.Entities;
using EntreEmpregos.Domain.Interfaces;

namespace EntreEmpregos.Service.Services;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _repository;
    private readonly TokenService _tokenService;

    public UserLoginService(IUserRepository repository,
        TokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<string> AuthenticateAsync(UserLoginRequest request)
    {
        ValidateRequest(request);
        var response =
            await _repository.FindAsync(prop => prop.Email == request.Email);
        if (response is null)
            throw new AuthenticationException("Usuario ou senha invalidos");
        if (!ValidatePassword(request, response))
            throw new AuthenticationException("usuario ou senha invalidos");

        return _tokenService.Generate(response);
    }


    private static void ValidateRequest(UserLoginRequest request)
    {
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(request,
            new ValidationContext(request), validationResults, true);

        if (isValid) return;
        var errorMessages = validationResults.Select(x => x.ErrorMessage);
        throw new ValidationException(string.Join("\n", errorMessages));
    }

    private static bool ValidatePassword(UserLoginRequest request, User entity)
    {
        return BCrypt.Net.BCrypt.Verify(request.Password, entity.Password);
    }
}