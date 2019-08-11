using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Business
{
    public class UserManager : BaseManager
    {
        public bool CheckIfValiedUser(string userName, string password)
        {
            return UnitOfWork.Users.CheckIfUserExists(userName, password);
        }
    }
}
