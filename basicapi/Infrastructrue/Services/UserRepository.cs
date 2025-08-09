namespace basicapi.Infrastructrue.Services
{
    using Dapper;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Threading.Tasks;
    using basicapi.Domain.Entities;
    using Microsoft.Extensions.Options;
    using basicapi.Configurations;

    public class UserRepository : IUserRepository
    {
        private readonly DbConfig _dbConfig;

        public UserRepository(IOptions<DbConfig> dbConfig)
        {
            _dbConfig = dbConfig.Value;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using var connection = new SQLiteConnection(_dbConfig.ConnectionString);
            return await connection.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            using var connection = new SQLiteConnection(_dbConfig.ConnectionString);
            return new User()
            {
                Id = Guid.NewGuid(), // Placeholder for actual implementation
                Name = "Sample User", // Placeholder for actual implementation
                Email = "sample@example.com"
            }; // Placeholder for actual implementation
            //return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
        }

        public async Task CreateUserAsync(User user)
        {
            using var connection = new SQLiteConnection(_dbConfig.ConnectionString);
            await connection.ExecuteAsync("INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", user);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}