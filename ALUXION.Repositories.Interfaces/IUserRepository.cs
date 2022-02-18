using ALUXION.Domain;
using System.Threading.Tasks;


namespace ALUXION.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByEmail(string email, bool active=true);
        Task<User> GetByIdAsync(int Id);
        Task<User> GetByEmailAndToken(string email, string token);
        Task ActiveUser(User user);
        Task<string> GenerateToken(User user);
        Task ResetPassword(User user, string password);
        
    }
}
