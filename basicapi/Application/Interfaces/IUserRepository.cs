using basicapi.Domain.Entities;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task CreateUserAsync(User user);
}
