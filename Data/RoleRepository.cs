using EmployeeRegister.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EmployeeRegister.Data
{
    public class RoleRepository:IRoleRepository
    {
        private readonly EmployeeMasterContext _context;
        public RoleRepository(EmployeeMasterContext context) { 
          _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList(); 
        }
    }
}
