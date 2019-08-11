using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Core.Domain
{
    public class ZipArchive
    {
        public int ID { get; set; }
        public string ArchiveName { get; set; }
        public string SavedFileName { get; set; }
        public string ArchiveHirachy { get; set; }
        public DateTime SavedDateTime { get; set; }
    }
}
