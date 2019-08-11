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
    public class ZipArchiveRepository : Repository<ZipArchive>, IZipArchiveRepository
    {
        public ZipArchiveRepository(DbContext context) : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
