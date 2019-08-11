using BackendApp.Core.Domain;
using BackendApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BackendApp.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public bool CheckIfUserExists(string userName, string passWord)
        {
            return DataContext.Users.Any(x => x.Username == userName && x.Password == passWord);
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
