using BackendApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendApp.Core.Repositories;
using BackendApp.DataAccess.Repositories;

namespace BackendApp.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            ZipArchives = new ZipArchiveRepository(_context);
        }

        public IUserRepository Users
        {
            get;
            private set;
        }

        public IZipArchiveRepository ZipArchives
        {
            get;
            private set;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
