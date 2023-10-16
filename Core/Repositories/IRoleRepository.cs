using Microsoft.AspNetCore.Identity;

namespace EmployeeRegister.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
