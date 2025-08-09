using basicapi.Domain.Entities;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task UpdateAsync(User user);   
    Task CreateUserAsync(User user);
}
