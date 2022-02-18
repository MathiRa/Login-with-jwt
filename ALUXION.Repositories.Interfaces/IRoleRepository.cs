using ALUXION.Domain;
namespace ALUXION.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetByRole(RoleType roletype);
    }
}
