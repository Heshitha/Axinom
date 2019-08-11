using BackendApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IZipArchiveRepository ZipArchives { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
