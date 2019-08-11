using BackendApp.Core.Domain;

namespace BackendApp.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckIfUserExists(string userName, string passWord);
    }
}
