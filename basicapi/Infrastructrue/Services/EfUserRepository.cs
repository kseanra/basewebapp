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

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id) ?? throw new NotFoundException("User", id);
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

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("User", id);
            }
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return GetAllAsync();
        }

        public Task<User> GetUserByIdAsync(Guid id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateUserAsync(User user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password ?? string.Empty);
            return AddAsync(user);
        }

        public async Task<User?> GetUserByEmailAsync(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string? email, string? password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null && PasswordHasher.VerifyPassword(password, user.Password ?? ""))
            {
                return user;
            }
            return null;
        }
    }
}
