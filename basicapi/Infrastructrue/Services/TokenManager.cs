using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using basicapi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

public class TokenManager : ITokenManager
{
    private readonly IConfiguration _configuration;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private string GenerateToken(User user, int expirationMinutes = 30)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("name", user.Name ?? string.Empty),
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email ?? string.Empty),
            new Claim("scope", "api.readwrite")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["IdentityServer:IssuerSigningKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["IdentityServer:Authority"],
            audience: _configuration["IdentityServer:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(expirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Task<string> GenerateTokenAsync(User user)
    {
        return Task.FromResult(GenerateToken(user));
    }

    public Task<User?> GetUserFromTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<string> RefreshTokenAsync(string token)
    {
        throw new NotImplementedException();
    }
}