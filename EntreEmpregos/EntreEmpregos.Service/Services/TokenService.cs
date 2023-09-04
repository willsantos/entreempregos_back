using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EntreEmpregos.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EntreEmpregos.Service.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Generate(User user)
    {
        if (_configuration["APP_SALT"] is null)
            throw new ApplicationException(
                "Salt é obrigatorio para gerar o token");
        var salt = _configuration["APP_SALT"];

        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(salt!);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(descriptor);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));

        return claims;
    }
}