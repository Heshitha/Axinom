using BackendApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ZipArchive> ZipArchives { get; set; }
    }
}
