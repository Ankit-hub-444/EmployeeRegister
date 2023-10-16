using Microsoft.AspNetCore.Identity;
using EmployeeRegister.Models;

namespace EmployeeRegister.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
