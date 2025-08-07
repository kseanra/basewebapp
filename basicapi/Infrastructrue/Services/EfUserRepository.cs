using basicapi.Data;
using basicapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace basicapi.Infrastructrue.Services
{
    public class EfUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public EfUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id) ?? new User();
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return GetAllAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateUserAsync(User user)
        {
            return AddAsync(user);
        }
    }
}
