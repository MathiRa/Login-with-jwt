using ALUXION.Domain;
using ALUXION.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ALUXION.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ALUXIONContext _context;
        public RoleRepository(ALUXIONContext context)
        {
            _context = context;
        }

        public async Task<Role> GetByRole(RoleType roletype)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.RoleType == roletype);
        }

    }
}
