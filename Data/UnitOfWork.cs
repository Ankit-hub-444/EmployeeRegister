using EmployeeRegister.Core.Repositories;
namespace EmployeeRegister.Data
{
    public class UnitOfWork :IUnitOfWork
    {
        public IUserRepository User { get; }

        public IRoleRepository Role { get; }

        public UnitOfWork(IUserRepository user,IRoleRepository role)
        {
            User = user;
            Role = role;
        }
    }
}
