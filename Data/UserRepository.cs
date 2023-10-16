using EmployeeRegister.Core.Repositories;
using EmployeeRegister.Models;
using Microsoft.AspNetCore.Identity;
using EmployeeRegister.Models;

namespace EmployeeRegister.Data
{
    public class UserRepository:IUserRepository
    {

        private readonly EmployeeMasterContext _context;
        public UserRepository(EmployeeMasterContext context) {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.ApplicationUser.ToList();
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.ApplicationUser.FirstOrDefault(u => u.Id == id);
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }

    }


}
