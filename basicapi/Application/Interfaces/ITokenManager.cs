using basicapi.Domain.Entities;

public interface ITokenManager
{
    Task<string> GenerateTokenAsync(User user);
    Task<string> RefreshTokenAsync(string token);
    Task<bool> ValidateTokenAsync(string token);
    Task<User?> GetUserFromTokenAsync(string token);
}