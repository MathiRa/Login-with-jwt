using ALUXION.Domain;
using ALUXION.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ALUXION.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ALUXIONContext _context;
        public UserRepository(ALUXIONContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            user.Id = await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmail(string email, bool active = true)
        {
            User user = new User();
            if (active)
            {
                user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.IsActive);
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            }
            return user;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmailAndToken(string email, string token)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Token == token);
        }

        public async Task ActiveUser(User user)
        {
            if (user != null)
            {
                user.IsActive = true;
                user.Token = string.Empty;
                user.Id = await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GenerateToken(User user)
        {
            if (user != null)
            {
                user.Token = Guid.NewGuid().ToString();
                user.Id = await _context.SaveChangesAsync();
            }

            return user.Token.ToString();
        }

        public async Task ResetPassword(User user, string password)
        {
            if (user != null)
            {
                user.Password = password;
                user.Id = await _context.SaveChangesAsync();
            }
        }
 
    }
}
