using BackendApp.Core;
using BackendApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Business
{
    public class BaseManager
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected BaseManager()
        {
            UnitOfWork = new UnitOfWork(new DataContext());
        }
    }
}
